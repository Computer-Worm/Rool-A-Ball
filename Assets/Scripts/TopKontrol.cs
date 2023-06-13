using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    public Rigidbody rb;
    public int Speed;
    public float jumpSpeed;

    public int puan = 0;
    public int objeSayisi;

    public Text puanText;
    public Text oyunBittiText;

    public Button RestartButton;

    [SerializeField] private AudioSource point;

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

        if (transform.position.y < 3.20)
        {
            //Debug.Log("Sınır Aşıldı..");    

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }


    }
    
    void  OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        puan += 5;

        puanText.text = "Puan: " + puan;
        point.Play();

        if (puan == objeSayisi)
        {
            oyunBittiText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
        }
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
