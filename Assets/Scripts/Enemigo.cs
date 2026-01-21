using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float movementSpeed = 4;
    public int direction = 1;
    public Rigidbody2D rBody2D;
    private Animator _animator;

    private SpriteRenderer renderer;

    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;

    public AudioClip deathSFX;

    private GameManger _gameManager;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        rBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManger>();
        
    }
    void Start()
    {
      

    }

    void Update()
    {
     
         
    }
     void FixedUpdate()
    {
      rBody2D.linearVelocity = new Vector2(direction * movementSpeed, rBody2D.linearVelocity.y);  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (!collision.gameObject.CompareTag("Suelo Para Enemigos"))
        {
          direction *= -1;
        }
       if(collision.gameObject.CompareTag("Player")) 
       {
         Destroy(collision.gameObject);
       }
    }

    public void GoombaDeath()
    {
        _animator.SetBool("Goomba death", true);

        _audioSource.PlayOneShot(deathSFX);

        movementSpeed = 0;

        _boxCollider.enabled = false; //desactiva el box collider

        Destroy(gameObject, 1.2f);


      _gameManager.AddKill();



       



        //_audioSource.Play();
        //_audioSource.clip = (deathSFX);
    }

}
