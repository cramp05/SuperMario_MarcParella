using UnityEngine;

public class Monedas : MonoBehaviour



{
    private GameManger _gameManager;

    public AudioClip coin;
    private AudioSource _audioSource;

    public SpriteRenderer renderSprite;

    void Awake()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManger>();
        _audioSource = GetComponent<AudioSource>();
        renderSprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

       if(collision.gameObject.CompareTag("Player"))  //destruccion de monedas y activar el contador de moneda
       {
            renderSprite.enabled = false;
            _gameManager.Coins();
            _audioSource.PlayOneShot(coin);
            Destroy(gameObject, 1.2f);
       }
    }
}
