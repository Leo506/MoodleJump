using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }
    
    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }
}
