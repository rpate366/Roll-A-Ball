using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    // rotation script, updates once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 30, 30) * Time.deltaTime);
    }
}
