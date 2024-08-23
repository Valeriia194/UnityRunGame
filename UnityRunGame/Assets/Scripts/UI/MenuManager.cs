using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("HWScene", LoadSceneMode.Single);
    }

    public void OnOptionsButtonClick()
    {

    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
