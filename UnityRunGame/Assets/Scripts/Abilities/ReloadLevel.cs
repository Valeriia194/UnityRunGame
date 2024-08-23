using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ReloadLevel : MonoBehaviour
{
    public TMP_Text levelCompleteText;

    private void Start()
    {
        levelCompleteText.gameObject.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ReloadAfterDelay());
        }
    }

    private IEnumerator ReloadAfterDelay()
    {
        levelCompleteText.gameObject.SetActive(true); 
        levelCompleteText.text = "Level Complete";

        yield return new WaitForSeconds(3); 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
