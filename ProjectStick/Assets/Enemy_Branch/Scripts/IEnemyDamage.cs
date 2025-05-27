using UnityEngine;

public interface IEnemyDamage
{
    /// <summary>
    /// mainAgentPos는 공격 주체의 위치 공격 주체가 투사체라면 투사체 위치 플레이어라면 플레이어 위치 없을 시 null로 쓰세요
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="mainAgentPos"></param>
    /// <param name="knockBackForce"></param>
    /// <param name="stunTime"></param>
    public void Damage(float damage, Vector2 mainAgentPos, Vector2 knockBackForce = new Vector2(), float stunTime = 0.5f);
    public void Death();
}
