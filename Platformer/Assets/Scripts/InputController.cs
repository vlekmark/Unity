using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] float maxMovespeed = 7.5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] int maxJumps = 2;

    private int jumps = 0;
    private bool isJumping = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D) )
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.A) )
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Q) && isJumping == true)
        {
            transform.rotation = Quaternion.AngleAxis(rb.rotation + 5f,Vector3.forward);
        }
        if (Input.GetKey(KeyCode.E) && isJumping == true)
        {
            transform.rotation = Quaternion.AngleAxis(rb.rotation - 5f, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        GetComponent<AudioSource>().Play();

        if (collision.otherCollider.name == "BottomCollider")
        {
            jumps = 0;
        }
        else if (collision.otherCollider.name == "TopCollider")
        {

        }
        else if (collision.otherCollider.name == "LeftCollider")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce*1.5f);
            jumps = maxJumps;
            isJumping = true;
        }
        else if (collision.otherCollider.name == "RightCollider")
        {

        }
        else
        {
            jumps = 1;
        }
    }

    void MoveLeft()
    {
        sr.flipX = true;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMovespeed, maxMovespeed) - 1f, rb.velocity.y);
    }

    void MoveRight()
    {
        sr.flipX = false;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMovespeed, maxMovespeed) + 1f, rb.velocity.y);
    }

    void Jump()
    {
        isJumping = true;
        jumps++;

        if (jumps <= maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else
        {
            return;
        }
    }
}
