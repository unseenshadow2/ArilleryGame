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

	[HideInInspector] public numTargets;

	// Private Variabels

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

	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
	public float eventPause = 1; // Seconds per tick
}