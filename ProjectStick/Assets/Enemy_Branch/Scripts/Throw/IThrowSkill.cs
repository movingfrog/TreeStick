using UnityEngine;

/// <summary>
/// 던지기 태그의 스킬을 사용하기 위한 인터페이스 하나의 오브젝트에 해당 인터페이스가 2개 이상이라면 FindObjectsOfType함수로 배열로 받기! (구분은 is 문법으로)
/// </summary>
public interface IThrowSkill
{
    /// <summary>
    /// 사용 방법 : TryGetComponent로 받아서 Attack의 인수를 타겟으로 삼을 적의 Transform으로 넘겨준다. 없을 시 비워두기!
    /// </summary>
    /// <param name="target"></param>
    public void Attack(Transform target = null);
}
