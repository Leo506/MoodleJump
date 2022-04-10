using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodleSpawner : MonoBehaviour
{
    [SerializeField] GameObject moodle;

    // Start is called before the first frame update
    void Start()
    {
        var block = FindObjectOfType<PlatformGenerator>().platforms[0].gameObject.transform;
        moodle.transform.position = new Vector2(block.position.x, transform.position.y);
    }
}
