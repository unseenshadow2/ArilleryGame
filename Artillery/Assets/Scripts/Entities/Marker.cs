using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour 
{
	//public Transform reticle;
	public PhysicsMovement pMovement;
	private Collider[] hits;

	public bool collision = false;

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
		/*

		if (coll.gameObject.tag != "Marker") {
			collision = true;
			ContactPoint contact = coll.contacts [0];
			//Debug.Log (contact);

			Vector3 point = contact.point;
			//Debug.Log (point);

			//gameObject.GetComponent<Artillery> ().MoveReticle (point);
			SendMessageUpwards ("MoveReticle", point, SendMessageOptions.DontRequireReceiver);
			Debug.Log ("boop");

			Destroy (gameObject);
		}*/
		Destroy (gameObject);
	}
}
