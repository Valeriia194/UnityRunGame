using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text gameOverText; 
    public float timeLeft = 30f;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false); 
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
            yield return null;
        }

        ShowGameOverMessage();
    }

    private void ShowGameOverMessage()
    {
        gameOverText.gameObject.SetActive(true); 
        gameOverText.text = "Game Over"; 

        StartCoroutine(ReloadAfterDelay());
    }

    private IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(3); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
