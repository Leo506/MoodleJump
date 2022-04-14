using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Moodle
{
    public class MoodleMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D moodle;
        [SerializeField] float screenEdge = 2.3f;


        private void Update()
        {
            
            // Телепорт из одного края экрана в другой
            if (moodle.transform.position.x < -screenEdge)
                moodle.transform.position = new Vector3(screenEdge, moodle.transform.position.y, 0);
            if (moodle.transform.position.x > screenEdge)
                moodle.transform.position = new Vector3(-screenEdge, moodle.transform.position.y, 0);
        }
    }
}