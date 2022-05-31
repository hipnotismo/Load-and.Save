using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField] private float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement.z = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        rb.MovePosition(rb.position + movement*(speed*Time.fixedDeltaTime));
    }
}
