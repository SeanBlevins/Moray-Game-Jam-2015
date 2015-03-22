using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Movement : MonoBehaviour {
	float speed = 10.00f;
	float direction = 0.0f;
	public Collider collider;
	float distToGround, distToSide;
	public float jump = 2;
	public string JoystickInput, AInput;

    public LayerMask layerMask;
	public AudioClip jumpOne, jumpTwo;

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
			if(Input.GetAxis(AInput) >0)
			{
				GetComponent<AudioSource>().PlayOneShot(jumpOne,1.0f);
			}

		} else if (IsBelowPlatform ()) {
			jump = 0 - 0.09f;

		}// else if (IsToLeftOfPlatform () || IsToRightOfPlatform ()) {
			//direction = 0;
		//}

		else jump = jump - 0.09f;

		transform.Translate (direction * speed * Time.deltaTime, jump * speed * Time.deltaTime, 0);

	}
	// Update is called once per frame
	void Update ()
	{
	}

	bool IsGrounded()  
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.FindChild("GroundCheck").transform.localPosition);
		//print (transform.FindChild ("GroundCheck").transform.position);

		Debug.DrawLine (transform.position, transform.FindChild("GroundCheck").transform.position);
		if (Physics.Raycast (ray, out hit,-transform.FindChild("GroundCheck").transform.localPosition.y,layerMask))
		{
			//print("groundcheck " + hit.transform.tag);
			if(hit.transform.tag == "Ground" || hit.transform.tag == "Platform")

			{
				return true;
			}
			else
			{
                print("else " + hit.transform.tag);
			}
		}
		return false;//Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	bool IsBelowPlatform()
	{
		RaycastHit hit;
		Ray ray = new Ray (transform.position, Vector3.up);
		//Debug.DrawRay (transform.position,Vector3.up,Color.red, Mathf.Infinity);
		if (Physics.Raycast (ray, out hit, 1.0f,layerMask))
		{
			//print("below " + hit.transform.tag);
			if(hit.transform.tag == "Ground" || hit.transform.tag == "Platform")
			{
				return true;
			}
		}
		return false;
		//return Physics.Raycast(transform.position, Vector3.up, distToGround + 0.1f);
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