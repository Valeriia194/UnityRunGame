using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript: MonoBehaviour
{
    public Text winText; 
    private bool hasWon = false;

    void Start()
    {
        winText.text = ""; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win") && !hasWon)
        {
            other.gameObject.SetActive(false); 
            winText.text = "You Win!";
            hasWon = true;
            Invoke("RestartLevel", 2f); 
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
