using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{

    public class InputController : MonoBehaviour
    {
        [Header("Keys down")]
        [SerializeField] KeyCode[] keysD;

        [Header("Keys up")]
        [SerializeField] KeyCode[] keysU;

        [Header("Actions on down")]
        [SerializeField] InputAction[] downActions;

        [Header("Actions on up")]
        [SerializeField] InputAction[] upActions;

        private void Start()
        {
            foreach (var item in downActions)
                item.Init();

            foreach (var item in upActions)
                item.Init();
        }

        private void Update()
        {
            for (int i = 0; i < keysD.Length; i++)
            {
                if (Input.GetKey(keysD[i]))
                    downActions[i].Perform();
            }

            for (int i = 0; i < keysU.Length; i++)
            {
                if (Input.GetKeyUp(keysU[i]))
                    upActions[i].Perform();
            }
        }
    }
}