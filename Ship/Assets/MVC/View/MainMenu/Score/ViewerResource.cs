using TMPro;
using UnityEngine;

public class ViewerResource : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currnetScore;
    [SerializeField] private TextMeshProUGUI _currnetCoin;

    private void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        LocalBank.TryChangeScore();
        LocalBank.SumUpCoin();
        _currnetScore.text = $"{BankResource.Score}";
        _currnetCoin.text = $"{BankResource.Coin}";
    }
}
