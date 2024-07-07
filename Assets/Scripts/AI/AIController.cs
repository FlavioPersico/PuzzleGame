using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class AIController : MonoBehaviour
{
	[SerializeField] private Transform[] targets;
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Player player;

	public AIState currentState;

	// Start is called before the first frame update
	void Start()
	{
		player = FindObjectOfType<Player>();

		switch (this.tag)
		{
			case "Turret":
				ChangeState(new IdleState(this));
				break;
			case "Enemy":
				ChangeState(new PatrolState(this));
				break;

			default:
				break;
		}		
	}

	public void ChangeState(AIState state)
	{
		if (currentState != null)
		{
			currentState.OnStateExit();
		}

		currentState = state;
		currentState.OnStateEnter();
	}

	// Update is called once per frame
	void Update()
	{
		currentState.OnStateRun();
	}

	public NavMeshAgent GetAgent()
	{
		return agent;
	}

	public Transform[] GetPath()
	{
		return targets;
	}

	public Player GetPlayer()
	{
		return player;
	}
}
