using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float Speed = 10f;
    public bool isJumping;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");// -1 to 1
        rb.velocity = new Vector2(Speed * moveX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            rb.AddForce(new Vector2(rb.velocity.x, 1000));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isJumping = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isJumping = true;
    }
}
