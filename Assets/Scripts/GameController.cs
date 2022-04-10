using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PlatformGenerator platformGenerator;
    [SerializeField] MoodleSpawner moodleSpawner;
    [SerializeField] JumpController jumpController;
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] GameObject moodle;

    int score;

    private void Start()
    {
        platformGenerator.GenerateStartBlocks();
        moodleSpawner.Spawn(platformGenerator.platforms[0].transform);

        score = 0;
    }

    private void Update()
    {
        var addScore = jumpController.CheckJump();
        if (addScore > 0)
        {
            MoveObjectsDown(addScore);
            score += (int)(addScore * 10);
            scoreUI.UpdateScore(score);
        }

        jumpController.Distance = platformGenerator.CheckDistanceToGenerate(jumpController.Distance);
    }


    private void MoveObjectsDown(float distance)
    {
        moodle.transform.Translate(0, -distance, 0);
        foreach (var item in platformGenerator.platforms)
            item.transform.Translate(0, -distance, 0);
    }
}
