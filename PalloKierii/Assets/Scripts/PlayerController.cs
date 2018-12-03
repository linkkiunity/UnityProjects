using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private bool koskeekoLattiaa;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        koskeekoLattiaa = true;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);


        // katsotaan onko space-nappi painettuna
        if (Input.GetKeyDown("space"))
        {

            if (koskeekoLattiaa)
            {
                //luodaan pystysuuntainen vektori, eli vain y:llä on arvo 
                Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);

                //lisätään vektori pelaaja-hahmolle 
                rb.AddForce(jump);
                koskeekoLattiaa = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // tarkistetaan koskeeko aarretta
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Lattia"))
        {
            koskeekoLattiaa = true;
        }
    }
}
