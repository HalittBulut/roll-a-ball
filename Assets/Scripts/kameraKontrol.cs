using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    Vector3 fark;
   public GameObject oyuncu;
    // Start is called before the first frame update
    void Start()
    {
       //fark=kamera konumu - oyuncu konumu
      fark= transform.position-oyuncu.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //kameranýn konumu=oyuncu konumu+fark
        transform.position = oyuncu.transform.position + fark;
    }
}
