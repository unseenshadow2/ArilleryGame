/*
	Script: Target
	Purpose: Add points and destroy self when hit bullets
 */

using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{
	int score = 1000;

	void Start()
	{
		GameManager.instance.numTargets += 1;
	}

	void TargetHit()
	{
		GameManager.instance.TargetDead (score);
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision coll)
	{
		TargetHit ();
	}
}
