using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameUI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] Canvas gameOverCanvas;
        [SerializeField] Canvas mainCanvas;

        public void GameOver()
        {
            if (mainCanvas != null)
                mainCanvas.enabled = false;
            
            if (gameOverCanvas != null)
                gameOverCanvas.enabled = true;
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}