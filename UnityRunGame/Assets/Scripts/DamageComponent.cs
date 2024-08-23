using UnityEngine;

namespace DefaultNamespace
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int damage;
        private void OnTriggerEnter(Collider other)
        {
            var health = other.GetComponent<HealthController>();
            if (health != null)
            {
                health.Damage(damage);
            }
        }
    }
}