using UnityEngine;

public class ShortAttack : AIEnemy
{
    public Vector2 attackRange;
    public float damage;

    protected override void Attack()
    {
        Collider2D hit = Physics2D.OverlapBox(new Vector2(transform.position.x + (attackRange.x / 2f * Direction), transform.position.y), attackRange, 0, player);

        if (hit != null)
        {
            hit.TryGetComponent<IDamageAble>(out IDamageAble player);
            player.GetDamage(damage);
        }
    }

    private void Update()
    {
        direction = DistanceEach.normalized;
    }

    protected override void Jump() { }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawCube(new Vector2(transform.position.x + (attackRange.x / 2f * Direction), transform.position.y), attackRange);
    }
}
