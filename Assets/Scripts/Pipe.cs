using UnityEngine;

public class Pipe : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        //Destroy(gameObject);
        
    }
}
