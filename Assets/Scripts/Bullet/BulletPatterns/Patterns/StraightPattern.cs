using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Straight")]
public class StraightPattern : BulletPattern
{
    public override bool isTrackingPlayer { get; set; } = true;
    public override Vector2 shootDirection { get; set; }
    
    enum ShootDirection
    {
        Right,
        Left,
        Up,
        Down
    }
    
    enum ExpendDirection
    {
        Horizontal,
        Vertical,
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private ShootDirection shootDir;
    [SerializeField] private ExpendDirection expendDir;
    [SerializeField] private float expendDistance;
    [SerializeField] private int bulletAmount = 1;
    
    public override List<Vector2> GetPatternInfo()
    {
        List<Vector2> bulletPos = new List<Vector2>();
        for(int i = 0; i < bulletAmount; i++)
        {
            Vector2 spawnPos = Vector2.zero;
            switch (shootDir)
            {
                case ShootDirection.Right:
                    shootDirection = Vector2.right;
                    break;
                case ShootDirection.Left:
                    shootDirection = Vector2.left;
                    break;
                case ShootDirection.Up:
                    shootDirection = Vector2.up;
                    break;
                case ShootDirection.Down:
                    shootDirection = Vector2.down;
                    break;
            }
            switch (expendDir)
            {
                case ExpendDirection.Horizontal:
                    if (bulletAmount % 2.0f == 0)
                    {//Even
                        spawnPos = 
                            ((spawnPosition + Vector2.right * (expendDistance / 2))  + Vector2.left * (expendDistance * bulletAmount / 2)) 
                            + Vector2.right * (expendDistance * i);
                    }
                    else
                    {//Odd
                        spawnPos = 
                            (spawnPosition + Vector2.left * (expendDistance * (bulletAmount / 2))) 
                            + Vector2.right * (expendDistance * i);
                    }
                    break;
                case ExpendDirection.Vertical:
                    if (bulletAmount % 2.0f == 0)
                    {//Even
                        spawnPos = 
                            ((spawnPosition + Vector2.up * (expendDistance / 2))  + Vector2.down * (expendDistance * bulletAmount / 2)) 
                            + Vector2.up * (expendDistance * i);
                    }
                    else
                    {//Odd
                        spawnPos = 
                            (spawnPosition + Vector2.down * (expendDistance * bulletAmount / 2)) 
                            + Vector2.up * (expendDistance * i);
                    }
                    break;
                case ExpendDirection.Right:
                    spawnPos = spawnPosition + Vector2.right * (expendDistance * i);
                    break;
                case ExpendDirection.Left:
                    spawnPos = spawnPosition + Vector2.left * (expendDistance * i);
                    break;
                case ExpendDirection.Up:
                    spawnPos = spawnPosition + Vector2.up * (expendDistance * i);
                    break;
                case ExpendDirection.Down:
                    spawnPos = spawnPosition + Vector2.down * (expendDistance * i);
                    break;
            }
            bulletPos.Add(spawnPos);
        }

        return bulletPos;
    }
}
