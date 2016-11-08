using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CubeTwo : MonoBehaviour {

	Texture myTexture; 

	IEnumerator GetTextureWeb(){
		UnityWebRequest webTexture = UnityWebRequest.GetTexture("http://www.telegraph.co.uk/content/dam/news/2016/05/29/99356270_Harambe_a_17-year-old_gorilla-NEWS-large_trans++qVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg");
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
