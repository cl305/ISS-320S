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

	public int toolbarInt = 0;
	// Use this for initialization
	void Start () {
		character1 = (Texture2D) Resources.Load ("character1.jpg");
		character2 = (Texture2D) Resources.Load ("character2.jpg");
		character3 = (Texture2D) Resources.Load ("character3.png"); 
//		content.character1 = character1;
//		content.character2 = character2;
//		content.character3 = character3; 
	}

	void Awake () {
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
				print("hohohoho");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 25), "Exit Game")){
				Application.Quit ();
			}
				
		}
		if (settings) {
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "Settings");
			string[] toolbarStrings = {"Soldier 76", "Reaper", "D. Va"};

			toolbarInt = GUI.Toolbar (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 25), toolbarInt, toolbarStrings);

			string characterName; 

			if (toolbarInt == 0) {
				characterName = "Soldier 76";
			} else if (toolbarInt == 1) {
				characterName = "Reaper"; 
			} else {
				characterName = "D.Va";
			}


			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 25), "Character: " + characterName);

		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !settings) {
			isPaused = !isPaused; 
		}
	}
}
