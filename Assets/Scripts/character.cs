using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

    public enum baseColorEnum
    {
        RED = 1,
        BLUE,
        YELLOW
    }

    public Color baseColor;
    public Color curColor;
    public int PlayerNum;
    public baseColorEnum baseColorEn;
    private SpriteRenderer[] childSprites;

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
	    childSprites = GetComponentsInChildren<SpriteRenderer>();
	}

    private void setColor()
    {
        //GetComponent<Renderer>().material.color = baseColor;
        curColor = baseColor;

        GetComponentInChildren<AreaOfInfluence>().initColor(baseColor);
    }

    private bool isRight = false;
	// Update is called once per frame
    void FixedUpdate()
    {

        float rotation = childSprites[0].transform.rotation.y; ;
	    float input = Input.GetAxis("Player" + PlayerNum + "Horizontal");
	    print(input);
        if (input > 0f)
        {
            isRight = true;
        }
        else if (input < 0f)
        {
            isRight = false;
        }
	    foreach (SpriteRenderer sprite in childSprites)
	    {

	        sprite.transform.rotation = isRight ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
	    }
	}

    public void updateColor()
    {
        //GetComponent<Renderer>().material.color = curColor;
        GetComponentInChildren<AreaOfInfluence>().changeColor(curColor);
    }

}
