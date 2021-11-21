using UnityEngine;

public class StartController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartGame() {
		GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
		gameController.StartGame();
	}

	public void QuitGame() {
		GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
		gameController.QuitGame();
	}
}
