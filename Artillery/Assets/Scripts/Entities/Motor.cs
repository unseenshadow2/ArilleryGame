﻿/*
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
    public float turretFixTime = 3; // In seconds

    [Header("Setup Values")]
    public Transform turretTF;

    [HideInInspector] public Transform tf;
    [HideInInspector] public PlayerController player;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public float turretLimits; // In degrees from 0

    // Private Variables
    private bool isFixingTurret = false;
    private float currentPercentFixed = 0; // In decimal format
    private Quaternion fixedPosition; // The rotation the turret will have when it is "fixed"
    private Quaternion brokenPosition; // The roatation the turret had before it was being "repaired"

	// Use this for initialization
	void Start () 
	{
		tf = gameObject.GetComponent<Transform> ();
        player = GetComponent<PlayerController> ();
        controller = GetComponent<CharacterController> ();
        fixedPosition = new Quaternion();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (isFixingTurret)
        {
            // Update the rotation of the turret
            currentPercentFixed += Time.deltaTime / turretFixTime;
            turretTF.localRotation = Quaternion.Lerp(brokenPosition, fixedPosition, currentPercentFixed);

            // Reset when the time is right
            if (currentPercentFixed >= 1)
            {
                isFixingTurret = false;
            }
        }
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
        if ((turretTF.rotation.eulerAngles.x >= 360 - turretLimits || turretTF.rotation.eulerAngles.x < 10) && !isFixingTurret)
        {
            Debug.Log("Turret Limits: " + turretLimits.ToString() + "\tResults Limit: " + (360 - turretLimits).ToString());
            turretTF.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
        }

        TurretStablize();
    }

    public void TurretDown(float rotateSpeed)
    {
        // Rotate the turret
        if (turretTF.rotation.eulerAngles.x != 0 && turretTF.rotation.eulerAngles.x > 361 - turretLimits && !isFixingTurret)
        {
            turretTF.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }

        TurretStablize();
    }

    public void TurretRight(float rotateSpeed)
    {
        if (!isFixingTurret)
        {
            turretTF.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            TurretStablize();
        }
    }

    public void TurretLeft(float rotateSpeed)
    {
        if (!isFixingTurret)
        {
            TurretRight(-rotateSpeed);
            TurretStablize();
        }
    }

    // Fix the turret when it locks up near the top
    public void FixTurret(float rotateSpeed)
    {
        if (!isFixingTurret)
        {
            isFixingTurret = true;
            currentPercentFixed = 0;

            fixedPosition.eulerAngles = new Vector3(-(turretLimits / 2), turretTF.localRotation.eulerAngles.y, 0);
            brokenPosition = turretTF.localRotation;
        }
    }

    // Gets rid of z value rotation on the turret
    private void TurretStablize()
    {
        Quaternion tempRotation = new Quaternion();
        tempRotation.eulerAngles = new Vector3(turretTF.rotation.eulerAngles.x, turretTF.rotation.eulerAngles.y, 0);
        turretTF.rotation = tempRotation;
    }
}
