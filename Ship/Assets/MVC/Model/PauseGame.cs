using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField]private Button[] _buttons;

    private static bool isPaused = true;

    void Start()
    {
        Time.timeScale = 0;

        foreach (Button button in _buttons) 
        { 
            button.onClick.AddListener(TogglePause); 
        }
    }

    public static void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
