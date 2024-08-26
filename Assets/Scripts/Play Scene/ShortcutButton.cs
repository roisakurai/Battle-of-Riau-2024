using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShortcutButton : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject image;
    public string sceneExit;

    private string activeSceneName;

    private void Start()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(SceneManager.GetActiveScene().buildIndex + 1));
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(SceneManager.GetActiveScene().buildIndex - 1));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(activeSceneName));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonSound.Play();
            StartCoroutine(LoadSceneWithFade(sceneExit));
        }
    }

    private IEnumerator LoadSceneWithFade(int sceneName)
    {
        image.GetComponent<Animator>().SetBool("fadein", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        image.GetComponent<Animator>().SetBool("fadein", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
