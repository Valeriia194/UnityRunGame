using System;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float fireDistance = 5;
    [SerializeField] private float chaseDistance = 10;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Transform target;
    private Vector3 spawnPoint;
    private EnemyState currentState;

    private void Start()
    {
        spawnPoint = transform.position;
        if (target == null)
            target = GameObject.FindWithTag($"Player")?.transform;
    }

    private void Update()
    {
        if (target == null)
            return;
        Vector3 direction = target.position - transform.position;

        switch (currentState)
        {
            case EnemyState.Patrol:
                navMeshAgent.destination = spawnPoint;

                if (direction.magnitude < chaseDistance)
                    currentState = EnemyState.Chase;
                if (direction.magnitude < fireDistance)
                    currentState = EnemyState.Attack;
                break;
            case EnemyState.Chase:
                navMeshAgent.destination = target.position;

                if (direction.magnitude > chaseDistance)
                    currentState = EnemyState.Patrol;
                if (direction.magnitude < fireDistance)
                    currentState = EnemyState.Attack;
                break;
            case EnemyState.Attack:
                navMeshAgent.destination = transform.position;
                //weaponController?.FireProjectile();

                if (direction.magnitude > chaseDistance)
                    currentState = EnemyState.Patrol;
                if (direction.magnitude > fireDistance)
                    currentState = EnemyState.Chase;
                break;
        }

    }

    private void OnDrawGizmos()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, direction);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }

    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }
}





