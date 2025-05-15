using UnityEngine;

public interface IEnemyDamage
{
    /// <summary>
    /// mainAgentPos�� ���� ��ü�� ��ġ ���� ��ü�� ����ü��� ����ü ��ġ �÷��̾��� �÷��̾� ��ġ ���� �� null�� ������
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="mainAgentPos"></param>
    /// <param name="knockBackForce"></param>
    /// <param name="stunTime"></param>
    public void Damage(float damage, Vector2 mainAgentPos, Vector2 knockBackForce = new Vector2(), float stunTime = 0.5f);
    public void Death();
}
