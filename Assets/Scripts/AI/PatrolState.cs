using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolState : AIState
{
	private int wayPointsIndex;

	public PatrolState(AIController contr) : base(contr)
	{

	}
	public override void OnStateEnter()
	{
		Debug.Log("Patrol entered");
		controller.GetAgent().SetDestination(controller.GetPath()[wayPointsIndex].position);
	}

	public override void OnStateExit()
	{
		Debug.Log("Patrol exit");
	}

	public override void OnStateRun()
	{
		if (controller.GetAgent().remainingDistance <= controller.GetAgent().stoppingDistance)
		{
			wayPointsIndex++;
			if (controller.GetPath().Length == wayPointsIndex)
			{
				wayPointsIndex = 0;
			}

			controller.GetAgent().SetDestination(controller.GetPath()[wayPointsIndex].position);
		}
	}
}
