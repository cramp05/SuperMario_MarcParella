using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip gameMusic;

    private AudioSource _audioSource;
    
    void Awake()
    {
       _audioSource = GetComponent<AudioSource>();
      StartBGM();
    }
 
    void Start()
    {
        StartBGM(); //llamamos a la funcion
    }


    void Update()
    {
        
    }

    void StartBGM()
    {
        _audioSource.clip = gameMusic;
        _audioSource.Play();

        //_audioSource.Stop();
        //_audioSource.Pause();
    }
}
