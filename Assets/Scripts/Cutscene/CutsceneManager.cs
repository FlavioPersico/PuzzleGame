using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private float changeTime;
    [SerializeField] private string sceneLoad;

	private void Update()
	{
		changeTime -= Time.deltaTime;
		if (changeTime <= 0)
		{
			GameManager.singleton.CutSceneChange(sceneLoad);
		}
	}

}
