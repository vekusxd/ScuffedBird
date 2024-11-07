using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonHandler : MonoBehaviour
{
    public async void OnClicked()
    {
        await SceneManager.LoadSceneAsync("MainMenu");
    }
}
