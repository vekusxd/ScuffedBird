using TMPro;
using UnityEngine;

public class PipePair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float PipeMoveSpeed = 2.0f;
    public GameState gameState;
    public TMP_Text text;
    private AudioSource m_audioSource;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        text = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState.GameOver)
            transform.position += PipeMoveSpeed * Time.deltaTime * Vector3.left;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_audioSource.Play();
            ++gameState.Score;
            text.text = gameState.Score.ToString();
        }
    }
}
