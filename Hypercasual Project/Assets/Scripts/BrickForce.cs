using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickForce : MonoBehaviour
{
    private Rigidbody rb;

    public Vector3 flingBrickSnyder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(flingBrickSnyder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
