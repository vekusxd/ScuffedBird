using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MovingPlatformState movingPlatformState;
    [SerializeField] public float JumpPower = 2.0f;
    [SerializeField] public float AngleChangePower = 10.0f;
    [SerializeField] public float linearVelocityThreshHold = 0.0f;


    private bool isColided = false;
    private bool acceptControl = true;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource m_audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        movingPlatformState.ShouldMove = true;
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsJumping", acceptControl);
        if (isColided) return;

        if (acceptControl && (Mouse.current.leftButton.isPressed || Keyboard.current.spaceKey.isPressed))
        {
            rb.linearVelocity = Vector2.up * JumpPower;
            animator.SetTrigger("ShouldFlap");
            m_audioSource.Play();
        }

        float angle;

        if (rb.linearVelocityY > linearVelocityThreshHold)
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
        acceptControl = false;
        if (collision.gameObject.CompareTag("Floor"))
        {
            isColided = true;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (collision.gameObject.CompareTag("Pipe"))
        {
            //Debug.Log("Pipe hit");
            //gameObject.layer = LayerMask.NameToLayer("IgnorePipes");
        }
    }

}
