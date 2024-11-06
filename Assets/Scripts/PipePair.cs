using UnityEngine;

public class PipePair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float PipeMoveSpeed = 2.0f;
    public MovingPlatformState movingPlatformState;
    private AudioSource m_audioSource;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingPlatformState.ShouldMove)
            transform.position += PipeMoveSpeed * Time.deltaTime * Vector3.left;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_audioSource.Play();
        }
    }
}
