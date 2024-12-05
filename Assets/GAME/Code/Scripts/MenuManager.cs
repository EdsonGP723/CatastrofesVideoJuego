using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncScene(sceneName));
    }

    public IEnumerator AsyncScene(string sceneName)
    {
        Debug.Log("Happens");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
