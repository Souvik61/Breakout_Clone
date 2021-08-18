using UnityEngine;
using UnityEngine.Tilemaps;

public class SoundManagerScript : MonoBehaviour
{ 

    public AudioClip brickHitSound;
    public AudioClip brickOutSound;
    public AudioClip gameOverSound;

    private AllEventsScript eventsScript;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        AllEventsScript.OnCollisionWTile += PlaySound_HitW;
    }

    private void OnDisable()
    {
       AllEventsScript.OnCollisionWTile -= PlaySound_HitW;
    }

    private void PlaySound_HitW(TileBase t)
    {
        PlaySound_Hit();
    }

    public void PlaySound_Out()
    {
        audioSource.PlayOneShot(brickOutSound, 1.0f);
    }

    public void PlaySound_Hit()
    {
        audioSource.PlayOneShot(brickHitSound, 1.0f);
    }

    public void PlaySound_Over()
    {
        audioSource.PlayOneShot(gameOverSound, 1.0f);
    }

}
