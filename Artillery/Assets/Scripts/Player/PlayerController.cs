/* 
 * Script: PlayerController
 * Purpose: To handle all of the player's input
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerData))]
[RequireComponent (typeof(Motor))]

public class PlayerController : MonoBehaviour 
{
	public PlayerData data;
	public Motor motor;

	// Use this for initialization
	void Start () 
	{
		data = GameManager.instance.playerData;
		motor = gameObject.GetComponent<Motor> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey("w"))
		{

		}

		if (Input.GetKey("a"))
		{
			
		}

		if (Input.GetKey("s"))
		{
			
		}

		if (Input.GetKey("d"))
		{
			
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			
		}


	}
}
