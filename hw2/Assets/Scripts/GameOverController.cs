using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	public GameObject gameOverText;

	// Start is called before the first frame update
	void Start()
	{
		gameOverText.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void EnableGameOver() {
		Time.timeScale = 0;
		gameOverText.SetActive(true);
	}

	public void BackToMenu() {
		SceneManager.LoadScene("Start");
		Time.timeScale = 1;
	}
}
