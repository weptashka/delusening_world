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
    [Space]
    //[SerializeField] private LifeHandler _lifeHandler;

    private EnemyBehaviourController _enemyBehaviourController;
    private EnemyAttakHandler _enemyAttakHandler;
    

    //public LifeHandler LifeHandler => _lifeHandler
    public EnemyAttakHandler EnemyAttakHandler => _enemyAttakHandler;
    public float Speed => _speed;
    public Rigidbody Rigidbode => _rb;
    

    private void Awake()
    {
        _enemyAttakHandler = new EnemyAttakHandler(_attackDelay, _damage);

        CreateEnemyBehaviourController();
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
