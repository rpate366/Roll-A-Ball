using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody rb;
    public float speedController = 10;
    private int score;
    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialize();
    }

    public GameObject cubePreFab;
    public GameObject capsulePreFab;
    public GameObject cylinderPreFab;

    void initialize()
    {
        Instantiate(cubePreFab, new Vector3(-3, 1, -3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(3, 1, -3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(-3, 1, 3), Quaternion.identity);
        Instantiate(cubePreFab, new Vector3(3, 1, 3), Quaternion.identity);

        Instantiate(capsulePreFab, new Vector3(0, 1, -5), Quaternion.identity);
        Instantiate(capsulePreFab, new Vector3(0, 1, 5), Quaternion.identity);

        Instantiate(cylinderPreFab, new Vector3(-5, 1, 0), Quaternion.identity);
        Instantiate(cylinderPreFab, new Vector3(5, 1, 0), Quaternion.identity);

        score = 0;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speedController);

    }

    void OnTriggerEnter(Collider obj)
    {
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

            if (score == 14)
            {
                reset();
            }
        }
    }

    void reset()
    {
        Invoke("initialize", 3);
    }
}
