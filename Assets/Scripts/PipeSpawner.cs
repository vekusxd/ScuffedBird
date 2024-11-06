using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject pipe;
    public MovingPlatformState movingPlatformState;
    public float TimeInterval = 1.0f;
    public float startXPosition = 3.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0.0f, TimeInterval);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!movingPlatformState.ShouldMove)
            CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(startXPosition, Random.Range(1.9f, 3.4f), 0.0f), Quaternion.identity);
    }
}
