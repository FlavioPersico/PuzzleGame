using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandInteractor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
	[SerializeField] private Camera camera;
	[SerializeField] private LayerMask clickableLayer;
	[SerializeField] private Queue<Command> commands = new Queue<Command>();

	private Command currentCommand;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(currentCommand != null)
		{
			currentCommand.Execute();
			if (currentCommand.IsCompleted())
			{
				if (commands.Count == 0)
				{
					return;
				}
				currentCommand = commands.Dequeue();
			}
		}
		else if(commands.Count != 0) 
		{
			currentCommand = commands.Dequeue();
		}

		//take the first command and keep track of it as a "currentCommand"
		//Check if this command is completed
		//if completed, remove this command and go to next one
		//if not complated, just keep executing
	}

	public void CreateCommand()
	{
		Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 5f, clickableLayer))
		{
			commands.Enqueue(new MoveCommand(agent, hit.point));
		}
	}
}
