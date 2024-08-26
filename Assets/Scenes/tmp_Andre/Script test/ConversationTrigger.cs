using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public GameObject npcCharacter; // Variabel untuk menyimpan karakter NPC
    public string[] conversationLines; // Array string untuk dialog percakapan
    private bool inRange; // Status untuk mengetahui apakah pemain berada di dalam trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Saat pemain masuk ke dalam trigger
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Saat pemain keluar dari trigger
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E)) // Jika pemain dalam jarak trigger dan menekan tombol E (contoh)
        {
            StartConversation(); // Panggil fungsi untuk memulai percakapan
        }
    }

    private void StartConversation()
    {
        // Menampilkan percakapan dengan NPC
        if (npcCharacter != null)
        {
            // Misalnya, menampilkan dialog pada console untuk keperluan contoh
            foreach (string line in conversationLines)
            {
                Debug.Log(line);
            }
        }
    }
}
