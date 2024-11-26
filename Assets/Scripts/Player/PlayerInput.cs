using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private BaseMovement _playerMovement;
    private bool _isMovementExist = false;
    private Vector2 _inputVec;

    public void Init()
    {
        _playerMovement = GetComponent<BaseMovement>();
        _isMovementExist = _playerMovement != null;
    }
    
    private void Update()
    {
        _inputVec.x = Input.GetAxisRaw("Horizontal");
        _inputVec.y = Input.GetAxisRaw("Vertical");

        if (!_isMovementExist) return;
        _playerMovement.MoveByDir(_inputVec.normalized);
    }
}
