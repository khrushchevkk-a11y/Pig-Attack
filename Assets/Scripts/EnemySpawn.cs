using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public Transform _leftPoint;
    public Transform _rightPoint;
    public float _speed = 2f;
    public int _interval = 1;
    public int _maxinterval = 5;
    public float _timer; 
    void Spawn() {
        Transform point;
        Vector2 direction;
        if(Random.value > 0.5f) {
            point = _leftPoint;
            direction = Vector2.right;
        } else {
            point = _rightPoint;
            direction = Vector2.left;
        }

        GameObject enemy = Instantiate(_enemyPrefab, point.position, Quaternion.identity);
        enemy.GetComponent<Rigidbody2D>().linearVelocity = direction * _speed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
        _timer = Random.Range(_interval, _maxinterval);

    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0) {
            Spawn();
            _timer = Random.Range(_interval, _maxinterval);
        }
    }
}
