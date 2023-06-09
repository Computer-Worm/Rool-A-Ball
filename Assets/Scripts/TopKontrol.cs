using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public Rigidbody rb;
    public int Speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float yatayEksen = Input.GetAxis("Horizontal");
        float dikeyEksen = Input.GetAxis("Vertical");

        Vector3 vektor = new Vector3(yatayEksen, 0, dikeyEksen);

        rb.AddForce(vektor * Speed);

    }
}
