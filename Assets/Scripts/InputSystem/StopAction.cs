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
        }

        public override void Perform()
        {
            moodleRb.velocity = new Vector2(0, moodleRb.velocity.y);
        }
    }
}