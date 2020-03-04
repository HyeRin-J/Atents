using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QDRuntime.Internal;

namespace QDRuntime.Internal
{
    public class DieClass : MonoBehaviour
    {
        void Start()
        {
            MessagingSystem.Instance.AttachListener(typeof(DieMessage), this.HandleYourMesssageListener);
        }

        void OnDestroy()
        {
            MessagingSystem.Instance.DetachListener(typeof(DieMessage), this.HandleYourMesssageListener);
        }

        private bool HandleYourMesssageListener(BaseMessage msg)
        {
            if (msg == null)
            {
                Debug.Log("HandleYourMesssageListener : Message is null!");
                return false;
            }

            DieMessage castMsg = msg as DieMessage;
            if (castMsg == null)
            {
                Debug.Log("HandleYourMesssageListener : Cast Message is null!");
                return false;
            }

            BattleMonster monster = castMsg.monster.GetComponent<BattleMonster>();

            Debug.Log(string.Format("{0} is Dead.", monster.monsterCharacter.monStatRecord.Name));

            // 처리해야 할 일
            monster.Dead();
            BattleManager.Instance.turnProgressSequence.Remove(monster.gameObject);



            return true;
        }
    }
}