using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthModule : MonoBehaviour
{
    //[SerializeField] private int maxHealth;
    private int currentHealth;

    public UnityEvent<int> OnHealthChange;
	public UnityEvent OnDied;
    // Start is called before the first frame update

    public HealthModule()
    {
        currentHealth = 1;
        OnHealthChange = new UnityEvent<int>();
        OnDied = new UnityEvent();
	}

	void Start()
    {
        //currentHealth = maxHealth;
	}

    public void DeductHealth(int toDeduct) 
    { 
        currentHealth -= toDeduct;
        //OnHealthChange.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            OnDied.Invoke();
        }
    }

}
