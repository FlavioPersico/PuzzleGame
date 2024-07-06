using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] private List<PooledObjects> availableObjects = new List<PooledObjects>();
    [SerializeField] private PooledObjects originalObject;
    [SerializeField] private int amountOfCopies;

	void Awake()
    {
        for(int index = 0; index < amountOfCopies; index++)
        {
            CreateCopy();	
        }
    }

    private void CreateCopy()
    {
		PooledObjects tempObject = Instantiate(originalObject, transform);
        tempObject.LinkToPool(this);
		tempObject.gameObject.SetActive(false);
		availableObjects.Add(tempObject);
	}

    public PooledObjects RetrieveAvailableItem()
    {
        if(availableObjects.Count == 0)
        {
            CreateCopy();
        }

		PooledObjects tempObject = availableObjects[0];
        availableObjects.RemoveAt(0);
        tempObject.gameObject.SetActive(true);
        return tempObject;
    }

    public void ResetBullet(PooledObjects cloneObject)
    {
       cloneObject.gameObject.SetActive(false);
       availableObjects.Add(cloneObject);
    }
}
