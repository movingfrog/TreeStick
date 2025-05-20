using System;
using UnityEngine;

//플레이어 능력 관련 관리 매니저
public class PlayerAblilty : MonoBehaviour
{
    private static PlayerAblilty AbliltyManager;
    public static PlayerAblilty AM
    {
        get
        {
            if(AbliltyManager == null)
            {
                return null;
            }
            return AbliltyManager;
        }
    }

    public AbliltyItem abliltyItem;
    [Serializable]
    public struct Ablilty
    {
        //단계 설정
        public bool[] abliltyTech;
        //능력 레벨(단계에 따른 레벨)
        public int ablityLevel;
        //능력의 스킬 레벨
        public int[] SkillLevel;
    }
    public Ablilty[] Ablilties;

    private void Awake()
    {
        if(AbliltyManager == null)
        {
            AbliltyManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 테크 정하면 사용할 것
    // 테크가 정해져서 다른 테크를 건들지 말게 하는것은 ui에서 처리
    public void Tech(int item, int tech)
    {
        Ablilties[item].abliltyTech[tech] = true;
    }
}