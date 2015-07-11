using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public PhysicsMovement pMovement;
	private Collider[] hits;

	// Use this for initialization
	void Start () 
	{
		pMovement = gameObject.GetComponent<PhysicsMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log ("Boop");

		if (coll.gameObject.tag == "Target") 
		{
		}

		Destroy (gameObject);
	}
	
}
