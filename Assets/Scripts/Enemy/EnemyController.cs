using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] private PlayerTrigger _chaseTrigger;
    [SerializeField] private PlayerTrigger _attackTrigger;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _chaseRadius;
    [Header("Movement")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [Header("Attack")]
    [SerializeField] private float _attackDelay;
    [SerializeField] private int _damage;
    [Header("Chase")]
    [SerializeField] private LayerMask _layerMask;

    private EnemyBehaviourController _enemyBehaviourController;
    private RigidbodyMîvement _rigidbodyMovement;

    public RigidbodyMîvement RigidbodyMovement => _rigidbodyMovement;

    private void Awake()
    {
        _rigidbodyMovement = new RigidbodyMîvement(_rb, _speed);
    }


    private void Update()
    {
        _enemyBehaviourController.Tick();
    }

    private void CreateEnemyBehaviourController()
    {

        _enemyBehaviourController = new EnemyBehaviourController(_chaseTrigger, _attackTrigger, this);
        _enemyBehaviourController.SwitchBehaviour<InactionBehaviour>();
    }


}
