using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    protected bool IsRbExist = false;

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        IsRbExist = rb != null;
    }
    
    public abstract void MoveByDir(Vector2 dir);
}
