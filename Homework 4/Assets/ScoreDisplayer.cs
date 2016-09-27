using UnityEngine;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour {

	int score;
	GUIStyle guiStyle;
	bool guiStyleSetup=false;

	void OnGUI() 
	{
		if (guiStyleSetup == false) 
		{
			guiStyle = new GUIStyle (GUI.skin.label); 
			guiStyle.fontSize = 50;
			guiStyleSetup = true;
		}
		GUI.Label (new Rect (10, 10, 400, 400), "Score: " + score,guiStyle);
		GUI.color = Color.blue;
	}

	public void updateScore(int change)
	{
		score += change;
	}

	// Use this for initialization
	void Start ()
	{	
		score = 0;
	}

	// Update is called once per frame
	void Update () 
	{

	}
}