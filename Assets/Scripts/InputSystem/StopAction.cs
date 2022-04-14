using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    [CreateAssetMenu(fileName ="Input action", menuName = "InputSystem/StopAction")]
    public class StopAction : InputAction
    {
        Rigidbody2D moodleRb;

        public override void Init()
        {
            moodleRb = FindObjectOfType<Moodle.Moodle>().GetComponent<Rigidbody2D>();
            Debug.Log("Moodle rb on start == null: " + (moodleRb == null));
        }

        public override void Perform()
        {
            Debug.Log("MoodleRb == null: " +  (moodleRb == null));
            moodleRb.velocity = new Vector2(0, moodleRb.velocity.y);
        }
    }
}