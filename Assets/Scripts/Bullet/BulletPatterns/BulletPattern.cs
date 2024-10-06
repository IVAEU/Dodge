using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    public abstract bool IsTrackingPlayer();
    public abstract Vector2 ShootDirection();
    public abstract List<Vector2> GetPatternInfo();
}


