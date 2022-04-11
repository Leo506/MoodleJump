using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D moodle;
    [SerializeField] float force;
    [SerializeField] float screenEdge = 2.3f;


    private void Update()
    {
        // Движение в стороны
        if (Input.GetKey(KeyCode.D))
        {
            moodle.velocity = new Vector2(force, moodle.velocity.y);
            Debug.Log("Button D pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            moodle.velocity = new Vector2(-force, moodle.velocity.y);
            Debug.Log("Button A pressed");
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            moodle.velocity = new Vector2(0, moodle.velocity.y);
            Debug.Log("Button up");
        }

        // Телепорт из одного края экрана в другой
        if (moodle.transform.position.x < -screenEdge)
            moodle.transform.position = new Vector3(screenEdge, moodle.transform.position.y, 0);
        if (moodle.transform.position.x > screenEdge)
            moodle.transform.position = new Vector3(-screenEdge, moodle.transform.position.y, 0);
    }
}
