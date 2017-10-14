using UnityEngine;
using System.Collections;

public class EggCollider : MonoBehaviour {

	PlayerScript myPlayerScript;
	public float powerupTime = 0.0f;
	public bool powerupActive = false;

    //Automatically run when a scene starts
    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<PlayerScript>();
    }

    //Triggered by Unity's Physics
	void OnTriggerEnter(Collider theCollision)
    {
        //Check what object is being hit
        
		GameObject collisionGO = theCollision.gameObject;

		switch(collisionGO.tag)
		{
			case "basicEgg":
				myPlayerScript.theScore++;
				break; 
			case "goldEgg":
				myPlayerScript.theScore += 5; 
				break;
			case "rock":
				myPlayerScript.theScore -= 5;
				break;
			case "timeEgg":
				myPlayerScript.time += 10;
				break;
			case "bigEgg":
				powerupTime = Time.time + 5.0f;
				powerupActive = true;
				GameObject.Find("bucket").transform.localScale += new Vector3(0.05f, 0, 0.05f);
				break;
			default:
				break;
		}

		Destroy(collisionGO);

    }

	void Update()
	{
		if (powerupTime < Time.time)
		{
			GameObject.Find("bucket").transform.localScale = new Vector3(0.1045929f, 0.02398696f, 0.1045928f);
			powerupActive = false;
		}
	}
}
