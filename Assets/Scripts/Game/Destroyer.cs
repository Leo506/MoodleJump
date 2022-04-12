using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObj = collision.gameObject;
        var block = gameObj.GetComponent<Generating.BlockMovement>();

        
        
        Destroy(gameObj);
    }
}
