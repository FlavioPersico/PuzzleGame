using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
	public Rigidbody rigidBody; //{ get; private set; }
	private ObjectPool poolOwner;
    private float timerToReset;
    private bool reseting;

	private void Update()
	{
		if(reseting)
        {
            timerToReset -= Time.deltaTime;
            if(timerToReset <= 0 )
            {
                ResetBackToPool();
            }
        }
	}

	public void LinkToPool(ObjectPool owner)
	{
		poolOwner = owner;
	}

	public void ResetBackToPool()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		reseting = false;
		poolOwner.ResetBullet(this);
	}

	public void ResetBackToPool(float time)
	{
		timerToReset = time;
		reseting = true;
	}
}
