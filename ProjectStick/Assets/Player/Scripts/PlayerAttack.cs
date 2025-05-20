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
            //PlayerAblilty.AM.TOA = abliltyItem.GetComponent<AbliltyItem>().abliltyType;
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
