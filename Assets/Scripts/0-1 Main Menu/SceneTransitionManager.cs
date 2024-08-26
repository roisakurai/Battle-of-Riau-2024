using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad; // Nama scene yang akan dipindahkan

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
