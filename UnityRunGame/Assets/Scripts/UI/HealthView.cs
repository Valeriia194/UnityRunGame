using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;

        [SerializeField] private Image fillImage;

        private void Start()
        {
            healthController.OnDamage += OnDamage;
            healthController.OnHeal += OnHeal;
        }

        private void OnDamage(DamageChanges obj)
        {
            fillImage.fillAmount = (float)obj.CurrentHealth / (float) healthController.MaxHealth;
        }

        private void OnHeal(HealthChanges obj)
        {
            fillImage.fillAmount = (float)obj.CurrentHealth / (float)healthController.MaxHealth;
        }
    }
}
