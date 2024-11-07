using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameState gameState;
    [SerializeField] public float JumpPower = 2.0f;
    [SerializeField] public float AngleChangePower = 10.0f;
    [SerializeField] FlashImage m_flashImage = null;

    private bool isColided = false;
    private bool acceptControl = true;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource m_audioSource;

    public AudioSource hitSound;
    public AudioSource dieSound;
    public GameObject restartButton;

    private bool hitPlayed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        gameState.GameOver = false;
        gameState.Score = 0;
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

        if (rb.linearVelocityY > 0)
        {
            angle = Mathf.LerpAngle(20, 60, rb.linearVelocityY / AngleChangePower);
        }
        else
        {
            angle = Mathf.LerpAngle(0, -90, -rb.linearVelocityY / AngleChangePower);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("Floor"))
        {
            
            isColided = true;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
            gameState.GameOver = true;
            acceptControl = false;
            gameState.GameOver = true;

            if (!hitPlayed)
            {
                m_flashImage.StartFlash(0.3f, 0.5f,Color.black);
                ShowButton();
                hitPlayed = true;
                hitSound.Play();
            }
        }

        if (collision.gameObject.CompareTag("Pipe"))
        {
            acceptControl = false;
            gameState.GameOver = true;
            gameState.GameOver = true;
            gameObject.layer = LayerMask.NameToLayer("IgnorePipes");
            dieSound.Play();
            if (!hitPlayed)
            {
                m_flashImage.StartFlash(0.3f, 0.5f, Color.black);
                ShowButton();
                hitPlayed = true;
                hitSound.Play();
            }
        }
    }

    private void ShowButton()
    {
        restartButton.SetActive(true);
    }
}
