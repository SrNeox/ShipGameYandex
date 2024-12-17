using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= ChangeHealth;
    }

    public abstract void ChangeHealth();
}
