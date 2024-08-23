using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        if (target == null)
            target = GameObject.FindWithTag($"Player")?.transform;
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = target.position - transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, direction);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }
}
