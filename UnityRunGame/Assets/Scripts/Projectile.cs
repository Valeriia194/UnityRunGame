using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private ObjectPool pool;

    public void Init(ObjectPool pool)
    {
        this.pool = pool;
    }

    private void OnEnable()
    {
        StartCoroutine(DieAfterDelay());
    }

    private IEnumerator DieAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        pool.Put(gameObject);
    }

    private void Update()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}