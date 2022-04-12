using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumping
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] GameObject moodle;
        [SerializeField] float line;

        float lastYPos;
        public float Distance { get; set; }

        private void Start()
        {
            Distance = 0;
            lastYPos = moodle.transform.position.y;
        }

        public float CheckJump()
        {
            var moodleYPos = moodle.transform.position.y;
            var difference = moodleYPos - lastYPos;
            if (moodleYPos > line && difference > 0)
            {
                Distance += difference;
                lastYPos = moodleYPos;
                return difference;
            }

            lastYPos = moodleYPos;

            return 0;
        }
    }
}
