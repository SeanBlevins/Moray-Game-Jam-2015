using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    
    public Image Player1;
    public Image Player2;
    public Image Player3;

    public bool ready1 = false;
    public bool ready2 = false;
    public bool ready3 = false;
    
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyDown("insert"))
	    {
            ready1 = !ready1;
            Player1.color = ready1 ? platform.dictionaryColour[platform.activateColorEnum.RED] : Color.white;
	    }
        if (Input.GetKeyDown("home"))
        {
            ready2 = !ready2;
            Player2.color = ready2 ? platform.dictionaryColour[platform.activateColorEnum.BLUE] : Color.white;
        }
        if (Input.GetKeyDown("page up"))
        {
            ready3 = !ready3;
            Player3.color = ready3 ? platform.dictionaryColour[platform.activateColorEnum.YELLOW] : Color.white;
        }

	    if (ready1 && ready2 && ready3)
	    {
	        //LOAD GAME
	        Application.LoadLevel(2);
	    }
    }
}
