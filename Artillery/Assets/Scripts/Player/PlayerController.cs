/* 
 * Script: PlayerController
 * Purpose: To handle all of the player's input
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerData))]
[RequireComponent (typeof(Motor))]
[RequireComponent(typeof(Artillery))]

public class PlayerController : MonoBehaviour 
{
	public PlayerData data;
	public ControlsData controls;
	public Motor motor;
	public Cannon cannon;
	public Artillery artillery;

	// Use this for initialization
	void Start () 
	{
		data = GameManager.instance.playerData;
		controls = GameManager.instance.controls;
		motor = gameObject.GetComponent<Motor> ();
		cannon = gameObject.GetComponent<Cannon> ();
		artillery = gameObject.GetComponent<Artillery> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(controls.moveForward))
		{

		}

		if (Input.GetKey(controls.moveBackward))
		{
			
		}

		if (Input.GetKey(controls.turnLeft))
		{
			
		}

		if (Input.GetKey(controls.turnRight))
		{
			
		}

		if (Input.GetKey(controls.turretUp))
		{
			motor.TurretUpDown(-data.cannonUpDownSpeed);
			//artillery.Mark();
			artillery.UpdateReticle();
		}

		if (Input.GetKey(controls.turretDown))
		{
			motor.TurretUpDown(data.cannonUpDownSpeed);
			//artillery.Mark();
			artillery.UpdateReticle();
		}

		if (Input.GetKey(controls.turretLeft))
		{
			motor.RotateTurret(-data.cannonTurnSpeed);
			//artillery.Mark();
			//artillery.RotateReticle(-data.cannonTurnSpeed);
			artillery.UpdateReticle();
		}

		if (Input.GetKey(controls.turretRight))
		{
			motor.RotateTurret(data.cannonTurnSpeed);
			//artillery.Mark();
			//artillery.RotateReticle(data.cannonTurnSpeed);
			artillery.UpdateReticle();
		}

		if (Input.GetKeyDown(controls.fire))
		{
			cannon.Shoot();
			//artillery.Mark();
		}

	}
}
