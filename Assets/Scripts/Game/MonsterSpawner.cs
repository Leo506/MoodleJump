using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Monster monsterPrefab;
    [SerializeField] float ySpawnPoint;

    public List<Monster> monstersOnScene;

    private void Start()
    {
        monstersOnScene = new List<Monster>();
        Monster.MonsterDiedEvent += RemoveMonster;
    }

    private void OnDestroy()
    {
        Monster.MonsterDiedEvent -= RemoveMonster;
    }

    void RemoveMonster(Monster monster)
    {
        monstersOnScene.Remove(monster);
    }    

    public void SpawnMonster(float xPos)
    {
        var monster = Instantiate(monsterPrefab, new Vector2(xPos, ySpawnPoint), Quaternion.identity);
        monstersOnScene.Add(monster);
    }
}
