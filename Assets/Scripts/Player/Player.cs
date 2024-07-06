using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthModule healthModule;
    // Start is called before the first frame update
    void Start()
    {
        healthModule = new HealthModule();
        healthModule.OnHealthChange.AddListener(ChangeHealth);
    }

    public void ChangeHealth(int healthParam)
    {
		UIManager.singleton.UIHealthUpdate(healthParam);
	}

	public void ReceiveDamage(int damage)
	{
		healthModule.DeductHealth(damage);
	}

}
