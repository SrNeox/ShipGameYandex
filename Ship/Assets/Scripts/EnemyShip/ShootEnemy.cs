using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SearchPlayer))]
public class ShootEnemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _bulletSpeed = 1f;

    private SearchPlayer _searchPlayer;

    private float _nextFireTime = 0f;
    private Mover _player;

    private void Start()
    {
        _searchPlayer = GetComponent<SearchPlayer>();  
    }

    private void Update()
    {
        if(_searchPlayer._playerPosition != null)
        {
            Vector3 direction = _searchPlayer._playerPosition.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);

            if(Time.time > _nextFireTime)
            {
                Shoot();
                _nextFireTime += Time.time + 1f / _fireRate;
            }
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bullet, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _bulletSpeed; 
    }
}
