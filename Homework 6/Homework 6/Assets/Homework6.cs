using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Homework6 : MonoBehaviour {

	bool isPaused = false; 
	bool settings = false; 

	public Texture2D character1; 
	public Texture2D character2;
	public Texture2D character3; 
	public GUIContent content; 
	public Texture2D[] toolBarImages; 
	private int toolbarInt = 0;
	private float gameSpeed = 2.5f; 

	// Use this for initialization
	void Start () {
//		character1 = (Texture2D) Resources.Load ("character1.jpg");
//		character2 = (Texture2D) Resources.Load ("character2.jpg");
//		character3 = (Texture2D) Resources.Load ("character3.png");  
//		content.character1 = character1;
//		content.character2 = character2;
//		content.character3 = character3; 
	}

	void Awake () {
		toolBarImages = new Texture2D[] { character1, character2, character3 };
		DontDestroyOnLoad (transform.gameObject);
	}

	void OnGUI() {
		if (isPaused) {
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "Overwatch");

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 25), "Level 1")) {
				SceneManager.LoadScene ("Level1");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 25), "Level 2")) {
				SceneManager.LoadScene ("Level2");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 25), "Settings")){
				isPaused = false; 
				settings = true; 			
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 25), "Exit Game")){
				Application.Quit ();
			}
				
		}
		if (settings) {
			print ("heyheheyeye");
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "Settings");
			string[] toolbarStrings = {"Soldier 76", "Reaper", "D. Va"};
//			toolBarImages [0] = character1;
//			toolBarImages [1] = character2;
//			toolBarImages [2] = character3;
			toolbarInt = GUI.Toolbar (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 175, 200, 100), toolbarInt, toolBarImages);
//			GUILayout.Toolbar (toolbarInt, toolBarImages, "customGuiStyle");
			string characterName; 

			if (toolbarInt == 0) {
				characterName = "Soldier 76";
			} else if (toolbarInt == 1) {
				characterName = "Reaper"; 
			} else {
				characterName = "D.Va";
			}


			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 65, 200, 25), "Character: " + characterName);

			gameSpeed = GUI.HorizontalSlider (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 25), gameSpeed, 0.0f, 5.0f);
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 25), "Game Speed: " + gameSpeed / 5.0f);
		
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 25), "Exit to Main Menu")){
				settings = !settings;
				isPaused = !isPaused;
			}	
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !settings) {
			isPaused = !isPaused; 
		}
	}
}
