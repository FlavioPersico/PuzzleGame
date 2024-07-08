using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthUIValue;
    [SerializeField] private GameObject UIHowToPlay;
	[SerializeField] private GameObject UIMenu;
	[SerializeField] private GameObject UIGameOver;
	[SerializeField] private GameObject UIGameEnded;

	public static UIManager singleton;
    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
    }

    public void UIHealthUpdate(int  health)
    {
        healthUIValue.text = health.ToString();
    }

    public void GameOver()
    {
        UIGameOver.SetActive(true);
    }

	public void GameCompleted()
	{
		UIGameEnded.SetActive(true);
	}

	public void HowToPlay(bool param)
	{
		UIHowToPlay.SetActive(param);
	}

	public void Menu()
	{
        UIMenu.SetActive(true);
	}

}
