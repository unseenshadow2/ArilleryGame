using UnityEngine;
using System.Collections;

public class PhysicsMovement : MonoBehaviour {

	public Vector3 basePosition;
	public float timeAlive;
	public float velocity = 25f;
	public Transform tf;

	public bool moveable = false;

	void Awake()
	{
		basePosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}

	// Use this for initialization
	void Start () 
	{
		tf = gameObject.GetComponent<Transform> ();
		timeAlive = 0f;
		//basePosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.position = GetPositionAtTime (basePosition, transform.forward, velocity, timeAlive);
		//timeAlive += Time.deltaTime;
		if (moveable) {
			UpdatePosition ();
		} 
		else 
		{
			timeAlive += Time.deltaTime;
		}

		if (timeAlive > 5f) 
		{
			Destroy (gameObject);
		}
	}

	public void UpdatePosition()
	{
		transform.position = GetPositionAtTime (basePosition, transform.forward, velocity, timeAlive);
		timeAlive += Time.deltaTime;
	}

	public Vector3 ReturnNextPosition()
	{
		Vector3 nextTF = Vector3.zero;
		nextTF = GetPositionAtTime (basePosition, transform.forward, velocity, timeAlive + Time.deltaTime);
		//timeAlive += Time.deltaTime;
		//Vector3 newPos = new Vector3(nextTF.po

		return nextTF;
	}

	// This function returns the position of the projectile at a given time
	public Vector3 GetPositionAtTime ( float time ) 
	{
		return GetPositionAtTime (transform.position, transform.forward, velocity, time);	
	}

	Vector3 GetPositionAtTime(Vector3 position, Vector3 direction, float velocity, float time)
	{
		Vector3 newPos;

		newPos = position + (direction * velocity * time);
		newPos += (Physics.gravity * (time * time)) * 0.5f;

		return newPos;
	}


	public Collider[] IsColliding()
	{
		Collider[] hits = Physics.OverlapSphere (tf.position, 0.5f);
		return hits;
	}
}
