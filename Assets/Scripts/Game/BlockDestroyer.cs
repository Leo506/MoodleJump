using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    [SerializeField] PlatformGenerator platformGenerator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObj = collision.gameObject;
        var block = gameObj.GetComponent<BlockMovement>();

        if (block != null)
            platformGenerator.platforms.Remove(block);
        
        Destroy(gameObj);
    }
}
