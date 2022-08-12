using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void OnClickPlay() 
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickExit() 
    {
        Application.Quit();
    }
}