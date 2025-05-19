using System;
using UnityEngine;

public enum TypeOfAblilty
{
    PO,
    SW,
    BO,
    TH,
    ST,
    TE,
    SP,
    HA,
}

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
    public TypeOfAblilty TOA = TypeOfAblilty.PO;
    [Serializable]
    public struct Ablilty
    {
        public bool[] abliltyTech;
        public int ablityLevel;
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
}