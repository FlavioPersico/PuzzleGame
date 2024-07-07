using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
	[SerializeField] private AIController myController;
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			myController.ChangeState(new ChaseState(myController, other.transform));
			GameManager.singleton.GameOver();
			Debug.Log("Player enter chase");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			myController.ChangeState(new PatrolState(myController));
			Debug.Log("Player exit chase");
		}

	}
}
