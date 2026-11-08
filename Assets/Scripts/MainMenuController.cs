using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator fadeAnimator;

    public void Play()
    {
        StartCoroutine(PlayC());
    }

    public void Quit()
    {
        StartCoroutine(QuitC());
    }

    public IEnumerator PlayC()
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Game");
    }

    public IEnumerator QuitC()
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.2f);
        Application.Quit();
    }
}
