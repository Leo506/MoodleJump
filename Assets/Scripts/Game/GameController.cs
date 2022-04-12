using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generating;
using GameUI;
using Jumping;
using Moodle;

public class GameController : MonoBehaviour
{
    [SerializeField] MoodleSpawner moodleSpawner;
    [SerializeField] JumpController jumpController;
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] GameCanvas gameCanvas;
    [SerializeField] GameObject moodle;
    [SerializeField] PlatformGeneratorData platformGeneratorData;
    [SerializeField] MonsterGeneratorData monsterGeneratorData;

    int score = 0;
    bool gameOver = false;

    int scoreToSpawnMonster = 100;

    Generator generator;

    private void Start()
    {
        generator = new Generator(platformGeneratorData, monsterGeneratorData);
        generator.GenerateStartBlocks();

        moodleSpawner.Spawn(generator.platforms[0].transform);

        Moodle.Moodle.MoodleDiedEvent += GameOver;
    }

    private void OnDestroy()
    {
        Moodle.Moodle.MoodleDiedEvent -= GameOver;
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

        bool spawnMonster = false;
        if (score / scoreToSpawnMonster == 1)
        {
            spawnMonster = true;
            scoreToSpawnMonster += 100;
        }

        jumpController.Distance = generator.CheckDistanceToGenerate(jumpController.Distance, spawnMonster);
    }


    private void MoveObjectsDown(float distance)
    {
        moodle.transform.Translate(0, -distance, 0);
        foreach (var item in generator.platforms)
            item.transform.Translate(0, -distance, 0);
        foreach (var item in generator.monsterSpawner.monstersOnScene)
            item.transform.Translate(0, -distance, 0);
    }

    private void GameOver()
    {
        gameOver = true;
        foreach (var item in generator.platforms)
            Destroy(item.gameObject);
        gameCanvas.GameOver();
    }
}
