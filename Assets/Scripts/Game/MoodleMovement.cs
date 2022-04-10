using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodleMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Rigidbody2D moodle;
    [SerializeField] float force;
    [SerializeField] int dir;

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
    }
}
