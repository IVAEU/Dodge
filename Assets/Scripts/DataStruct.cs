using System;

[Serializable]
public struct HealthInfo
{
    public float MaxHealth;
    public float CurHealth;

    public void HealHealth(float value)
    {
        CurHealth = CurHealth + value > MaxHealth ? MaxHealth : CurHealth + value;
    }

    public void DamageHealth(float value)
    {
        CurHealth = CurHealth - value < 0 ? 0 : CurHealth - value;
    }
}

[Serializable]
public struct MoveInfo
{
    public float Speed;
}