using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _leftBoundary = -5f;
    [SerializeField] private float _rightBoundary = 5f;

    private bool _isMovingRight = true;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_isMovingRight)
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.right, Space.World);

            if (transform.position.x >= _rightBoundary)
            {
                _isMovingRight = false;
            }
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.left, Space.World);

            if (transform.position.x <= _leftBoundary)
            {
                _isMovingRight = true;
            }
        }
    }
}
