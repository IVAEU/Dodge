using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private BulletSpawner _spawner;

    public void Init(BulletSpawner bulletSpawner)
    {
        _spawner = bulletSpawner;
        if (rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyBullet), 5f);
    }
    
    public void SetBulletData(Vector2 dir, float spd)
    {
        if(rb == null) return;
        rb.velocity = dir.normalized * spd;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.TakeDamage(1);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        _spawner.RemoveBullet(this);
        Destroy(gameObject);
    }
}
