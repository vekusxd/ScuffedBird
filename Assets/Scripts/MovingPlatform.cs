using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float speed = 2.0f;
    [SerializeField] public float startX = 0f;
    [SerializeField] public float restartX = -6.0f;
    public GameState gameState;

    // Update is called once per frame
    private void Update()
    {
        if (!gameState.GameOver)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x < restartX)
            {
                transform.position = new Vector3(startX, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        }
    }
}
