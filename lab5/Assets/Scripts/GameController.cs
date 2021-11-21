using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
	public GameObject canvas;
	public GameObject winText;
	public GameObject loseText;

	// Start is called before the first frame update
	void Start()
	{
		winText.SetActive(false);
		loseText.SetActive(false);
		canvas.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Win()
	{
		canvas.SetActive(true);
		loseText.SetActive(false);
		winText.SetActive(true);
	}

	public void Lose()
	{
		canvas.SetActive(true);
		winText.SetActive(false);
		loseText.SetActive(true);
	}

	public void Retry()
	{
		PlayerController playerController = player.GetComponent<PlayerController>();
		playerController.Retry();
		canvas.SetActive(false);
	}
}
