/*
 * Script: Cannon
 * Purpose: Shoots the bullet along the projected flight path.
 */

using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	//private Artillery artillery;
	public Transform shooter;

	public PhysicsMovement bullet;
	public float forwardV = 5f;

	// Use this for initialization
	void Start () 
	{
		//artillery = gameObject.GetComponent<Artillery> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Shoot()
	{
		PhysicsMovement projectile = Instantiate (bullet, shooter.position, shooter.rotation) as PhysicsMovement;
		//projectile.velocity = new Vector3 (0, 0, forwardV);
		//projectile.velocity = shooter.forward * forwardV;
	}
}
