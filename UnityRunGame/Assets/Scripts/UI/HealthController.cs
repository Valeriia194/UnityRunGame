using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class HealthController : MonoBehaviour
    {
        public int MaxHealth { get; private set; }
        public int Currenthealth { get; private set; }

        public event Action OnDead;
        public event Action <DamageChanges> OnDamage;
        public event Action<HealthChanges> OnHeal;

    public void Init(int health)
        {
            MaxHealth = health;
            Currenthealth = health;
        }

        public void Damage(int damage)
        {
            Currenthealth -= damage;
            OnDamage?.Invoke(new DamageChanges(damage, Currenthealth+damage, Currenthealth));
            if (damage < 0)
                OnDead?.Invoke();
        }

    //public void Heal(int amount)
    //{
    //    Currenthealth += amount;
    //    if (Currenthealth > MaxHealth)
    //    {
    //        Currenthealth = MaxHealth;
    //    }
    //}

    public void Heal(int amount)
    {
        int previousHealth = Currenthealth;
        Currenthealth += amount;
        if (Currenthealth > MaxHealth)
        {
            Currenthealth = MaxHealth;
        }
        OnHeal?.Invoke(new HealthChanges(amount, previousHealth, Currenthealth));
    }
}


public struct DamageChanges
    {
        public int Damage;
        public int PrevHealth;
        public int CurrentHealth;

        public DamageChanges (int damge, int prevHealth, int currentHealth) {

            Damage = damge;
            PrevHealth = prevHealth;
            CurrentHealth = currentHealth;
            }
    }

public class HealthChanges
{
    public int Amount { get; }
    public int PreviousHealth { get; }
    public int CurrentHealth { get; }

    public HealthChanges(int amount, int previousHealth, int currentHealth)
    {
        Amount = amount;
        PreviousHealth = previousHealth;
        CurrentHealth = currentHealth;
    }
}