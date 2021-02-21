using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickForce : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spin;

    public Vector3 flingBrickSnyder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(flingBrickSnyder);

        spin = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));

        rb.AddTorque(spin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
