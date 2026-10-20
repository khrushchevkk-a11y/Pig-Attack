using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isDead)
        {
            return;
        }
        Leg leg = collision.gameObject.GetComponent<Leg>();
        Hp player = collision.gameObject.GetComponent<Hp>();

        if (leg != null && leg.IsKicking)
        {
            _isDead = true;
            Destroy(gameObject);
        }
        else if (player != null)
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}