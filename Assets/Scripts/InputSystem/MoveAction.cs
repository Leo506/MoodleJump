using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    [CreateAssetMenu(fileName = "Input action", menuName = "InputSystem/Move Action")]
    public class MoveAction : InputAction
    {
        [SerializeField] float force;
        [SerializeField] int direction;

        Rigidbody2D moodleRb;

        public override void Init()
        {
            moodleRb = FindObjectOfType<Moodle.Moodle>().GetComponent<Rigidbody2D>();
        }

        public override void Perform()
        {
            moodleRb.velocity = new Vector2(force * direction, moodleRb.velocity.y);
        }
    }
}