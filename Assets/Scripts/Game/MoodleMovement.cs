using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodleMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Rigidbody2D moodle;
    [SerializeField] float force;
    [SerializeField] int dir;
    [SerializeField] float screenEdge = 2.3f;

    bool isDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        moodle.velocity = new Vector2(0, moodle.velocity.y);
    }

    private void FixedUpdate()
    {
        if (isDown)
        {
            moodle.velocity = new Vector2(force * dir, moodle.velocity.y);
        }

        if (moodle.transform.position.x < -screenEdge)
            moodle.transform.position = new Vector3(screenEdge, moodle.transform.position.y, 0);
        if (moodle.transform.position.x > screenEdge)
            moodle.transform.position = new Vector3(-screenEdge, moodle.transform.position.y, 0);
    }
}
