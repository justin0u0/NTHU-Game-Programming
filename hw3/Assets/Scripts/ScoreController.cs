using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public int shoots;
	public int score;

	private static ScoreController instance;
	private Text shootsText;
	private Text scoreText;
	private Text totalShootsText;
	private Text totalScoreText;
	private int totalShoots;
	private int totalScore;

	void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		shoots = 0;
		score = 0;
		totalShoots = 0;
		totalScore = 0;

		shootsText = getTextByName("ShootsText");
		scoreText = getTextByName("ScoreText");
		totalShootsText = getTextByName("TotalShootsText");
		totalScoreText = getTextByName("TotalScoreText");
	}

	void Update()
	{
		shootsText = getTextByName("ShootsText");
		scoreText = getTextByName("ScoreText");
		totalShootsText = getTextByName("TotalShootsText");
		totalScoreText = getTextByName("TotalScoreText");

		if (shootsText != null) {
			shootsText.text = $"Shoots: {shoots}";
		}
		if (scoreText != null) {
			scoreText.text = $"Score: {score}";
		}
		if (totalShootsText != null) {
			totalShootsText.text = $"Total Shoots: {totalShoots}";
		}
		if (totalScoreText != null) {
			totalScoreText.text = $"Total Score: {totalScore}";
		}
	}

	public void Restart()
	{
		shoots = 0;
		score = 0;
	}

	public void NextStage()
	{
		totalShoots += shoots;
		totalScore += score;
		Restart();
	}

	private Text getTextByName(string name) {
		GameObject o = GameObject.Find(name);
		if (o != null) {
			return o.GetComponent<Text>();
		}
		return null;
	}
}
