using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float speed = 2.0f;
    [SerializeField] public float startX = 0f;
    [SerializeField] public float restartX = -6.0f;
    [SerializeField] public MovingPlatformState movingPlatformState;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (movingPlatformState.ShouldMove)
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
        movingPlatformState.ShouldMove = false;
    }
}
