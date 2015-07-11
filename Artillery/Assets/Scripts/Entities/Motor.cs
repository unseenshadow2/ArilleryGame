/*
 * Script: Motor
 * Purpose: Handle the player's movements and the turret's rotation
 * 
 */

using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour 
{
	public Transform tf;
	public Transform turretTF;

	// Use this for initialization
	void Start () 
	{
		tf = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RotateTurret(float speed)
	{
		turretTF.Rotate (Vector3.up * speed * Time.deltaTime, Space.World);
	}

	public void TurretUpDown(float speed)
	{
		turretTF.Rotate (Vector3.right * speed * Time.deltaTime);

	}
}
