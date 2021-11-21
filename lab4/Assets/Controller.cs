using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    void Start()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
    }

    public void startGame() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
    }
}
