using Assets.Scripts.UI;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 2.0f; 
    public float boostDuration = 5.0f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StartCoroutine(player.BoostSpeed(boostAmount, boostDuration));
                Destroy(gameObject); 
            }
        }
    }
}
