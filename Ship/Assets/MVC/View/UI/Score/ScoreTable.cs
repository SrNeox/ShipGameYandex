using TMPro;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private TextMeshProUGUI _textCoin;

    private Health _health;

    private void Start()
    {
        ChangeText();
    }

    public void Init(Health health)
    {
        if (_health != null)
        {
            _health.HealthOver -= ChangeText;
            _health = null;
        }

        _health = health;

        _health.HealthOver += ChangeText;
    }

    private void ChangeText()
    {
        _textScore.SetText($"{LocalBank.Score}");
        _textCoin.SetText($"{LocalBank.Coin}");
    }
}
