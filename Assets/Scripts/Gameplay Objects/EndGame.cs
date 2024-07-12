using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
	private Scene currentScene;

	private void Start()
	{
		currentScene = SceneManager.GetActiveScene();
	}

	private void OnTriggerEnter(Collider other)
	{
		switch (currentScene.name)
		{
			case "game":
				if (other.CompareTag("Player"))
				{
					GameManager.singleton.CutSceneChange("EndCutScene");
				}
				break;
			case "EndCutScene":
				if (other.CompareTag("Player"))
				{
					GameManager.singleton.EndGame();
				}
				break;
			default:
				break;
		}
	}
}
