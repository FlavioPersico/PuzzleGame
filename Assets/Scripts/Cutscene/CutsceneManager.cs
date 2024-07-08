using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneStartType cutSceneType;
    [SerializeField] private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.singleton.OnUnityLevelStart.AddListener(StartCutscene);
    }

	private void StartCutscene()
    {
        //GameManager.singleton.LockPlayerInput();
        //director.Play();
    }

	public void OnCutsceneEnd()
	{
		//GameManager.singleton.OnUnityLevelEnds.RemoveListener(StartCutscene);
	}

	public enum CutsceneStartType
	{
		//OnLevelStart, OnLevelFinish
	}
}
