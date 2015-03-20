using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultipleControllerTest : MonoBehaviour
{

    
    public GameObject textObj;
    public Player player1;
    public Player player2;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (player1.isReady && player2.isReady)
	    {
            textObj.SetActive(true);
	    }

	}


}
