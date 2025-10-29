
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1f;
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic();
        }
        else
        {
            Debug.LogWarning("MenuManager.Start: AudioManager.Instance is null, cannot play music yet!");
        }
    }

    public void NewGameFunction()
    {
         if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopMusic();
        }
        SceneManager.LoadScene("SpaceshipExplore");
    }
    
    public void ExitGameFunction()
    {
        Application.Quit();
    }

}
