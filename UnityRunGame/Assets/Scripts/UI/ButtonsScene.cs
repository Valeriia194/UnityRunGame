using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScene : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
