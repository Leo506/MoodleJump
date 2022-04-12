using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public List<BlockMovement> platforms { get; private set; }
    public MonsterSpawner monsterSpawner { get; private set; }
    
    PlatformGeneratorData platformData;
    

    const float minX = -2.3f;
    const float xInterval = 0.46f;

    BlockMovement lastBlock;

    bool spawnMonster = false;

    public Generator(PlatformGeneratorData platformData, MonsterGeneratorData monsterData)
    {
        this.platformData = platformData;
        monsterSpawner = new MonsterSpawner(monsterData);
        BlockMovement.BlockDestroyedEvent += RemoveBlock;
    }

    ~Generator()
    {
        BlockMovement.BlockDestroyedEvent += RemoveBlock;
    }

    public void GenerateStartBlocks()
    {
        platforms = new List<BlockMovement>();
        for (int i = 0; i < 5; i++)
        {
            var yPos = platformData.startY + i * platformData.yInterval;
            Generate(yPos);
        }
    }

    public float CheckDistanceToGenerate(float distance, bool monster)
    {
        if (!spawnMonster)
            spawnMonster = monster;

        if (distance >= platformData.yInterval)
        {
            var yPos = lastBlock.transform.position.y + platformData.yInterval;

            if (spawnMonster)
            {
                GeneratePlatformsWithMonster(yPos);
                spawnMonster = false;
            }
            else
                Generate(yPos);
            return distance - platformData.yInterval;
        }

        return distance;
    }

    public void GeneratePlatformsWithMonster(float yPos)
    {
        Generate(yPos);
        monsterSpawner.SpawnMonster(lastBlock.transform.position.x);
    }

    private void Generate(float yPos)
    {
        List<int> usedIndexes = new List<int>();

        int platformCounts = Random.Range(1, 4);
        for (int i = 0; i < platformCounts; i++)
        {
            int index = GetRandomIndex(usedIndexes);
            if (index == -1)
                return;

            float xPos = minX + (index + 1) * xInterval;
            Vector2 pos = new Vector2(xPos, yPos);
            lastBlock = GameObject.Instantiate(platformData.blockPrefab, pos, Quaternion.identity);
            platforms.Add(lastBlock);
            usedIndexes.Add(index);
            usedIndexes.Add(index + 1);
        }
    }

    private int GetRandomIndex(List<int> usedIndexes)
    {
        if (!CheckSequence(usedIndexes))
            return -1;

        List<int> indexVariants = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            if (!usedIndexes.Contains(i))
            {
                indexVariants.Add(i);
            }
        }

        int indexToReturn;
        do
        {
            indexToReturn = indexVariants[Random.Range(0, indexVariants.Count)];
        } while (usedIndexes.Contains(indexToReturn + 1));

        return indexToReturn;
    }

    private bool CheckSequence(List<int> usedIndexes)
    {
        for (int i = 0; i < 9; i++)
        {
            if (!usedIndexes.Contains(i) && !usedIndexes.Contains(i + 1))
                return true;
        }

        return false;
    }

    private void RemoveBlock(BlockMovement block)
    {
        platforms.Remove(block);
    }
}
