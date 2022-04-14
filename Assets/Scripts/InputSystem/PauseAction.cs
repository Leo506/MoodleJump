using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    [CreateAssetMenu(fileName = "Input action", menuName = "InputSystem/PauseAction")]
    public class PauseAction : InputAction
    {
        Canvas pauseCanvas;
        
        static bool isPause = false;

        public override void Init()
        {
            pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<Canvas>();
        }

        public override void Perform()
        {
            isPause = !isPause;
            Time.timeScale = isPause ? 0.0f : 1.0f;
            
            if (pauseCanvas != null)
                pauseCanvas.enabled = isPause;
            
            Debug.Log("Pause: " + isPause);
        }
    }
}