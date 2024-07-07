using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int currentHealth;

    public UnityEvent<int> OnHealthChange;
    // Start is called before the first frame update

    public HealthModule()
    {
        currentHealth = 1;
        OnHealthChange = new UnityEvent<int>();
	}

	void Start()
    {
        currentHealth = maxHealth;
	}

    public void DeductHealth(int toDeduct) 
    { 
        currentHealth -= toDeduct;
        //OnHealthChange.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            GameManager.singleton.GameOver();
        }
    }

}
