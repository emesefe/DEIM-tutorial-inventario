using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rigidbody2D;

    private float horizontalInput, verticalInput;
    private Vector2 inputVector;
    private float moveSpeed = 10f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        inputVector = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = inputVector * moveSpeed;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 newPosition)
    {   
        transform.position = newPosition;
    }
}
