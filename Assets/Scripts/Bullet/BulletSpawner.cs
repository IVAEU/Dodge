using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet bulletObj;
    private List<Bullet> _spawnedBullet = new List<Bullet>();
    
    public Bullet SpawnBullet(Vector2 pos, Vector2 dir, float spd)
    {
        Bullet bullet = Instantiate(bulletObj, pos, Quaternion.identity);
        bullet.Init(this);
        bullet.SetBulletData(dir, spd);
        _spawnedBullet.Add(bullet);
        return bullet;
    }

    public void RemoveBullet(Bullet bullet)
    {
        _spawnedBullet.Remove(bullet);
    }
}
