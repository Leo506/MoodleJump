using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static event System.Action<Monster> MonsterDiedEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var moodle = collision.gameObject.GetComponent<Moodle>();
        if (moodle != null)
            Destroy(moodle.gameObject);
    }

    private void OnDestroy()
    {
        MonsterDiedEvent?.Invoke(this);
    }
}
