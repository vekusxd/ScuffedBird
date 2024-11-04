using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public MovingPlatformState movingPlatformState;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard == null)
        {
            Debug.Log("Keyboard not connetected :(");
            return;
        }

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            movingPlatformState.ShouldMove = !movingPlatformState.ShouldMove;
        }
    }
}
