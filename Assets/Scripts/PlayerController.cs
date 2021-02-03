using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{   
    //player
    private Rigidbody rb;
    //essentially speed, higher = faster, lower = slower
    public float speedController = 10;

    private int score;
    public Text scoreText;

    void Start()
    {
        //rb is essentially the player
        rb = GetComponent<Rigidbody>();

        //setting up the pick up objects
        initialize();
    }

    //different prefabs
    public GameObject cubePreFab;
    public GameObject capsulePreFab;
    public GameObject cylinderPreFab;

    void initialize()
    {   
        //Game object setup
        Instantiate(cubePreFab, new Vector3(-3, 1, -3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(3, 1, -3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(-3, 1, 3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(3, 1, 3), Quaternion.identity);

        Instantiate(capsulePreFab, new Vector3(0, 1, -5), Quaternion.identity);
        Instantiate(capsulePreFab, new Vector3(0, 1, 5), Quaternion.identity);

        Instantiate(cylinderPreFab, new Vector3(-5, 1, 0), Quaternion.identity);
        Instantiate(cylinderPreFab, new Vector3(5, 1, 0), Quaternion.identity);

        //score text setup
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        //adding forces to player off inputs from wasd or arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speedController);

    }

    void OnTriggerEnter(Collider obj)
    {
        //checking what player collided with, different collisions warrant different scores
        if (obj.gameObject.tag == "Capsule" || obj.gameObject.tag == "Cylinder" || obj.gameObject.tag == "Cube")
        {
            Destroy(obj.gameObject);

            if (obj.gameObject.CompareTag("Capsule"))
            {
                score += 3;
            } else if (obj.gameObject.CompareTag("Cylinder"))
            {
                score += 2;
            } else if (obj.gameObject.CompareTag("Cube"))
            {
                score += 1;
            }

            scoreText.text = "Score: " + score;
            
            //reset if all pickups are picked up, which is also when score = 14
            if (score == 14)
            {
                reset();
            }
        }
    }

    void reset()
    {   
        //Invoke waits for given time in seconds, then calls method
        Invoke("initialize", 3);
    }
}
