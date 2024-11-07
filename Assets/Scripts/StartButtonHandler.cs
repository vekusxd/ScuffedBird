using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{
    public async void StartClicked()
    {
        await SceneManager.LoadSceneAsync("Game");
    }
}
