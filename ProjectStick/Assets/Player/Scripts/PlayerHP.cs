using UnityEditor;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageAble
{
    public float HP { get; set; }
    [SerializeField] float MaxHP;

    private void Awake()
    {
        HP = MaxHP;
    }

    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            isDie();
        }
    }

    public void isDie()
    {
        //아직 제작 안됨
        EditorApplication.isPlaying = false;
    }
}
