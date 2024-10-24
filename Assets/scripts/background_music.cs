using UnityEngine;

public class background_music : MonoBehaviour
{
    private AudioSource audioSource;

    private static background_music instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.parent.gameObject); // Parent GameObject is not destroyed
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(); // Start playing the background music
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
