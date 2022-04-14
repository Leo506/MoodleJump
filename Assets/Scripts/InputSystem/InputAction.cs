using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public abstract class InputAction : ScriptableObject
    {
        public abstract void Init();
        public abstract void Perform();
    }
}
