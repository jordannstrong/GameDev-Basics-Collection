using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    
    public int theScore = 0;
	public float time = 60.0f;
	public bool timeOut = false;
	public bool win = false;

	void Update () {
		
        //These two lines are all there is to the actual movement..
        float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * 3; 
        transform.position -= new Vector3(moveInput, 0, 0);

        //Restrict movement between two values
        if (transform.position.x <= -5.5f || transform.position.x >= 5.5f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -5.5f, 5.5f); //Clamp between min -2.5 and max 2.5
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

		if (theScore < 0) 
		{
			theScore = 0;
		}

		if (time <= 0) {
			Time.timeScale = 0;
			if (theScore >= 50) {	
				win = true;
			}
			timeOut = true;
		} else {
			time -= Time.deltaTime;
		}
			
	}

    //OnGUI is called multiple times per frame. Use this for GUI stuff only!
    void OnGUI()
    {
        //We display the game GUI from the playerscript
        //It would be nicer to have a seperate script dedicated to the GUI though...
		if (timeOut == false) {
			GUILayout.Label ("Score: " + theScore);

			GUILayout.Label ("Time: " + (int)time);
		} else {
			if (win == false) {
				GUILayout.Label ("You lose!");
			} else {
				GUILayout.Label ("You win!");
			}
		}

    }    
}
