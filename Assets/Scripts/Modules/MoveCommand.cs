using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
	private NavMeshAgent agentToCommand;
	private Vector3 destination;
	private bool arrivedAtDestination;

	public MoveCommand(NavMeshAgent agent, Vector3 position)
	{
		this.agentToCommand = agent;
		this.destination = position;
	}
	public override void Execute()
	{
		//Set AI destination to a Vector 3
		agentToCommand.SetDestination(destination);
		if(agentToCommand.remainingDistance < 0.2f )
		{
			arrivedAtDestination = true;
		}
		//if arrived at destination
		//arrivedAtDestination = true;
	}

	public override bool IsCompleted()
	{
		return arrivedAtDestination;
	}
}
