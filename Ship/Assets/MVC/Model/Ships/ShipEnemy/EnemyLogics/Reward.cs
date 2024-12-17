using UnityEngine;

public class Reward : MonoBehaviour
{
    private int _score;
    private int _coin;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthOver += SetReward;
    }

    private void OnDisable()
    {
        _health.HealthOver -= SetReward;
    }

    public void Init(int score, int coin)
    {
        _score = score;
        _coin = coin;
    }

    private void SetReward()
    {
        Debug.Log("Добавил очки");
        Debug.Log(_coin);
        Debug.Log(_score);

        LocalBank.AddCoin(_coin);
        LocalBank.AddScore(_score);
    }
}
