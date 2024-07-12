using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private UIManager uiManager;
	[SerializeField] private AudioClip audioClip;
    public static GameManager singleton;

	private InputController player;

	private void Awake()
	{
			singleton = this;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ExitGame();
		}
	}
	public void StartGame()
	{
		SoundControl.audioPlayer.PlayOneShot(audioClip);
		SceneManager.LoadScene("IntroCutScene");
	}

	public void HowToPlay()
	{
		SoundControl.audioPlayer.PlayOneShot(audioClip);
		uiManager.HowToPlay(true);
	}

	public void HowToPlayReturn()
	{
		SoundControl.audioPlayer.PlayOneShot(audioClip);
		uiManager.HowToPlay(false);
	}

	public void LoadGame()
	{
		Time.timeScale = 1;
		SoundControl.audioPlayer.PlayOneShot(audioClip);
		SceneManager.LoadScene("game");
	}

	public void LoadMenu()
	{
		Time.timeScale = 1;
		SoundControl.audioPlayer.PlayOneShot(audioClip);
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
		Time.timeScale = 0;
		uiManager.GameCompleted();
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void CutSceneChange(string sceneLoad)
	{
		SceneManager.LoadScene(sceneLoad);
	}
}
