using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerButton : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject image;
    public HandUIController handUIController;
    public string sceneExit;

    void Start()
    {
        image.SetActive(true);
        image.GetComponent<Animator>().SetBool("fadeout", true);
    }

    private IEnumerator LoadSceneWithFade(int sceneIndex)
    {
        handUIController.sceneLoadInProgress = true;

        image.GetComponent<Animator>().SetBool("fadein", true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        handUIController.sceneLoadInProgress = true;

        image.GetComponent<Animator>().SetBool("fadein", true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    public void NextGame()
    {
        if (!handUIController.sceneLoadInProgress)
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void RestartGame()
    {
        if (!handUIController.sceneLoadInProgress)
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(SceneManager.GetActiveScene().name));
        }
    }

    public void ExitGame()
    {
        if (!handUIController.sceneLoadInProgress)
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(sceneExit));
        }
    }
}
