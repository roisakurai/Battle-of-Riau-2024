using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDestroy : MonoBehaviour
{
    public int requiredDestroyedCount = 1;
    public GameObject image;

    private int destroyedObjectCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character_Kapten_Belanda" ||
            other.gameObject.name == "Character_Bawahan_Belanda 2" ||
            other.gameObject.name == "Character_Bawahan_Belanda 5")
        {
            Destroy(other.transform.parent.gameObject);
            destroyedObjectCount++;
        }

        if (other.gameObject.name == "1 Small ship" ||
            other.gameObject.name == "2 Medium ship" ||
            other.gameObject.name == "3 Warship")
        {
            Destroy(other.transform.parent.parent.gameObject);
            destroyedObjectCount++;
        }

        StartCoroutine(CheckAndActivateObject());
    }

    private IEnumerator CheckAndActivateObject()
    {
        yield return null;

        if (destroyedObjectCount >= requiredDestroyedCount)
        {
            image.GetComponent<Animator>().SetBool("fadein", true);
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
