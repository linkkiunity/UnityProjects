using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;	
	private Rigidbody rb;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}	
	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);	
		rb.AddForce(movement * speed);


		{
            if (Input.GetKeyDown ("space") ) {
                Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);
           
                rb.AddForce (jump);
            }
        }
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
        }
    }
}
