using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public int numberOfPigs;
	public AudioClip endClip;

	void Start()
	{
	}

	void Update()
	{
	}

	public void LoadStartScene() {
		SceneManager.LoadScene("Start");
		Destroy(GameObject.Find("ScoreCanvas"));
	}

	public void StartStage1()
	{
		SceneManager.LoadScene("Stage1");
	}

	public void StartStage2()
	{
		SceneManager.LoadScene("Stage2");
	}

	public void RestartStage()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);

		GameObject.Find("ScoreCanvas").GetComponent<ScoreController>().Restart();
	}

	public void NextStage()
	{
		Scene scene = SceneManager.GetActiveScene();

		switch (scene.name)
		{
			case "Stage1":
				StartStage2();
				break;
			case "Stage2":
				loadEndScene();
				break;
		}

		GameObject.Find("ScoreCanvas").GetComponent<ScoreController>().NextStage();
	}

	private void loadEndScene() {
		SceneManager.LoadScene("End");
		GameObject.Find("ScoreCanvas").GetComponent<Canvas>().enabled = false;
		GameObject.Find("ScoreCanvas").GetComponent<AudioSource>().PlayOneShot(endClip);
	}
}
