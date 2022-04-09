using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] float startY;
    public float yInterval;
    [SerializeField] float yInGame;
    [SerializeField] float spawnInterval;
    const float minX = -2.3f;
    const float interval = 0.46f;

    public GameObject lastBlock;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            var yPos = startY + i * yInterval;
            Generate(yPos);
        }

    }

    public void Generate(float yPos = 7.240001f)
    {
        List<int> usedIndexes = new List<int>();

        int platformCounts = Random.Range(1, 4);
        for (int i = 0; i < platformCounts; i++)
        {
            int index = GetRandomIndex(usedIndexes);
            if (index == -1)
                return;

            float xPos = minX + (index + 1) * interval;
            Vector2 pos = new Vector2(xPos, yPos);
            lastBlock = Instantiate(platformPrefab, pos, Quaternion.identity);
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

    private IEnumerator Spawning(float interval)
    {
        while (true)
        {
            Generate(yInGame);
            yield return new WaitForSeconds(interval);
        }
    }
}