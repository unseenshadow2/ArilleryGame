/*
	Script: Target
	Purpose: Add points and destroy self when hit bullets
 */

using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void Start()
	{
		//GameManager.instance.numTargets += 1;
	}

	void TargetHit()
	{
		//GameManager.instance.numTargets -= 1;
		//GameManager.instance.playerScore += 1000;
		//Destroy(gameObject);
	}

	void OnCollisionEnter(Collider coll)
	{
		TargetHit ();
	}
}
