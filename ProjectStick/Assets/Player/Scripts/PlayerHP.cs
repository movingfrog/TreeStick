using UnityEditor;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageAble, IHP
{
    public float HP { get; set; }

    private void Awake()
    {
        HP = PlayerManager.PM.MaxHP;
    }

    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            isDie();
        }
    }

    public void HealHP(float H)
    {

    }

    public void MaxHPUP(float H)
    {

    }

    public void isDie()
    {
        //아직 제작 안됨
        EditorApplication.isPlaying = false;
    }
}
