using System;
using System.Collections;
using UnityEngine;

public static class WaitAction
{
    //
    // 요약:
    //      1번째 인자는 대기 시간, 2번째 인자는 1번 인자(단위 : 초)만큼 대기 후 실행할 람다식
    public static IEnumerator wait(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    //
    // 요약:
    //      1번째 인자는 bool을 return하는 람다식, 2번째 인자는 1번 인자의 조건이 만족될 시 실행할 람다식
    public static IEnumerator wait(Func<bool> condition, Action action)
    {
        yield return new WaitUntil(condition);
        action();
    }

    //
    // 요약:
    //      1번째 인자는 대기 시간(실재 시간), 2번째 인자는 1번 인자(단위 : 초)만큼 대기 후 실행할 람다식
    public static IEnumerator waitRealTime(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
