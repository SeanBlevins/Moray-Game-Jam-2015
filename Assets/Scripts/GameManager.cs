using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public enum GameState { wait, rotate, check }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null; 
    public event OnStateChangeHandler OnStateChange;
	//public GameState gameState { get; private set; }
    protected GameManager() { }

    public List<character> characters = new List<character>();
    //ArrayList colors = new ArrayList();
    public List<Color> colors = new List<Color>();
    Color groupColor;

    public enum PrimaryColors
    {
        Red = 1,
        Blue,
        Green
    }

    // Singleton pattern implementation
    public static GameManager Instance
    {
        get
        {
            _instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {                	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addToGroup(character ch)
    {
        //print("Color Mix " + ch);
        characters.Add(ch);
        //print("Color     " + ch.baseColor);
        colors.Add(ch.baseColor);
        //print("Col Count      " + colors.Count);
        //print("Char Count     " + characters.Count);
        if (colors.Contains(Color.red))
        {
            //print("Color red");
        }
        if (colors.Contains(Color.blue))
        {
            //print("Color blue");
        }
        if (colors.Contains(Color.red) && colors.Contains(Color.blue))
        {
            //print("Color red and blue");
        }
        updateCharacters();
    }

    public void removeFromGroup(character ch)
    {
        ch.curColor = ch.baseColor;
        ch.updateColor();

        print("Remove: " + ch.baseColor);
        characters.Remove(ch);
        colors.Remove(ch.baseColor);
        updateCharacters();
    }

    public void updateCharacters()
    {
        //print("Col Count      " + colors.Count);
        //print("Char Count     " + characters.Count);
        foreach (var color in colors)
        {
            //print(color);
            if (color.Equals(Color.yellow))
            {
                //print("Yellow");
            }
            else if (color.Equals(Color.blue))
            {
                //print("Blue");
            }
            else if (color.Equals(Color.red))
            {
                //print("Red");
            }
        }
        if(characters.Count == 3)
        {
            groupColor = Color.white;
        }
        else
        {
            if(colors.Contains(Color.red) && colors.Contains(Color.blue))
            {
                //Purple - new Color(0.7f, 0f, 1f, 1f);
                groupColor = new Color(0.7f, 0f, 1f, 1f);
            }
            else if (colors.Contains(Color.red) && colors.Contains(Color.yellow))
            {
                //Orange - new Color(1f, 0.65f, 0f, 1f);
                groupColor = new Color(1f, 0.65f, 0f, 1f);
            }
            else
            {
                //Green
                groupColor = Color.green;
            }

        }

        foreach (var character in characters)
        {            
            character.curColor = groupColor;
            character.updateColor();
        }
    }
}
