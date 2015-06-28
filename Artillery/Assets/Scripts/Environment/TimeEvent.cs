/*
 * Name: Time Event
 * Purpose:	To act as the parent
 * 			class for events that
 * 			happen when the game
 * 			manager pulses.
 */

using UnityEngine;
using System.Collections;

public class TimeEvent : MonoBehaviour 
{
	// Public Variables

	// Private Variables

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Where the stuff for time events happen
	public virtual void OnPulse()
	{

	}
}
