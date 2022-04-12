using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] Text scoreText;

        // Start is called before the first frame update
        void Start()
        {
            scoreText.text = "Score: 0";
        }

        public void UpdateScore(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}