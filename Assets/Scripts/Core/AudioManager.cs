using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {

        source = GetComponent<AudioSource>();

        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}