using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class FlyingRectangle : MonoBehaviour
{
    private bool destroyed;
    private PlayerHealth touchedPlayer;

    void Awake()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Dynamic;
        body.gravityScale = 0f;
        body.freezeRotation = true;
        GetComponent<BoxCollider2D>().isTrigger = true;
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CheckHit(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        CheckHit(other);
    }

    void CheckHit(Collider2D other)
    {
        if (destroyed) return;

        Leg leg = other.GetComponent<Leg>();
        if (leg != null)
        {
            if (leg.IsKicking)
            {
                destroyed = true;
                Destroy(gameObject);
            }
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null) touchedPlayer = health;
    }

    void LateUpdate()
    {
        // Если нога и тело задеты в одном кадре, пинок имеет приоритет.
        if (destroyed || touchedPlayer == null) return;
        touchedPlayer.TakeDamage();
        destroyed = true;
        Destroy(gameObject);
    }
}
