using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{

    public class InputController : MonoBehaviour
    {
        [Header("Keys hold")]
        [SerializeField] KeyCode[] holdKeys;

        [Header("Keys down")]
        [SerializeField] KeyCode[] downKeys;

        [Header("Keys up")]
        [SerializeField] KeyCode[] upKeys;

        [Header("Actions on hold")]
        [SerializeField] InputAction[] holdActions;

        [Header("Actions on down")]
        [SerializeField] InputAction[] downActions;

        [Header("Actions on up")]
        [SerializeField] InputAction[] upActions;

        private void Start()
        {
            foreach (var item in holdActions)
                item.Init();

            foreach (var item in downActions)
                item.Init();

            foreach (var item in upActions)
            {
                Debug.Log("Init " + item.ToString());
                item.Init();
            }
        }

        private void Update()
        {
            for (int i = 0; i < holdKeys.Length; i++)
            {
                if (Input.GetKey(holdKeys[i]))
                    holdActions[i].Perform();
            }

            for (int i = 0; i < upKeys.Length; i++)
            {
                if (Input.GetKeyUp(upKeys[i]))
                    upActions[i].Perform();
            }

            for (int i = 0; i < downKeys.Length; i++)
            {
                if (Input.GetKeyDown(downKeys[i]))
                    downActions[i].Perform();
            }
        }
    }
}