/*
 * Script: Game Manager
 * Purpose:	To handle all centralized
 * 			data and functions.
 */

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	// Public Variables
	public static GameManager instance;
	public PlayerData playerData;
	public EnemyData enemyData;
	public TimeData timeData;

	[HideInInspector] public int numTargets;
	[HideInInspector] public TimeEvent[] timedEvents;

	// Private Variabels
	private float nextPulse;

	void Awake ()
	{
		// Make a singleton
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		// Get all timed events
		timedEvents = FindObjectsOfType<TimeEvent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time >= nextPulse)
		{
			SendPulse();
			nextPulse += timeData.eventPause;
		}
	}

	// Send the pulse to the timed events
	// Returns true if elements exist in timedEvents
	bool SendPulse()
	{
		if (timedEvents.Length > 0)
		{
			// Call the function they need called
			foreach (TimeEvent element in timedEvents)
			{
				element.OnPulse();
			}

			return true;
		}
		else
		{
			return false;
		}
	}
}

[System.Serializable]
public class PlayerData
{
	public int score = 60000;
	public float forwardSpeed; // In meters per second
	public float reverseSpeed; // In meters per second
	public float turnSpeed; // In degrees per second
	public float cannonUpDownSpeed;
	public float cannonTurnSpeed; // In degrees per second
}

[System.Serializable]
public class EnemyData
{
	public int scoreValue = 1;
}

[System.Serializable]
public class TimeData
{
	public float pointsPerSecond = 1000;
	public float eventPause = 1; // Seconds per tick, how often between pulses
}

[System.Serializable]
public class ControlsData
{
	public KeyCode moveForward = ;
	public KeyCode moveBackward;
	public KeyCode turnLeft;
	public KeyCode turnRight;
	public KeyCode turretUp;
	public KeyCode turretDown;
	public KeyCode turretRight;
	public KeyCode turretLeft;
	public KeyCode fire;
}