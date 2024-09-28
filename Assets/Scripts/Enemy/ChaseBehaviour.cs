
using UnityEngine;


public class ChaseBehaviour : EnemyBehaviour
{
    private readonly EnemyBehaviourController _enemyBehaviourController;
    private readonly PlayerTrigger _chaseTrigger;
    private readonly PlayerTrigger _attackTrigger;
    private readonly EnemyController _enemyController;

    public ChaseBehaviour(EnemyBehaviourController enemyBehaviourController, PlayerTrigger chaseTrigger, PlayerTrigger attackTrigger, EnemyController enemyController) : base(enemyBehaviourController)
    {
        _enemyBehaviourController = enemyBehaviourController;
        _chaseTrigger = chaseTrigger;
        _attackTrigger = attackTrigger;
        _enemyController = enemyController;
    }


    public override void Tick()
    {
        if (_attackTrigger.IsTriggered)
        {
            _enemyBehaviourController.SwitchBehaviour<AttackBehaviour>();
            Debug.Log("ATTACK MODE");
        }
        else if (_chaseTrigger.IsTriggered)
        {
            Debug.Log("CHASE MODE");
            var playerPosition = _chaseTrigger.TriggeredValue.transform.position;

            Vector3 direction = new Vector3(-playerPosition.x + _enemyController.Rigidbode.position.x, 0, -playerPosition.z + _enemyController.Rigidbode.position.z);
            Debug.LogWarning(direction);
            _enemyController.Rigidbode.transform.Translate(direction * _enemyController.Speed * 0.1f * Time.deltaTime);
        }
        else
        {
            _enemyBehaviourController.SwitchBehaviour<InactionBehaviour>();
            Debug.Log("PATROLLING MODE");
        }
    }

    public override void Exit()
    {

    }
}
