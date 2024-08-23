using Assets.Scripts.Audio;
using Assets.Scripts.Project;
using System.Collections;
using UnityEngine;

public class CloseWeaponController : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private LayerMask castMask;
    [SerializeField] private float fireDelay = 1f;
    private ObjectPool projectilePool;
    private const float rayDistance = 10f;
    private bool IsCoolingDown;
    private IAudioService audioService;

    private void Awake()
    {
        audioService = ProjectContext.Instance.AudioService;
        projectilePool = new ObjectPool(projectilePrefab.gameObject);
    }

    public void FireProjectile()
    {
        if (IsCoolingDown)
            return;
        Vector3 spawnPosition = transform.position + transform.forward;
        var projectile = projectilePool.Get();

        projectile.GetComponent<Projectile>().Init(projectilePool);
        projectile.transform.position = spawnPosition;
        projectile.transform.rotation = transform.rotation;
        projectile.SetActive(true);
        StartCoroutine(Delay());
    }

    public void FireRaycast()
    {
        if (IsCoolingDown)
            return;
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, castMask))
        {
            Debug.Log(hitInfo.collider.name);

            if (hitInfo.collider.CompareTag("Player"))
            {
                HealthController playerHealth = hitInfo.collider.GetComponent<HealthController>();
                if (playerHealth != null)
                {
                    int damageAmount = 10;
                    playerHealth.Damage(damageAmount);
                }

                Destroy(gameObject);
            }
        }
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        IsCoolingDown = true;
        yield return new WaitForSeconds(fireDelay);
        IsCoolingDown = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + transform.forward, transform.forward * rayDistance);
    }
}
