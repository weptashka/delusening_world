using UnityEngine;


public class EnemyAttakHandler
{
    private readonly float _attackDelay = 5;
    private float _lastAttackTime;

    private readonly int _damage;

    public EnemyAttakHandler(float attackDelay, int damage)
    {
        _attackDelay = attackDelay;
        _damage = damage;
    }

    public void Attack()
    {
        if (Time.time - _lastAttackTime > _attackDelay)
        {
            PlayerStorageData.SetPickableCount(PickableType.HP, -_damage);

            Debug.Log("ATTACK");

            _lastAttackTime = Time.time;
        }
    }
}

