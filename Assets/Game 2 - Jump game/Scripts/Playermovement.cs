using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
	enum doubleJumpStates {None, First, Second};

    public float movementSpeed = 5.0f;
    private bool isGrounded = true;
	public static bool doubleJump = false;
	private int jumpState = 0;

    void Update() 
	{	
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0); //Set X and Z velocity to 0
 
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);

		if (Input.GetButtonDown("Jump") && (isGrounded || jumpState < 2 && doubleJump == true))
        {
            //Jump(); //Manual jumping
			if (doubleJump == false) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 700, 0), ForceMode.Force); 
				isGrounded = false;
			} else if (floatJump == true) {
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 700, 0), ForceMode.Force);
				isGrounded = false;
			}
			else if(doubleJump == true && jumpState == 0){
				GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0), ForceMode.Force); 
				jumpState = 1;
			}
			else if(doubleJump == true && jumpState == 1){
				GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0), ForceMode.Force); 
				jumpState = 2;
			}

        }
	}

    void Jump()
    {
        if (!isGrounded) {return;}
        isGrounded = false;
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0), ForceMode.Force); 
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "platform") {
			isGrounded = true; 
			jumpState = 0;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "platform") {
			isGrounded = false; 
			jumpState = 1;
		}
	}

    /*void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, - Vector3.up, 1.0f);

        if (isGrounded)
        {
            Jump(); //Automatic jumping
        }
    }*/
       

}
