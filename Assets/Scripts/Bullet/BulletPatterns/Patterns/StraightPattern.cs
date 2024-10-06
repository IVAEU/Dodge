using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Straight")]
public class StraightPattern : BulletPattern
{
    enum ShootDir
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
    [SerializeField] private ShootDir shootDir;
    [SerializeField] private ExpendDirection expendDir;
    [SerializeField] private float expendDistance;
    [SerializeField] private int bulletAmount = 1;

    public override bool IsTrackingPlayer()
    {
        return false;
    }

    public override Vector2 ShootDirection()
    {
        switch (shootDir)
        {
            case ShootDir.Right:
                return Vector2.right;
            case ShootDir.Left:
                return Vector2.left;
            case ShootDir.Up:
                return Vector2.up;
            case ShootDir.Down:
                return Vector2.down;
        }

        return Vector2.zero;
    }

    public override List<Vector2> GetPatternInfo()
    {
        List<Vector2> bulletPos = new List<Vector2>();
        for(int i = 0; i < bulletAmount; i++)
        {
            Vector2 spawnPos = Vector2.zero;
            
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
