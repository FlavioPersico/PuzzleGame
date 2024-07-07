using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
	private Transform targetToChase;

	public ChaseState(AIController contr, Transform target) : base(contr)
	{
		targetToChase = target;
	}

	public override void OnStateEnter()
	{
		
	}

	public override void OnStateExit()
	{
		
	}

	public override void OnStateRun()
	{
		controller.GetAgent().SetDestination(targetToChase.position);
		if (controller.GetAgent().remainingDistance <= controller.GetAgent().stoppingDistance)
		{
			//change to attack

		}
	}
}
