using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public Rigidbody rb;
    public int Speed;
    public int puan = 0;
    public int objeSayisi;

    public Text puanText;
    public Text oyunBittiText;

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
    
    void  OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        puan += 5;

        puanText.text = "Puan: " + puan;

        if (puan == objeSayisi)
        {
            oyunBittiText.gameObject.SetActive(true);
        }
    }
}
