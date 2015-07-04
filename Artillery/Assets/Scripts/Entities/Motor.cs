/*
 * Script: Motor
 * Purpose: Handle the player's movements and the turret's rotation
 * 
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CharacterController))]

public class Motor : MonoBehaviour 
{
    // Public Variables
    [Header("Setup Values")]
    public Transform turretTF;

    [HideInInspector] public Transform tf;
    [HideInInspector] public PlayerController player;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public float turretLimits; // In degrees from 0

    // Private Variables

	// Use this for initialization
	void Start () 
	{
		tf = gameObject.GetComponent<Transform> ();
        player = GetComponent<PlayerController> ();
        controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    // Movement functions
    public void MoveFoward(float speed)
    {
        controller.SimpleMove(tf.forward * speed);
    }

    public void MoveBackward(float speed)
    {
        MoveFoward(-speed);
    }

    public void ApplyGravity()
    {
        controller.SimpleMove(Vector3.zero);
    }

    public void TurnRight(float turnSpeed)
    {
        tf.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

    public void TurnLeft(float turnSpeed)
    {
        TurnRight(-turnSpeed);
    }

    // Turret functions
    // Vector3.right rotates the turret up and down
    // Vector3.up rotates the turret right and left
    public void TurretUp(float rotateSpeed)
    {
        // Rotate the turret
        if (turretTF.rotation.eulerAngles.x != 360 - turretLimits)
        {
            turretTF.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
        }

        TurretStablize();
    }

    public void TurretDown(float rotateSpeed)
    {
        // Rotate the turret
        if (turretTF.rotation.eulerAngles.x != 0 && turretTF.rotation.eulerAngles.x > 359 - turretLimits)
        {
            turretTF.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }

        TurretStablize();
    }

    public void TurretRight(float rotateSpeed)
    {
        turretTF.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        TurretStablize();
    }

    public void TurretLeft(float rotateSpeed)
    {
        TurretRight(-rotateSpeed);
        TurretStablize();
    }

    // Gets rid of z value rotation on the turret
    private void TurretStablize()
    {
        Quaternion tempRotation = new Quaternion();
        tempRotation.eulerAngles = new Vector3(turretTF.rotation.eulerAngles.x, turretTF.rotation.eulerAngles.y, 0);
        turretTF.rotation = tempRotation;
    }
}
