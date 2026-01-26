using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip PlayButtonSound;
    public AudioClip ExitButtonSound;
    public AudioClip CoinSound;
    private AudioSource audioMenu;
    int r = 1;

    void Awake()
    {
        audioMenu = GetComponent<AudioSource>();
    }

    public void PlayPlayButtonSound()
    {
        StartCoroutine(WaitSoundPlay());
    }

    public void PlayExitButtonSound()
    {
        StartCoroutine(WaitSoundExit());
    }

    public void PlayCoinSound()
    {
        StartCoroutine(WaitSoundCoin());
    }

    IEnumerator WaitSoundPlay()
    {
        audioMenu.PlayOneShot(PlayButtonSound);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(r);
    }

    IEnumerator WaitSoundExit()
    {
        audioMenu.PlayOneShot(ExitButtonSound);
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    IEnumerator WaitSoundCoin()
    {
        audioMenu.PlayOneShot(CoinSound);
        yield return new WaitForSeconds(1f);
    }
}
