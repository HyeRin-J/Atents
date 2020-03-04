using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDRuntime.Internal
{
    public class BaseMessage
    {
        public string name;

        public BaseMessage()
        {
            name = this.GetType().Name;
        }
    }
}
