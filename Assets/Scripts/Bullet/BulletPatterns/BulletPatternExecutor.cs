using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternExecutor : MonoBehaviour
{
    private BulletController _bulletController;
    private BulletSpawner _bulletSpawner;
    
    [SerializeField] private float timeBtwSpawn;
    private float _previousSpawnTime = 0;
    
    [SerializeField] private List<BulletPattern> patterns = new List<BulletPattern>();

    public void Init(BulletController controller)
    {
        _previousSpawnTime = Time.time;
        _bulletController = controller;
        _bulletSpawner = GetComponent<BulletSpawner>();
    }
    
    public void ExecuteRandomPattern()
    {
        int randIndex = Random.Range(0, patterns.Count);
        ExecutePattern(randIndex);
    }
    
    public void ExecutePattern(int index)
    {
        List<Vector2> pattern = patterns[index].GetPatternInfo(); //트래킹 정리 포함
        foreach (Vector2 p in pattern)
        {
            Vector2 dir;
            if (patterns[index].isTrackingPlayer)
            {
                dir = _bulletController.GetPlayerDir(p);
            }
            else
            {
                dir = patterns[index].shootDirection;
            }
            _bulletSpawner.SpawnBullet(p, dir, _bulletController.bulletSpeed);
        }
    }
    
    private void Update()
    {
        if (Time.time > _previousSpawnTime + timeBtwSpawn)
        {
            ExecuteRandomPattern();
            _previousSpawnTime = Time.time;
        }
    }
}
