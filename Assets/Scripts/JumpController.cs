using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] GameObject moodle;
    [SerializeField] float line;
    [SerializeField] PlatformGenerator generator;
    float lastYPos;
    float summDistance = 0;

    private void Start()
    {
        lastYPos = moodle.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (moodle.transform.position.y > line && (moodle.transform.position.y - lastYPos) > 0)
        {
            summDistance += moodle.transform.position.y - lastYPos;
            foreach (var item in FindObjectsOfType<BlockMovement>())
            {
                item.transform.Translate(0, -(moodle.transform.position.y - lastYPos), 0);
            }
            moodle.transform.Translate(0, -(moodle.transform.position.y - lastYPos), 0);
        }
        lastYPos = moodle.transform.position.y;

        if (summDistance >= 2.334f)
        {
            var yPos = generator.lastBlock.transform.position.y + generator.yInterval;
            generator.Generate(yPos);
            summDistance -= 2.334f;
        }
    }
}
