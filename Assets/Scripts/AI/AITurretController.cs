using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AITurretController : MonoBehaviour
{
	[SerializeField] private Player player;

   // [SerializeField] private float time;
    //[SerializeField] private float timer;
   // [SerializeField] private float delayTime;

	public AIState currentState;

    void Start()
    {
        player = FindObjectOfType<Player>();
        //ChangeState(new IdleState(this));
       // timer = delayTime;
    }

	public void ChangeState(AIState state)
	{
		if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;
		currentState.OnStateEnter();
	}

	// Update is called once per frame
	void Update()
    {
        Debug.Log(currentState.ToString());


       /* time = Time.time;
        if (time > timer)
        {*/
			currentState.OnStateRun();
		/*	timer = time + delayTime;
        }*/

		//currentState.OnStateRun();
    }

    public Player GetPlayer()
    {
        return player;
    }
}
