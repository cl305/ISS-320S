using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CubeOne : MonoBehaviour {

	Texture myTexture; 

	IEnumerator GetTextureWeb(){
		UnityWebRequest webTexture = UnityWebRequest.GetTexture("http://people.duke.edu/~djzielin/pics/dave_head2.jpg");
		yield return webTexture.Send();

		if(webTexture.isError){
			Debug.Log(webTexture.error);
		}
		else{
			myTexture = ((DownloadHandlerTexture)webTexture.downloadHandler).texture;
			GetComponent<Renderer> ().material.mainTexture = myTexture; 
		}
	}

	// Use this for initialization
	void Start () {
			StartCoroutine(GetTextureWeb());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
