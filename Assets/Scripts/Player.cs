using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MovingPlatformState movingPlatformState;
    [SerializeField] public float JumpPower = 2.0f;
    [SerializeField] public float AngleChangePower = 10.0f;


    private bool isColided = false;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        movingPlatformState.ShouldMove = true;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        animator.SetBool("IsJumping", !isColided);
        if (isColided) return;

        var keyboard = Keyboard.current;
        var mouse = Mouse.current;

        if (Mouse.current.leftButton.isPressed || Keyboard.current.spaceKey.isPressed)
        {
            rb.linearVelocity = Vector2.up * JumpPower;
            animator.SetTrigger("ShouldFlap");
        }

        float angle;

        if (rb.linearVelocityY > 0)
        {
            angle = Mathf.Lerp(0, 35, rb.linearVelocityY / AngleChangePower);
        }
        else
        {
            angle = Mathf.Lerp(0, -90, -rb.linearVelocityY / AngleChangePower);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColided = true;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
