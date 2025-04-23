using System;
using System.Collections;
using UnityEngine;

public static class WaitAction
{
    //
    // ���:
    //      1��° ���ڴ� ��� �ð�, 2��° ���ڴ� 1�� ����(���� : ��)��ŭ ��� �� ������ ���ٽ�
    public static IEnumerator wait(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    //
    // ���:
    //      1��° ���ڴ� bool�� return�ϴ� ���ٽ�, 2��° ���ڴ� 1�� ������ ������ ������ �� ������ ���ٽ�
    public static IEnumerator wait(Func<bool> condition, Action action)
    {
        yield return new WaitUntil(condition);
        action();
    }

    //
    // ���:
    //      1��° ���ڴ� ��� �ð�(���� �ð�), 2��° ���ڴ� 1�� ����(���� : ��)��ŭ ��� �� ������ ���ٽ�
    public static IEnumerator waitRealTime(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
