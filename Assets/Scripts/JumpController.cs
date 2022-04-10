using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] GameObject moodle;
    [SerializeField] float line;
    [SerializeField] PlatformGenerator platformGenerator;
    [SerializeField] ScoreUI scoreUI;
    float lastYPos;
    public float summDistance { get; set; }

    private void Start()
    {
        summDistance = 0;
        lastYPos = moodle.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var moodleYPos = moodle.transform.position.y;
        if (moodleYPos > line && (moodleYPos - lastYPos) > 0)
        {
            summDistance += moodleYPos - lastYPos;
            scoreUI.UpdateScore((int)((moodleYPos - lastYPos) * 10));
            
            foreach (var item in platformGenerator.platforms)
                item.transform.Translate(0, -(moodle.transform.position.y - lastYPos), 0);

            moodle.transform.Translate(0, -(moodleYPos - lastYPos), 0);
        }
        lastYPos = moodleYPos;
    }
}
