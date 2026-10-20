using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] _hearts = new Image[5];
    public Hp _hp;
    

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _hp.Lives)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}
