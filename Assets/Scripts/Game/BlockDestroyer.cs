using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObj = collision.gameObject;
        var block = gameObj.GetComponent<BlockMovement>();

        
        
        Destroy(gameObj);
    }
}
