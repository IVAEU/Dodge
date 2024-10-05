using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private float _speed;
    
    public override void Init()
    {
        base.Init();
        RefreshInfo();
        PlayerController.Instance.OnSpeedChanged += RefreshInfo;
    }

    public override void MoveByDir(Vector2 dir)
    {
        if(!IsRbExist) return;

        rb.velocity = dir * _speed;
    }
    
    private void RefreshInfo()
    {
        _speed = PlayerController.Instance.Speed;
    }
}
