using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager PM
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public float MaxHP { get; private set; }
    public float HP;
    public float attackPoint;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHP(float HP, float MaxHP)
    {
        this.HP = HP;
        this.MaxHP = MaxHP;
    }
}
