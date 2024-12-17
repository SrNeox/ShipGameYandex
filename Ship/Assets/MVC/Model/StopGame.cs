using UnityEngine;

public class StopGame : MonoBehaviour
{
    [SerializeField] private Health _helathPlayer;
    [SerializeField] private Canvas _canvas;

    private void OnEnable()
    {
        _helathPlayer.HealthOver += Stop;
    }

    private void OnDisable()
    {
        _helathPlayer.HealthOver -= Stop;
    }

    private void Stop()
    {
        Time.timeScale = 0; 
        _canvas.gameObject.SetActive(true);
    }
}
