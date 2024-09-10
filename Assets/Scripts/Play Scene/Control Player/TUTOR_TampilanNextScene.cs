using UnityEngine;

public class TUTOR_TampilanNextScene : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Finish;

    void Update()
    {
        ShowNextScene();
    }

    void ShowNextScene()
    {
        if ((Enemy1 == null || !Enemy1.activeSelf) &&
            (Enemy2 == null || !Enemy2.activeSelf) &&
            (Enemy3 == null || !Enemy3.activeSelf))
        {
            Finish.SetActive(true);
        }
    }
}
