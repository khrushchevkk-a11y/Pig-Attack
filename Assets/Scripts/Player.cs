using UnityEngine;

public class Player : MonoBehaviour
{
    public Leg leg;
    private Rigidbody2D rb;
    private Collider2D bodyCollider;
    public LayerMask groundLayer;
    public float jumpSpeed = 10f;
    public bool IsGrounded => rb != null && bodyCollider != null
        && rb.linearVelocity.y <= 0.1f
        && bodyCollider.IsTouchingLayers(groundLayer);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            leg.CancelKick();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }

        if (!IsGrounded)
        {
            leg.CancelKick();
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leg.Kick(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leg.Kick(1);
        }
    }
}
