using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hp : MonoBehaviour
{
    public int Lives { get; private set; } = 5;
    public void TakeDamage(int damage)
    {
        if(Lives <= 0) return;

        Lives -= damage;
        if (Lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
