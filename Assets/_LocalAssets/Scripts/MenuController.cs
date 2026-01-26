using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public SoundManager sm;

    public void StartAction()
    {
        sm.PlayPlayButtonSound();
        SceneManager.LoadScene("TestParkScene");
    }
    public void ExitAction()
    {
        sm.PlayExitButtonSound();
        Application.Quit();
    }
}
