using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int PlayerNum = 0;
    public float Speed = 5f;
    private bool boost = false;
    public bool isReady = false;

    public Material[] materials;
    public Renderer rend;
	// Use this for initialization
	void Start ()
	{
	    rend = GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        boost = false || Input.GetButton("Player" + PlayerNum + "A");

	    if (Input.GetButton("Player" + PlayerNum + "A"))
	    {
            isReady = true;
            rend.sharedMaterial = materials[1];
	    }

	    float mSpeed = boost ? Speed * 2f : Speed;

        float movement = Input.GetAxis("Player" + PlayerNum + "Horizontal") * Time.deltaTime * mSpeed;
        transform.position += new Vector3(movement, 0, 0);
	}
}
