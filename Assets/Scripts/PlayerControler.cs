using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5;
    public int direction = 1;
    public InputAction moveAction;
    public Vector2 moveDirection;

    public Rigidbody2D rBody2D;
    public float jumpForce = 10;



    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        transform.position = startPosition;

        moveAction = InputSystem.actions["Move"];

        rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();

        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.position = vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed + Time.deltaTime);

        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));
        transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);



    }
}
