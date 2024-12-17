using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdaterText : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _speed;
    [SerializeField] private TextMeshProUGUI _currentCoin;
    [SerializeField] private Button _button;

    private void Start()
    {
        Refresh();
        _button.onClick.AddListener(Refresh);
    }

    public void Refresh()
    {
        _health.text = $"{_playerInfo.MaxHealth}";
        _damage.text = $"{_playerInfo.Damage}";
        _speed.text = $"{_playerInfo.Speed}";
        _currentCoin.text = $"{BankResource.Coin}";
    }
}
