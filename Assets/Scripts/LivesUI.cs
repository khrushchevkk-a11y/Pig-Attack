using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public PlayerHealth player;
    public Image[] squares = new Image[3];

    void Update()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].color = Color.red;
            squares[i].enabled = i < player.Lives;
        }
    }
}
