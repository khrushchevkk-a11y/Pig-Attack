using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Lives { get; private set; } = 3;

    public void TakeDamage()
    {
        if (Lives == 0) return;
        Lives--;

        if (Lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
