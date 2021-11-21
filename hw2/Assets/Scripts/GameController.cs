using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject openButton;
	public GameObject closeButton;
	public GameObject settingsBackground;
	public AudioClip[] audioClips;

	private AudioSource audioSource;
	private GameObject startCanvas;
	private GameObject settingsCanvas;

	private static GameController instance;

	void Awake() {
		DontDestroyOnLoad(this);

		if (instance == null) {
			instance = this;
		} else {
			Object.Destroy(gameObject);
			Object.Destroy(settingsCanvas);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		openButton.SetActive(true);
		closeButton.SetActive(false);
		settingsBackground.SetActive(false);

		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClips[0];
		audioSource.Play();

		settingsCanvas = GameObject.Find("SettingsCanvas");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void EnableSettings() {
		openButton.SetActive(false);
		closeButton.SetActive(true);
		settingsBackground.SetActive(true);

		startCanvas = GameObject.Find("StartCanvas");
		if (startCanvas != null) {
			startCanvas.SetActive(false);
		}

		Time.timeScale = 0;
	}

	public void DisableSettings() {
		openButton.SetActive(true);
		closeButton.SetActive(false);
		settingsBackground.SetActive(false);

		if (startCanvas != null) {
			startCanvas.SetActive(true);
		}

		Time.timeScale = 1;
	}

	public void OnVolumeSliderChanged(float value) {
		audioSource.volume = value;
	}

	public void OnChooseBGMDropdownChanged(int value) {
		audioSource.Stop();
		audioSource.clip = audioClips[value];
		audioSource.Play();
	}

	public void StartGame() {
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Start") {
			SceneManager.LoadScene("Main");
		}
	}

	public void QuitGame() {
		Application.Quit();
	}
}
