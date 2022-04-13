using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        [SerializeField] Text scoreListText;

        // Start is called before the first frame update
        void Start()
        {
            HightScores.ScoresLoadedEvent += SetScoresText;

            scoreText.text = "Score: 0";
            scoreListText.text = "Hight scores:\n" +
                                "1. 0\n" +
                                "2. 0\n" +
                                "3. 0";
        }

        private void OnDestroy()
        {
            HightScores.ScoresLoadedEvent -= SetScoresText;
        }

        private void SetScoresText(List<int> scores)
        {
            scoreListText.text = "Hight scores:\n";
            for (int i = 0; i < scores.Count; i++)
                scoreListText.text += $"{i + 1}. {scores[i].ToString()}\n";

            for (int i = scores.Count; i < 3; i++)
                scoreListText.text += $"{i + 1}. 0\n";
        }

        public void UpdateScore(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}