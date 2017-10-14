using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScene() {
		string name = gameObject.name;
		if (name == "Egg") {
			SceneManager.LoadScene (1);
		} else if (name == "Jump") {
			SceneManager.LoadScene (2);
		} else if (name == "Marble") {
			SceneManager.LoadScene (3);
		}
	}
}
