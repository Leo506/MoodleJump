using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PlatformGenerator platformGenerator;
    [SerializeField] MoodleSpawner moodleSpawner;
    [SerializeField] JumpController jumpController;
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] GameCanvas gameCanvas;
    [SerializeField] GameObject moodle;
    [SerializeField] MonsterSpawner monsterSpawner;

    int score = 0;
    bool gameOver = false;

    private void Start()
    {
        platformGenerator.GenerateStartBlocks();
        moodleSpawner.Spawn(platformGenerator.platforms[0].transform);

        Moodle.MoodleDiedEvent += GameOver;
    }

    private void OnDestroy()
    {
        Moodle.MoodleDiedEvent -= GameOver;
    }

    private void Update()
    {
        if (gameOver)
            return;


        var addScore = jumpController.CheckJump();
        if (addScore > 0)
        {
            MoveObjectsDown(addScore);
            score += (int)(addScore * 10);
            scoreUI.UpdateScore(score);
        }

        jumpController.Distance = platformGenerator.CheckDistanceToGenerate(jumpController.Distance, score / 100 == 1);
    }


    private void MoveObjectsDown(float distance)
    {
        moodle.transform.Translate(0, -distance, 0);
        foreach (var item in platformGenerator.platforms)
            item.transform.Translate(0, -distance, 0);
        foreach (var item in monsterSpawner.monstersOnScene)
            item.transform.Translate(0, -distance, 0);
    }

    private void GameOver()
    {
        gameOver = true;
        foreach (var item in platformGenerator.platforms)
            Destroy(item.gameObject);
        gameCanvas.GameOver();
    }
}
