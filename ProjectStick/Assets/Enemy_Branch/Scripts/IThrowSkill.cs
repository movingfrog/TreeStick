using UnityEngine;

/// <summary>
/// ������ �±��� ��ų�� ����ϱ� ���� �������̽� �ϳ��� ������Ʈ�� �ش� �������̽��� 2�� �̻��̶�� FindObjectsOfType�Լ��� �迭�� �ޱ�! (������ is ��������)
/// </summary>
public interface IThrowSkill
{
    /// <summary>
    /// ��� ��� : TryGetComponent�� �޾Ƽ� Attack�� �μ��� Ÿ������ ���� ���� Transform���� �Ѱ��ش�. ���� �� ����α�!
    /// </summary>
    /// <param name="target"></param>
    public void Attack(Transform target = null);
}
