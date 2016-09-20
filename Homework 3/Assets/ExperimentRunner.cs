using UnityEngine;
using System.Collections;

public class ExperimentRunner : MonoBehaviour 
{
	public string experimentDataFile="experiment.csv";

	public GameObject stimulus1; //loaded these up either via editor gui, or via GameObject.Find
	public GameObject stimulus2;
	public GameObject stimulus3; 
	public GameObject currentStimulus; //help use keep reference to what we are currently showing

	string objectName; //these describe the current stimulus, use these!
	string displayTime;
	string allowUserInput;

	string[] allExperimentLines; //for CSV file
	int experimentLineIndex=-1;

	float rotationPerSecond = 10.0f; 

	void loadCSV()
	{
		//put experiment.csv file in /Assets/StreamingAssets
		string fname = Application.streamingAssetsPath + "/" + experimentDataFile;

		string text = System.IO.File.ReadAllText (fname);

		char[] delimiterNewLine = { '\n' };
		allExperimentLines = text.Split (delimiterNewLine);
	}

	void getNextExperimentRow()
	{
		experimentLineIndex = (experimentLineIndex + 1) % allExperimentLines.Length; //increment and loop to begining if needed
		string currentRow = allExperimentLines [experimentLineIndex];

		char[] delimiterComma = { ',' };		

		currentRow=currentRow.Replace("\n",""); //some data cleaning
		currentRow=currentRow.Replace("\r",""); //should be \r and not \\r
		currentRow=currentRow.Replace(" ",  ""); //remove any spaces

		//this needs to happen after data cleaning
		string[] vals=currentRow.Split(delimiterComma); //split current line out, based on comma locations

		objectName =     vals [0];
		displayTime =    vals [1];
		allowUserInput = vals [2];

		Debug.Log ("loaded experiment row: " + objectName + " " + displayTime + " " + allowUserInput);
	}

	float timeLimit;

	//GOAL 1: setup world based on CSV values 
	void setupStimulus()
	{
		getNextExperimentRow(); 

		//TODO: turn off all stimulus
		stimulus1.SetActive (false);
		stimulus2.SetActive (false);
		stimulus3.SetActive (false);

		//TODO: use if statements to turn on required stimulus (examine objectName)
		if (objectName == "stimulus1") {
			stimulus1.SetActive (true);
			stimulus2.SetActive (false);
			stimulus3.SetActive (false); 
			currentStimulus = stimulus1;
		} else if (objectName == "stimulus2") {
			stimulus1.SetActive (false);
			stimulus2.SetActive (true);
			stimulus3.SetActive (false); 
			currentStimulus = stimulus2;
		} else if (objectName == "stimulus3") {
			stimulus1.SetActive (false);
			stimulus2.SetActive (false);
			stimulus3.SetActive (true); 
			currentStimulus = stimulus3; 
		}

		//TODO: use if statements (or combine with above) to assign currentStimulus (examine objectName)


		//TODO: setup timeLimit using value from csv file (displayTime, utilize a parse to get it to a float!)
		timeLimit = float.Parse(displayTime); 
	}

	// Use this for initialization
	void Start ()
	{   
		//TODO: if using GameObject.find technique, setup object references here
		stimulus1 = GameObject.Find ("bucket");
		stimulus2 = GameObject.Find ("tree");
		stimulus3 = GameObject.Find ("car"); 

		loadCSV ();
		setupStimulus (); //start off with the first stimulus
	}

	float timeElapsed=0.0f;

	// Update is called once per frame
	void Update () 
	{
		//GOAL 2: move to next stimulus when it's time
		//
		//increment timeElapsed using Time.deltaTime
		//check if timeElasped exceeds timeLimit
		//if yes, reset timeElapsed + call setupStimulus() to move to next stimulus
		timeElapsed += Time.deltaTime; 
		if (timeElapsed >= timeLimit) {
			timeElapsed = 0.0f;
			setupStimulus();
		}


		//GOAL 3: allow user to manipulate object (if allowed)
		//
		//check if interaction is allowed (examine allowUserInput)
		//if yes, allow rotate currentObject based on keys pressed
		if(allowUserInput == "true"){
			if (Input.GetKey ("left")) {
				transform.Rotate (0, rotationPerSecond * Time.deltaTime, 0); 
			} else if (Input.GetKey ("right")) {
				transform.Rotate (0, -1 * rotationPerSecond * Time.deltaTime, 0); 
			} else if (Input.GetKey ("up")) {
				transform.Rotate (rotationPerSecond * Time.deltaTime, 0, 0);
			} else if (Input.GetKey ("down")) {
				transform.Rotate (-1 * rotationPerSecond * Time.deltaTime, 0, 0);
			}
		}
	}
}