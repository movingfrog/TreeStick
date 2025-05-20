using System;
using UnityEngine;

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