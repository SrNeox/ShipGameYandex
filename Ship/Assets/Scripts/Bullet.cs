using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 5;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(-transform.forward * _speed * Time.deltaTime);
    }
}
