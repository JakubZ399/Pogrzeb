using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform bulletSpawnPoint;
	public GameObject bulletPrefab;
	public float bulletSpeed = 10;

	void Update()
	{
		if(Input.GetMouseButton(1))
		{
			Debug.Log("Left Mouse Button Pressed");
			var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
		}
	}
}
