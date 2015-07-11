/*
 * Script: Artillery
 * Purpose: Handle the projected flight path of the bullet and draw a reticle where bullet will impact
 */

using UnityEngine;
using System.Collections;

public class Artillery : MonoBehaviour {

	public Cannon cannon;
	public GameObject reticle;
	public Rigidbody marker;

	public float detectionLimit;

	//private PlayerController pc;
	private Transform markLocate;
	private Transform tf;

	// Use this for initialization
	void Start () 
	{
		cannon = gameObject.GetComponent<Cannon> ();
		//pc = gameObject.GetComponent<PlayerController> ();
		tf = gameObject.GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//MoveReticle();
	}

	public void Mark()
	{
		if (markLocate == null) {

			PhysicsMovement mark = Instantiate (marker, cannon.shooter.position, cannon.shooter.rotation) as PhysicsMovement;

			mark.transform.parent = transform;

			markLocate = mark.GetComponent<Transform> ();

			//mark.velocity = cannon.shooter.forward * cannon.forwardV;
		}
	}

	public void UpdateReticle()
	{

		Transform parent = GameObject.FindGameObjectWithTag ("Player").transform;

		Vector3 nextPos = Vector3.zero;

		//MoveReticle (FindReticlePosition());
		Rigidbody mark = Instantiate (marker, cannon.shooter.position, cannon.shooter.rotation) as Rigidbody;
		mark.transform.parent = parent;

		RaycastHit hit;

		bool keepGoing = true;

		while (keepGoing && mark != null)
		{
			nextPos = mark.GetComponent<PhysicsMovement>().ReturnNextPosition();

			mark.GetComponent<PhysicsMovement>().UpdatePosition();

			//.Raycast(mark.position, nextPos - mark.position, out hit, Vector3.Distance(mark.position, nextPos));

			//if (Physics.Raycast(mark.position, nextPos - mark.position, out hit, Vector3.Distance(mark.position, nextPos)))
			if(Physics.Linecast(mark.position, nextPos, out hit))
			{
				MoveReticle (hit.point);
				keepGoing = false;
				//Destroy (mark);
			}

		/*	if (mark.GetComponent<Marker>().collision)
			{
				keepGoing = false;
			}*/

			else if (mark.GetComponent<PhysicsMovement>().timeAlive > detectionLimit)
			{
				keepGoing = false;
				//Destroy (mark);
			}
		};

		//Destroy (mark);

		return;
	}

	// DrawTraject(projectile.transform.position, projectile.rigidbody2D.velocity);
	
	/*public void DrawTraject(Vector3 startPos, float startVelocity)
	{
		
		var verts = 20;
		var line = this.gameObject.GetComponent(LineRenderer);
		line.SetVertexCount(verts);
		
		Vector3 pos = startPos;
		float vel = startVelocity;
		var grav:Vector2 = Vector2(Physics.gravity.x, Physics.gravity.y);
		for(var i = 0; i < verts; i++)
		{
			line.SetPosition(i, Vector3(pos.x, pos.y, 0));
			vel = vel + grav * Physics.fixedDeltaTime;
			pos = pos + vel * Physics.fixedDeltaTime;
		}
		
	}*/
	
	public void MoveReticle(Vector3 tf)
	{
		if (reticle.transform.position != tf) {
			reticle.transform.position = tf;
		}
	}

	public void RotateReticle(float speed)
	{
		reticle.transform.RotateAround (tf.position, Vector3.up, speed * Time.deltaTime);
	}

	public Vector3 FindReticlePosition()
	{
		//PhysicsMovement mark = Instantiate (marker, cannon.shooter.position, cannon.shooter.rotation) as Transform;

		/*PhysicsMovement mark = Instantiate (marker, cannon.shooter.position, cannon.shooter.rotation) as PhysicsMovement;
		Rigidbody markRB = mark.GetComponent<Rigidbody> ();
		Vector3 newTF = mark.ReturnNextPosition();

		RaycastHit hit;

		while (!markRB.SweepTest(newTF - mark.transform.position, out hit, Vector3.Distance(mark.transform.position, newTF))) 
		{
			Debug.Log ("Boop");
			mark.UpdatePosition();

			newTF = mark.ReturnNextPosition();

		};*/

		//return newTF;

		//mark.transform.parent = transform;

		//markLocate = mark.GetComponent<Transform> ();

		//while (!mark.IsColliding
		return Vector3.zero;
	}


}
