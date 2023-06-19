using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    public Rigidbody rb;
    Button btn;
    public int Speed;
    public float jumpSpeed;

    public int puan = 0;
    public int objeSayisi;

    public Text puanText;
    public Text oyunBittiText;

    public Button QuitButton;
    public Button MenuButton;
    public Button StartButton;

    bool kontrol = false;

    [SerializeField] private AudioSource point;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(StartBtn);
    }

    void FixedUpdate()
    {
        if (kontrol == true)
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
    }
    
    void  OnTriggerEnter(Collider other)
    {
        if (kontrol == true)
        {
            other.gameObject.SetActive(false);
            puan += 5;

            puanText.text = "Puan: " + puan;
            point.Play();

            if (puan == objeSayisi)
            {
                oyunBittiText.gameObject.SetActive(true);
                MenuButton.gameObject.SetActive(true);
                QuitButton.gameObject.SetActive(true);
            }
        }

    }

    public void StartBtn()
    {
        kontrol = true;
        StartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitBtn()
    {
        Debug.Log("Oyundan Çıkılıyor..");
        Application.Quit();
    }
}
