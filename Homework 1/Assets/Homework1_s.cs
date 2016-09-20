using UnityEngine;
using System.Collections;

public class Homework1_s : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float playerHealth = 100; 
		bool playerDamaged = true; 

		if(playerDamaged){
			playerHealth = playerHealth / 2; 
			print("playerHealth now: " + playerHealth); 
		}

		int powerUpAmount = 50;
		print ("powerUpAmount now: " + powerUpAmount); 

		bool isDangerZone = playerHealth < 20; 
		print ("isDangerZone now: " + isDangerZone);

		playerHealth++; 
		playerHealth += 1;
		playerHealth = playerHealth + 1; 

		print ("playerHealth now: " + playerHealth); 

		int playerHealthInt = (int)playerHealth; 
		print ("playerHealth now: " + playerHealthInt); 

		print ("playerHealth mod: " + playerHealth % 2); 


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
