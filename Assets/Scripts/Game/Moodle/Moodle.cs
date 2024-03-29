using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moodle
{
    public class Moodle : MonoBehaviour
    {
        public static System.Action MoodleDiedEvent;

        private void OnDestroy()
        {
            MoodleDiedEvent?.Invoke();
        }
    }
}