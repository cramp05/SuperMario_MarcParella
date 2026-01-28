using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5;
    public int direction = 1;
    public InputAction moveAction;
    public Vector2 moveDirection;
    private InputAction jumpAction;

    public Rigidbody2D rBody2D;
    public float jumpForce = 10;

    private SpriteRenderer renderer;
    private BoxCollider2D _boxCollider;

    private GroundSensor sensor;

    private Animator animator;
    private AudioSource _audioSource;
    public AudioClip deathSFXMario;
    public AudioClip jumpMario;

    public float bounceforce = 5;





    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();

        sensor = GetComponentInChildren<GroundSensor>();

        moveAction = InputSystem.actions["Move"];

        jumpAction = InputSystem.actions["Jump"];

        animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();
     
    
    }



    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        transform.position = startPosition;

    }

    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();

        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.position = vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed + Time.deltaTime);

        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));

        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (moveDirection.x > 0)
        {
            renderer.flipX = false;
            animator.SetBool("IsRunning", true);
        }

        else if (moveDirection.x < 0)
        {
            renderer.flipX = true;
            animator.SetBool("IsRunning", true);
        }

        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (jumpAction.WasPressedThisFrame() && sensor.isGrouned)
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(jumpMario);
        }

        animator.SetBool("IsJumping", !sensor.isGrouned);
    }

    public void Mariodeath()
    {
        animator.SetBool("IsDeath", true);

        _audioSource.PlayOneShot(deathSFXMario);

        movementSpeed = 0;

        _boxCollider.enabled = false; //desactiva el box collider

        Destroy(gameObject, 1.2f);
    }

    public void Bounce()
    {
        rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("IsJumping", !sensor.isGrouned);
    }

   
    void FixedUpdate()
    {
      rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);  
    }

}