using UnityEngine;

public class PlayAudioOnGrab : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(){
        audioSource.Play();
    }
}
