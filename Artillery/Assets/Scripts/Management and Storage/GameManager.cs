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

	bool isGameOver = false;

	[HideInInspector] public int numTargets;

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