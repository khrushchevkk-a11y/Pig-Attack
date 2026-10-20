using UnityEngine;

public class RectangleSpawner : MonoBehaviour
{
    public FlyingRectangle prefab;
    public PlayerHealth player;
    public Transform leftPoint;
    public Transform rightPoint;
    public float interval = 1.5f;
    public float speed = 5f;
    private float timer;

    void Update()
    {
        if (player.Lives == 0) return;

        timer -= Time.deltaTime;
        if (timer > 0f) return;
        timer = interval;

        Transform point = Random.value < 0.5f ? leftPoint : rightPoint;
        FlyingRectangle rectangle = Instantiate(prefab, point.position, Quaternion.identity);
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)point.position).normalized;
        rectangle.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }
}
