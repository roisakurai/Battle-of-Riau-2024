using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {
        // Menunggu selama 1 detik sebelum berpindah scene
        Invoke("SwitchScene", 1f);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("1-2 Play Scene");
    }
}
