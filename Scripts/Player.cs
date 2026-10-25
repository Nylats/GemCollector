using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 6f;        // velocidad máxima
    [SerializeField] private float smoothTime = 0.1f; // suavizado (más alto = más "deslizamiento")

    private Rigidbody rb;
    private Vector3 input;
    private Vector3 smoothedVelocity;
    private Vector3 velocityRef;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        input = new Vector3(h, 0f, v).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = input * speed;

        smoothedVelocity = Vector3.SmoothDamp(smoothedVelocity, targetVelocity, ref velocityRef, smoothTime);

        rb.MovePosition(rb.position + smoothedVelocity * Time.fixedDeltaTime);
    }
}