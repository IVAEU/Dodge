using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private float _speed;
    
    public override void Init(float spd)
    {
        base.Init(spd);
        RefreshInfo(spd);
        PlayerController.Instance.speed.OnChanged += RefreshInfo;
    }

    public override void MoveByDir(Vector2 dir)
    {
        if(!IsRbExist) return;

        rb.velocity = dir * _speed;
    }
    
    private void RefreshInfo(float newSpeed)
    {
        _speed = newSpeed;
    }
}
