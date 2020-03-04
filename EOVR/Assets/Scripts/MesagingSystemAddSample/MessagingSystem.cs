using System.Collections.Generic;
using UnityEngine;

namespace QDRuntime.Internal
{
    public delegate bool MessageHandlerDelegate(BaseMessage msg);

    public class MessagingSystem : MonoBehaviour
    {
        private static MessagingSystem _Instance;

        public static MessagingSystem Instance
        {
            get { return (MessagingSystem)_Instance; }
        }

        private Dictionary<string, List<MessageHandlerDelegate>> _listenerDictionary = new Dictionary<string, List<MessageHandlerDelegate>>();
        private Queue<BaseMessage> _messageQueue = new Queue<BaseMessage>();
        private readonly float maxQueueProcessingTime = 0.1667f;

        private void Awake()
        {
            if(_Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public bool AttachListener(System.Type type, MessageHandlerDelegate handler)
        {
            if( type == null )
            {
                Debug.Log("MessagingSystem : AttachListener failed due to no message type specified");
                return false;
            }

            string msgName = type.Name;
            if( !_listenerDictionary.ContainsKey(msgName) )
                _listenerDictionary.Add(msgName, new List<MessageHandlerDelegate>());

            List<MessageHandlerDelegate> listenerList = _listenerDictionary[msgName];
            if (listenerList.Contains(handler))
                return false;

            listenerList.Add(handler);
            return true;
        }

        public bool DetachListener(System.Type type, MessageHandlerDelegate handler)
        {
            if( type == null )
            {
                Debug.Log("MessagingSystem : DetachListener failed due to no message type specified");
                return false;
            }

            string msgName = type.Name;
            if (!_listenerDictionary.ContainsKey(type.Name))
                return false;

            List<MessageHandlerDelegate> listenerList = _listenerDictionary[msgName];
            if (!listenerList.Contains(handler))
                return false;

            listenerList.Remove(handler);
            return true;
        }

        public bool QueueMesssage(BaseMessage msg)
        {
            if (!_listenerDictionary.ContainsKey(msg.name))
                return false;

            _messageQueue.Enqueue(msg);
            return true;
        }

        public bool TriggerMessage(BaseMessage msg)
        {
            string msgName = msg.name;
            if( !_listenerDictionary.ContainsKey(msgName) )
            {
                Debug.Log("MessagingSystem : Message \"" + msgName + "\" has no listeners!");
                return false;
            }

            List<MessageHandlerDelegate> listenerList = _listenerDictionary[msgName];
            for( int i=0; i<listenerList.Count; ++i )
            {
                if (listenerList[i](msg))
                    return true;
            }

            return true;
        }

        private void Update()
        {
            float timer = 0.0f;
            while( _messageQueue.Count > 0 )
            {
                if( maxQueueProcessingTime > 0.0f )
                {
                    if (timer > maxQueueProcessingTime)
                        return;
                }

                BaseMessage msg = _messageQueue.Dequeue();
                if (!TriggerMessage(msg))
                    Debug.Log("MessagingSystem : Error when processing message - " + msg.name);

                //처리할 일

                if (maxQueueProcessingTime > 0.0f)
                    timer += Time.deltaTime;
            }
        }
    }
}
