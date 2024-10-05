using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    public abstract bool isTrackingPlayer { get; set; }
    public abstract Vector2 shootDirection { get; set; } //수정 가능성 
    public abstract List<Vector2> GetPatternInfo();
}


