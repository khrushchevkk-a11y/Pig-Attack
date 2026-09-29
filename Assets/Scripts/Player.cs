using UnityEngine;

public class Player : MonoBehaviour
{
    public Leg leg;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumpSpeed = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leg.Kick(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leg.Kick(1);
        }
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpSpeed;
        }

    }
}
