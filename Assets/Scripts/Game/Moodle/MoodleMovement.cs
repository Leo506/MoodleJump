using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Moodle
{
    public class MoodleMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D moodle;
        [SerializeField] InputSystem.InputAction dAction, aAction, stopAction;
        [SerializeField] float screenEdge = 2.3f;

        private void Start()
        {
            dAction.Init();
            aAction.Init();
            stopAction.Init();
        }


        private void Update()
        {
            // Движение в стороны
            if (Input.GetKey(KeyCode.D))
            {
                dAction.Perform();
            }
            if (Input.GetKey(KeyCode.A))
            {
                aAction.Perform();
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                stopAction.Perform();
            }

            // Телепорт из одного края экрана в другой
            if (moodle.transform.position.x < -screenEdge)
                moodle.transform.position = new Vector3(screenEdge, moodle.transform.position.y, 0);
            if (moodle.transform.position.x > screenEdge)
                moodle.transform.position = new Vector3(-screenEdge, moodle.transform.position.y, 0);
        }
    }
}