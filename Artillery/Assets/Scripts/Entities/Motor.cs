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

	// Use this for initialization
	void Start () 
	{
		tf = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
