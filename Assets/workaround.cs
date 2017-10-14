using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workaround : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		//Just load something and catch the null exception with a default scene.
		Application.LoadLevel(1);
	}

	// Update is called once per frame
	void Update () {

	}
}
