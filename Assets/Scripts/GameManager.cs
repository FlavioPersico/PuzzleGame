using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

	private void Awake()
	{
		singleton = this;
	}
	public void GameOver()
    {
        Debug.Log("Player DEAD!");
        Time.timeScale = 0;
    }
}
