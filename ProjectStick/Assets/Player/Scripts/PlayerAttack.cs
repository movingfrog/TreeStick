using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject abliltyItem;

    public float attackDelay;
    public float attackSec;

    public Vector2 distance;
    public Vector2 attackSize;

    public void OnAttack()
    {
        if(attackSec >= attackDelay && Input.anyKeyDown)
        {
            Collider2D[] enemy = Physics2D.OverlapBoxAll(transform.position + new Vector3(distance.x * transform.localScale.x, distance.y), attackSize, 0);
            foreach(var collider in enemy)
            {
                if (collider.CompareTag("Enemy"))
                {
                    IEnemyDamage Attack = collider.GetComponent<IEnemyDamage>();
                    //Attack.Damage();
                    Debug.Log("attack");
                    continue;
                }
                attackSec = 0;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AbliltyItem"))
        {
            abliltyItem = collision.gameObject;
        }
    }

    public void OnGetItem()
    {
        if (Input.anyKeyDown && abliltyItem != null)
        {
            PlayerAblilty.AM.abliltyItem = abliltyItem.GetComponent<AbliltyItem>(); //플레이어가 아이템을 획득시 아이템의 종류를 저장
            // 아이템의 부모를 플레이어로 저장 및 비공개 상태로 전환(이후에 다른 아이템을 얻을 때 아이템이 빠지는 기능을 위함)
            abliltyItem.transform.SetParent(transform);
            abliltyItem.SetActive(false);
        }
    }
    private void Update()
    {
        if(attackSec < attackDelay)
        {
            attackSec += Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + new Vector3(distance.x * transform.localScale.x, distance.y), attackSize);
    }
}
