using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float speed = 10.00f;
	float direction = 0.0f;
	public Collider collider;
	float distToGround, distToSide;
	public float jump = 2;
	public string JoystickInput, AInput;
	public Collider otherPlayer;
	void Start () {
		distToGround = collider.bounds.extents.y;
		distToSide = collider.bounds.extents.x;
		//material.color = Color.magenta;
	}
	void FixedUpdate()
	{
		direction = Input.GetAxis (JoystickInput);
		if (IsGrounded ()) {
			jump = 0;
			jump = Input.GetAxis (AInput) * 1.75f;
			//print ("grounded");
		} else if (IsBelowPlatform ()) {
			jump = 0 - 0.09f;
			//print ("platform");
		} else if (IsToLeftOfPlatform () || IsToRightOfPlatform ()) {
			direction = 0;
		}
		else jump = jump - 0.09f;

		transform.Translate (direction * speed * Time.deltaTime, jump * speed * Time.deltaTime, 0);
	}
	// Update is called once per frame
	void Update () {
		Physics.IgnoreCollision (collider, otherPlayer);
	}

	bool IsGrounded()  
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.FindChild("GroundCheck").transform.localPosition);
		//print (transform.FindChild ("GroundCheck").transform.position);
		Debug.DrawRay (transform.position, transform.FindChild("GroundCheck").transform.localPosition);
		if (Physics.Raycast (ray, out hit,-transform.FindChild("GroundCheck").transform.localPosition.y))
		{
			//print(hit.transform.name);
			if(hit.transform.tag == "Ground")
			{
				return true;
			}
		}
		return false;//Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	bool IsBelowPlatform()
	{
		return Physics.Raycast(transform.position, Vector3.up, distToGround + 0.1f);
	}

	bool IsToRightOfPlatform()
	{
		return Physics.Raycast(transform.position, -Vector3.right, distToSide + 0.1f);
	}

	bool IsToLeftOfPlatform()
	{
		return Physics.Raycast(transform.position, Vector3.right, distToSide + 0.1f);
	}
}