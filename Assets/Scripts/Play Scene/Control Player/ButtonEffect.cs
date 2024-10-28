using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    public GameObject button; // Tombol yang ingin dimunculkan
    public float delay = 3f; // Waktu delay sebelum muncul
    public float animationDuration = 0.5f; // Durasi animasi scaling
    public AudioClip appearSound; // Efek suara untuk tombol muncul
    private AudioSource audioSource;

    private void Start()
    {
        if (button != null)
        {
            button.SetActive(false); // Sembunyikan tombol saat mulai
            audioSource = gameObject.AddComponent<AudioSource>(); // Tambahkan AudioSource ke game object
            StartCoroutine(ShowButtonWithAnimationCoroutine());
        }
    }

    private IEnumerator ShowButtonWithAnimationCoroutine()
    {
        yield return new WaitForSeconds(delay); // Tunggu sesuai delay
        button.SetActive(true); // Aktifkan tombol

        // Mainkan efek suara jika tersedia
        if (appearSound != null)
        {
            audioSource.PlayOneShot(appearSound);
        }

        // Atur ukuran awal menjadi besar
        button.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        // Efek animasi dari besar ke kecil
        float elapsedTime = 0f;
        Vector3 startScale = button.transform.localScale;
        Vector3 endScale = new Vector3(0.1f, 0.1f, 0.1f);

        while (elapsedTime < animationDuration)
        {
            button.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Pastikan tombol berada pada ukuran akhir
        button.transform.localScale = endScale;
    }
}
