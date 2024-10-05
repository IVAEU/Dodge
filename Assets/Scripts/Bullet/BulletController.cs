using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletSpawner _bulletSpawner;
    private BulletPatternExecutor _bulletPatternExecutor;

    public float bulletSpeed;

    public void Awake()
    {
        _bulletPatternExecutor = GetComponent<BulletPatternExecutor>(); //null check
        _bulletPatternExecutor.Init(this);
        _bulletSpawner = GetComponent<BulletSpawner>(); //null check
    }

    public Vector2 GetPlayerDir(Vector2 basePos)
    {
        Vector2 playerPos = PlayerController.Instance.transform.position;
        return -(basePos - playerPos).normalized;
    }
}
