using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner
{
    public List<Monster> monstersOnScene { get; set; }

    MonsterGeneratorData monsterData;

    public MonsterSpawner(MonsterGeneratorData monsterData)
    {
        this.monsterData = monsterData;
        monstersOnScene = new List<Monster>();
        Monster.MonsterDiedEvent += RemoveMonster;
    }

    ~MonsterSpawner()
    {
        Monster.MonsterDiedEvent -= RemoveMonster;
    }

    void RemoveMonster(Monster monster)
    {
        monstersOnScene.Remove(monster);
    }    

    public void SpawnMonster(float xPos)
    {
        var monster = GameObject.Instantiate(monsterData.monsterPrefab, new Vector2(xPos, monsterData.yPos), Quaternion.identity);
        monstersOnScene.Add(monster);
    }
}
