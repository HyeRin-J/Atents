using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SpawnCase
{
    One,
    OneTwo,
    Three,
    ThreeTwo,
    Big,
    Foe,
    Boss,
}

public class SpawnManager : MonoBehaviour
{
    SpawnCase spawnCase = SpawnCase.OneTwo; //스폰케이스

    #region 유니티상에서 등록해야 할 몬스터 프리팹들
    public GameObject[] spawnPoints;
    public GameObject[] normals;
    public GameObject[] bigs;
    public GameObject[] foes;
    public GameObject[] bosses;
    #endregion

    public GameObject[] spawnMonsters;  //현재 스폰된 몬스터 배열

    public int spawnCount = 0;  //현재 스폰된 몬스터 수

    public AudioClip foeClip;   //foe시 바꿀 BGM

    public int totalExp;

    public List<DropItemRecord> monsterDropItem;
    int dropRate;

    private void Start()
    {

        totalExp = 0;
        //스폰 시 foe인지 아닌지를 검사
        if (SceneChanger.instance != null)
            spawnCase = (SceneChanger.instance.spawnCase == SpawnCase.Foe) ? SpawnCase.Foe : (SpawnCase)Random.Range(0, (int)SpawnCase.Big + 1);
        else
            spawnCase = (SpawnCase)Random.Range(0, (int)SpawnCase.Big + 1);

        //몬스터가 스폰될 위치배열
        int[] spawnPointsIndex = { 0 };

        switch (spawnCase)
        {
            case SpawnCase.One:
                spawnCount = 1;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 1;
                break;
            case SpawnCase.OneTwo:
                spawnCount = 3;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 1;
                spawnPointsIndex[1] = 3;
                spawnPointsIndex[2] = 5;
                break;
            case SpawnCase.Three:
                spawnCount = 3;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 0;
                spawnPointsIndex[1] = 1;
                spawnPointsIndex[2] = 2;
                break;
            case SpawnCase.ThreeTwo:
                spawnCount = 5;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 0;
                spawnPointsIndex[1] = 1;
                spawnPointsIndex[2] = 2;
                spawnPointsIndex[3] = 3;
                spawnPointsIndex[4] = 5;
                break;
            case SpawnCase.Big:
                spawnCount = 1;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 1;
                break;
            case SpawnCase.Foe:
                spawnCount = 1;
                spawnPointsIndex = new int[spawnCount];
                spawnPointsIndex[0] = 1;
                GetComponent<AudioSource>().clip = foeClip;
                GetComponent<AudioSource>().Play();
                break;
        }

        spawnMonsters = new GameObject[spawnCount];

        if (spawnCase == SpawnCase.Big)
        {
            spawnMonsters[0] = Instantiate(bigs[Random.Range(0, bigs.Length)], spawnPoints[spawnPointsIndex[0]].transform);
        }
        else if (spawnCase == SpawnCase.Foe)
        {
            spawnMonsters[0] = Instantiate(foes[SceneChanger.instance.foeId], spawnPoints[spawnPointsIndex[0]].transform);
        }
        else
        {
            if (SceneChanger.instance.floor >= 4) return;
            for (int i = 0; i < spawnMonsters.Length; i++)
            {
                int index = Random.Range(10 * (SceneChanger.instance.floor - 1), (14 * SceneChanger.instance.floor));
                index = index >= normals.Length ? normals.Length - 1 : index;
                spawnMonsters[i] = Instantiate(normals[index], spawnPoints[spawnPointsIndex[i]].transform);
            }
        }

        StartCoroutine(SetResultInfo());
    }

    //몬스터 죽을 때 호출
    public void DestoryMonster(GameObject monster)
    {
        //새로운 임시 배열 생성
        GameObject[] temp = new GameObject[spawnCount - 1];

        for (int i = 0, j = 0; i < spawnMonsters.Length; i++)
        {
            //삭제될 몬스터랑 같지 않으면 임시 배열에 저장
            if (!spawnMonsters[i].Equals(monster))
            {
                temp[j] = spawnMonsters[i];
                j++;
            }
        }

        //남은 몬스터들을 다시 배열에 집어넣음
        spawnMonsters = temp;

        //스폰된 몬스터 숫자 감소
        spawnCount = spawnMonsters.Length;

        //배틀 종료 확인
        if(spawnCount == 0)
        { 
            GetComponent<BattleUIManager>().StartCoroutine(GetComponent<BattleUIManager>().ResultDelay());
            GetComponent<BattleManager>().StopTurnProgressingCoroutine();
        }

        Destroy(monster);
    }

    IEnumerator SetResultInfo()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < spawnMonsters.Length; i++)
        {
            totalExp += spawnMonsters[i].GetComponent<BattleMonster>().monsterCharacter.monStatRecord.Exp;

            dropRate = Random.Range(0, 10);
            Debug.Log("dropRate : " + dropRate);
            if (dropRate < 7 && spawnCase != SpawnCase.Boss)
            {
                monsterDropItem.Insert(i, TableMgr.Instance.dropItemTable.GetRecord(spawnMonsters[i].GetComponent<BattleMonster>().monNID + (int)MonsterVariables.DropItemtoMonster));
            }
            else if (spawnCase == SpawnCase.Boss)
            {
                monsterDropItem.Insert(i, TableMgr.Instance.dropItemTable.GetRecord(spawnMonsters[i].GetComponent<BattleMonster>().monNID + (int)MonsterVariables.DropItemtoMonster));
            }
            else
            {
                monsterDropItem.Insert(i, null);
            }   
        }

        monsterDropItem.RemoveAll(item => item == null);
        Debug.Log("monsterDropItemCount : " + monsterDropItem.Count);
    }
}
