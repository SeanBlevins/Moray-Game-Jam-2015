using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

    public enum baseColorEnum
    {
        RED = 1,
        BLUE,
        YELLOW
    }

    public float movementSpeed;
    public float jumpSpeed;
    bool grounded = false;
    public Color baseColor;
    public Color curColor;
    public int PlayerNum;
    public baseColorEnum baseColorEn;
    

	// Use this for initialization
	void Start () {

        switch (baseColorEn)
        {
            case baseColorEnum.RED:
                baseColor = Color.red;
                break;
            case baseColorEnum.BLUE:
                baseColor = Color.blue;
                break;
            case baseColorEnum.YELLOW:
                baseColor = Color.yellow;
                break;
            default:
                break;
        }

        setColor();       
	
	}

    private void setColor()
    {
        GetComponent<Renderer>().material.color = baseColor;
        curColor = baseColor;

        GetComponentInChildren<AreaOfInfluence>().initColor(baseColor);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        if (Input.GetButtonDown("A"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
        }

        if (Input.GetButtonDown("B"))
        {
            if (!curColor.Equals(Color.red))
            {
                curColor = Color.red;
                updateColor();
            }            
        }

        if (Input.GetButtonDown("Y"))
        {
            if (!curColor.Equals(Color.yellow))
            {
                curColor = Color.yellow;
                updateColor();
            }  
        }

        if (Input.GetButtonDown("X"))
        {
            if (!curColor.Equals(Color.blue))
            {
                curColor = Color.blue;
                updateColor();
            }  
        }
	*/
	}

    public void updateColor()
    {
        GetComponent<Renderer>().material.color = curColor;
        GetComponentInChildren<AreaOfInfluence>().changeColor(curColor);
    }

}
