using UnityEngine;
using System.Collections;

public class CactusClicker : MonoBehaviour {

	public GameObject cactus1;
	public GameObject cactus2; 
	public GameObject cactus3;
	public GameObject scoreObject;
	public ScoreDisplayer updater; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
		
	}

	void OnMouseDown () {
		print ("clicked");
		int randNum = Random.Range (0, 3);
		Debug.Log (randNum);
		GameObject cactusCopy; 
		if (randNum == 0) {
			cactusCopy = Instantiate (cactus1);
		} else if (randNum == 1) {
			cactusCopy = Instantiate (cactus2); 
		} else {
			cactusCopy = Instantiate (cactus3); 
		}

		float x = Random.Range (-15.0f, 15.0f);
		float z = Random.Range (-15.0f, 15.0f);

		cactusCopy.transform.position = new Vector3 (x, 0.0f, z); 
		updater = (ScoreDisplayer)scoreObject.GetComponent (typeof(ScoreDisplayer));
		updater.updateScore (1);
	}

}
