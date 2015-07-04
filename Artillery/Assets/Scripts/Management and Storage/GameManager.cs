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
	public ControlsData controlsData;

	bool isGameOver = false;

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

	public void TargetDead(int score)
	{
		playerData.playerScore += score;
		numTargets -= 1;

		if (numTargets == 0) 
		{
			GameOver();
		}
	}

	void GameOver()
	{
		isGameOver = true;
		playerData.finalScore = playerData.bonusScore + playerData.playerScore;
	}
}

[System.Serializable]
public class PlayerData
{
	public int playerScore = 0;
	public int bonusScore = 60000;
	public int finalScore;
	public float forwardSpeed = 5; // In meters per second
	public float reverseSpeed = 3; // In meters per second
	public float turnSpeed = 90; // In degrees per second
	public float cannonUpDownSpeed = 30; // In degrees per second
	public float cannonTurnSpeed = 30; // In degrees per second
    public float cannonVerticleLimit = 90; // In degrees
}

[System.Serializable]
public class EnemyData
{
	public int scoreValue = 1;
    public int health = 1; // The number of hits that the targets require before they die
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
	public KeyCode moveForward = KeyCode.W;
	public KeyCode moveBackward = KeyCode.S;
	public KeyCode turnLeft = KeyCode.A;
	public KeyCode turnRight = KeyCode.D;
	public KeyCode turretUp = KeyCode.UpArrow;
	public KeyCode turretDown = KeyCode.DownArrow;
	public KeyCode turretRight = KeyCode.RightArrow;
	public KeyCode turretLeft = KeyCode.LeftArrow;
	public KeyCode fire = KeyCode.Space;
}