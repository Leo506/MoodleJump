using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodleSpawner : MonoBehaviour
{
    [SerializeField] GameObject moodle;

    public void Spawn(Transform spawnTransform)
    {
        moodle.transform.position = new Vector2(spawnTransform.position.x, transform.position.y);
    }
}
