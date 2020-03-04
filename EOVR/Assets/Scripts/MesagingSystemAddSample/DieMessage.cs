using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QDRuntime.Internal
{
    public class DieMessage : BaseMessage
    {
        public GameObject monster;

        public DieMessage(GameObject monster)
        {
            this.monster = monster;
        }
    }
}
