using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthUIValue;
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
}
