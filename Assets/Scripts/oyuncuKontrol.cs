using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyuncuKontrol : MonoBehaviour
{
    float yatay;
    float dikey;
    public float hiz = 10f;
    int skor = 0;
    Rigidbody rb; // rb deðiþkeni sahnedeki oyuncunun RigidBody bileþenini temsil eder

    //text deðiþkenler
   public Text skorTxt;
    public Text uyariTxt;
    public Text tebrikTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("sahne baþladý");
        rb = GetComponent<Rigidbody>(); //rb sahnedeki RigidBody'e baðlandý..Referans.

    }
    
    private void FixedUpdate()
    {
        //if(Application.platform==RuntimePlatform.Android)
        //{
        //    yatay = Input.acceleration.x;
        //    dikey = Input.acceleration.y;
        //    Input.gyro
        //}
        if (hiz < 1)
            hiz = 10;
        //kullanýcýdan yön bilgisi alýnacak: input / getAxis
        //iki yön belirlenecek ve bunlarý +/- þekilde yazýlacak
        // yatay- dikey
        yatay = Input.GetAxis("Horizontal");
        dikey = Input.GetAxis("Vertical");


        //kuvvet vektörü oluþturulacak: Vector3 xhiz
        Vector3 kuvvet = new Vector3(yatay, 0f, dikey);

        //oluþturulan kuvvet oyuncuya (rigidbody) uygulanacak
        rb.AddForce(kuvvet * hiz);
    }

    //oyuncu elmaslardan herhangi birine dokunduðunda destroy edecek
    private void OnTriggerEnter(Collider other)
    {
        //silinecek nesnelerin isTrigger özelliði True olmalý
        // burada elmaslarýn isTrigger özelliði True yapýldý
        if (other.CompareTag("sonElmas") && skor == 90)
        {
            Destroy(other.gameObject);
            skor += 10;
            skorTxt.text = "Skor:" + skor.ToString();
            //tebrik mesajý yazdýr (UI Text) 3sn bekleyecek ve sonraki sahneye geçiþ yap
            tebrikTxt.text = "Tebrikler..Seviye tamamlandý!";
            StartCoroutine(tebrikBeklet());
        }
        else if (other.CompareTag("tumElmaslar"))
        {
            Destroy(other.gameObject); //nesneyi sahneden siler
                                       // other.gameObject.SetActive(false); //nesneyi gizler
            skor += 10;
            skorTxt.text = "Skor:" + skor.ToString();

        }
        else
        {
            //uyarý mesajý gelecek 3sn bekleyecek ve gizlenecek
            uyariTxt.text = "Bu elmas en son toplanacak!";
            //3sn bekle ve temizle
            StartCoroutine(uyariBeklet());

        }
    }
    IEnumerator tebrikBeklet()
    {
        yield return new WaitForSeconds(3.1f);
        //sonraki sahneye geçiþ!
        SceneManager.LoadScene("cikisSahnesi");
    }
  IEnumerator  uyariBeklet()
    {
        yield return new WaitForSeconds(3f);
        uyariTxt.text = "";
    }
    //private void OnCollisionEnter(Collision collision) //isTrigger kapalý
    //{
    //    if (collision.gameObject.CompareTag("tumElmaslar"))
    //    {
    //        Destroy(collision.gameObject);

    //    }
    //    Debug.Log("Çaprma koordinatý:" + collision.contacts[0].point);
    //}
}
