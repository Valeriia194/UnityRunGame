using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Project;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private HealthController health;

        private float originalSpeed;

        private void Start()
        {
            var stats = ProjectContext.Instance.DataService.PlayerStats;
            playerMovement.Init(stats.MovementSpeed);
            health.Init(stats.MaxHealth);

            originalSpeed = stats.MovementSpeed;

        }

        public IEnumerator BoostSpeed(float amount, float duration)
        {
            var stats = ProjectContext.Instance.DataService.PlayerStats;
            stats.MovementSpeed += amount;
            playerMovement.Init(stats.MovementSpeed); 
            yield return new WaitForSeconds(duration);
            stats.MovementSpeed = originalSpeed;
            playerMovement.Init(stats.MovementSpeed);
        }
    }
}
