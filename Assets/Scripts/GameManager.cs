using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private UIManager uiManager;
    public static GameManager singleton;

	public UnityEvent OnUnityLevelStart;
	public UnityEvent OnUnityLevelEnds;
	private InputController player;

	private void Awake()
	{
		if (singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/*private void Start()
	{
		StartLevel();
	}

	public void StartLevel()
	{
		player = FindObjectOfType<InputController>();
		OnUnityLevelStart?.Invoke();
	}

	public void FinishLevel()
	{
		OnUnityLevelEnds?.Invoke();
	}

	public void LockPlayerInput()
	{
		player.enabled = false;
	}

	public void UnlockPlayerInput()
	{
		player.enabled = true;
	}*/

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ExitGame();
		}
	}
	public void StartGame()
	{
		Invoke("LoadGame", 2f);
	}

	public void HowToPlay()
	{
		uiManager.HowToPlay(true);
	}

	public void HowToPlayReturn()
	{
		uiManager.HowToPlay(false);
	}

	public void LoadGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("game");
	}

	public void LoadMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void GameOver()
    {
        Debug.Log("Player DEAD!");
        Time.timeScale = 0;
		uiManager.GameOver();
    }

	public void EndGame()
	{
		uiManager.GameCompleted();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
