using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpAction : MonoBehaviour
{
    [SerializeField] Vector2 jumpForce;
    Rigidbody2D rb2d;
    bool inJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb2d.velocity.y < 0)
        {
            inJump = false;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal != Vector2.up || inJump)
            return;

        inJump = true;
        rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
        //Debug.Log("Jump!!!");
    }
}
