using UnityEngine;
using System.Collections;

public class EggScript : MonoBehaviour {

    void Awake()
    {
        //rigidbody.AddForce(new Vector3(0, -100, 0), ForceMode.Force);
    }

    //Update is called by Unity every frame
	void Update () {
        
		switch(gameObject.tag)
		{
			case "basicEgg":
				break; 
			case "goldEgg":
				break;
			case "rock":
				break;
			default:
				break;
		}

		float fallSpeed = 2 * Time.deltaTime;
        transform.position -= new Vector3(0, fallSpeed, 0);

        if (transform.position.y < -1 || transform.position.y >= 20)
        {
            //Destroy this gameobject (and all attached components)
            Destroy(gameObject);
        }
	}
}
