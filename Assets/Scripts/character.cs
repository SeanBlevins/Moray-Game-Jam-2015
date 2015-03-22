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

	}

    public void updateColor()
    {
        GetComponent<Renderer>().material.color = curColor;
        GetComponentInChildren<AreaOfInfluence>().changeColor(curColor);
    }

}
