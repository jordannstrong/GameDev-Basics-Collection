using UnityEngine;
using System.Collections;

public class MarbleControl : MonoBehaviour
{

    public float movementSpeed = 6.0f;
    public bool isGrounded = true;


    void Update()
    {
        Vector3 movement = (Input.GetAxis("Horizontal") * Camera.main.transform.right * movementSpeed) + (Input.GetAxis("Vertical") * Camera.main.transform.forward * movementSpeed);
        movement *= Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(movement, ForceMode.Force);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0), ForceMode.Force);
            isGrounded = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            MarbleGameManager.SP.FoundGem();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "platform")
        {
            isGrounded = true;
            Debug.Log("hit2");
        }
    }

}