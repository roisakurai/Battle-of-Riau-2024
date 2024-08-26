using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameShortcut : MonoBehaviour
{
    void Update()
    {
        // Jika tombol "P" ditekan pada keyboard
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadScene("1-2 Play Scene"); // Ganti "NamaScene" dengan nama scene yang ingin Anda muat
        }
    }

    // Fungsi untuk memuat scene
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
