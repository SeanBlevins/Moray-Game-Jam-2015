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

    public ArrayList characters = new ArrayList();
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

        print("Remove");
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
            //print("Color     " + color);
        }
        if(characters.Count == 3)
        {
            groupColor = Color.white;
        }
        else
        {
            if(colors.Contains(Color.red) && colors.Contains(Color.blue))
            {
                //Purple
                groupColor = Color.magenta;
            }
            else if (colors.Contains(Color.red) && colors.Contains(Color.yellow))
            {
                //Orange
                groupColor = Color.cyan;
            }
            else
            {
                //Green
                groupColor = Color.green;
            }

        }

        foreach (var item in characters)
        {
            character character = (character)item;
            character.curColor = groupColor;
            character.updateColor();
        }
    }
}
