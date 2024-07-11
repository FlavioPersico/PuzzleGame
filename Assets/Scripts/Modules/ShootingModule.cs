using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingModule : MonoBehaviour
{
	[SerializeField] private Camera camera;
	[SerializeField] private Rigidbody projectile;
	[SerializeField] private Transform shootingPoint;
	[SerializeField] private float shotStrenght;
	[SerializeField] private ObjectPool ObjectPool;
	[SerializeField] private AudioClip shotAudio;

	public void Shoot()
	{
		PooledObjects tempPool = ObjectPool.RetrieveAvailableItem();
		SoundControl.audioPlayer.PlayOneShot(shotAudio);
		Rigidbody bulletInstantiate = tempPool.rigidBody; //Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
		bulletInstantiate.position = shootingPoint.position;
		bulletInstantiate.rotation = shootingPoint.rotation;
		bulletInstantiate.AddForce(shotStrenght * shootingPoint.forward, ForceMode.Impulse);
		tempPool.ResetBackToPool(5f);
		//Destroy(bulletInstantiate, 5f);
	}
}
