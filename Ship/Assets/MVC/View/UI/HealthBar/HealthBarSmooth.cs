using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmooth : HealthView
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private Slider _healthBarSlider;

    private Coroutine _changeHealth;

    private readonly int _rateSmoothChange = 25;

    private void Start()
    {
        _healthBarSlider.maxValue = Health.MaxHealth;
        _healthBarSlider.value = Health.CurrentHealth;
    }

    public override void ChangeHealth()
    {
        if (_changeHealth != null)
            StopCoroutine(_changeHealth);

        _changeHealth = StartCoroutine(MakeChange());
    }

    private void ChangeValue() => _healthBarSlider.value = Mathf.MoveTowards(_healthBarSlider.value, Health.CurrentHealth, _rateSmoothChange * Time.deltaTime);

    private IEnumerator MakeChange()
    {
        while (_healthBarSlider.value != Health.CurrentHealth)
        {
            ChangeValue();

            if (_healthBarSlider.value == 0)
                _fillImage.enabled = false;

            yield return null;
        }
    }
}

