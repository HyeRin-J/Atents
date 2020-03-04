using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [HideInInspector] public GameObject playerObj;
    [HideInInspector] public Vector3 tempPos;  // 마을에서 마지막 이동한 MovePoint 의 position
    [HideInInspector] public Quaternion tempRotation; // 마을에서 마지막 이동한 MovePoint 의 rotation
    //public Transform lastTr;
    public List<GameObject> FOEs = new List<GameObject>();
    public Vector3 playerCameraPosition;
    public Vector3 playerCameraRotation;
    public int playerDirectionNum = 0;
    public int[] directionArrowPos = new int[2];
    public Vector3 directionArrowRotation;

    public int mapSize = 20;
    public int floor = 1;
    public Vector2 startPosition;
    static SceneChanger _instance;
    public static SceneChanger instance
    {
        get { return _instance; }
    }

    public GameObject[] allGameObjects = new GameObject[20];

    public SpawnCase spawnCase = SpawnCase.One;
    [HideInInspector]
    public int foeId = 0;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        TableMgr.Instance.CheckLoad();

        _instance = this;
        DontDestroyOnLoad(gameObject);
        allGameObjects = new GameObject[20];
        SceneManager.sceneLoaded += OnSceneLoaded;
        FindGameObjects();
    }

    public void SceneChange()
    {
        foreach (var obj in allGameObjects)
        {
            if (obj == null) continue;
            if (obj.CompareTag("PlayerManager")) continue;

            if (obj.name.Equals("Player"))
            {
                obj.GetComponent<PlayerMove>().enabled = true;
            }
            obj.SetActive(!obj.activeSelf);
        }
        gameObject.SetActive(true);
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        if (aScene.isLoaded)
        {
            FOEs.Clear();
            FindGameObjects();
        }
    }

    public void FindGameObjects()
    {
        int i = 0;
        foreach (var obj in FindObjectsOfType<GameObject>())
        {
            if (LayerMask.LayerToName(obj.layer).Equals("InLabyrinth"))
            {
                allGameObjects[i] = obj;
                i++;
            }
        }
      
        foreach (var obj in allGameObjects)
        {
            if (obj == null) break;
            if (obj.CompareTag("Player"))
            {
                playerObj = obj;
            }
            if (obj.CompareTag("Map"))
            {
                mapSize = obj.GetComponent<MapData>().mapSize;
                floor = obj.GetComponent<MapData>().floor;
            }
            if (obj.CompareTag("FOE"))
            {
                if(!FOEs.Contains(obj))
                    FOEs.Add(obj);
            }
        }
    }

    public void Go_OpenField()
    {
        SceneManager.LoadScene("OpenField");
        playerCameraPosition = new Vector3(105, 2, 185);
        playerCameraRotation = new Vector3(0f, 90f, 0f);
        startPosition = new Vector2(38, -120);
        playerDirectionNum = 1;
        directionArrowRotation = new Vector3(0, 0, 90);
        playerObj.GetComponent<PlayerMove>().directionNum = 1;
    }
    public void GoIN_INN()
    {
        SceneManager.LoadScene("Scene_INN");
    }
    public void GoINShop()
    {
        SceneManager.LoadScene("Scene_Shop");

    }
    public void GoINRequest()
    {
        SceneManager.LoadScene("Scene_Request");
    }
    public void GoINGuild()
    {
        SceneManager.LoadScene("Scene_Guild");
    }

    public void GoVillage()
    {
        SceneManager.LoadScene("Village");
    }

    public void SetPlayerPosition()
    {
        if (SceneManager.GetActiveScene().name.Equals("Village") && tempPos != new Vector3(0f,0f,0f))
        {
            playerObj.transform.position = tempPos;
            playerObj.transform.rotation = tempRotation * Quaternion.Euler(0,180f,0);
            tempPos = new Vector3(0f, 0f, 0f);
            //lastTr = null;
            playerObj = null;
        }
    }
}
