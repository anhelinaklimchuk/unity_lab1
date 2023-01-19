using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    public float speed;
    public float move;
    public float jump;
    public bool isJumping;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping==false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
