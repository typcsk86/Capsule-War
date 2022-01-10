using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreatingBullet : MonoBehaviour
{

    public GameObject mermi; //Oluşturulacak mermi objesi
    public Transform mermiOlusmaNoktasi; //Merminin çıkacağı nokta
    public float mermiHizi; //Mermi hız katsayısı
    private int atesSayaci; //Ateş zaman aralığı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = 50; //Playerin 1.silahının ateş etme aralığı 50 atanır
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeScale != 0) //eğer oyun durmamışsa ateş edilebilir
        {
            if(atesSayaci <= 0 && Input.GetMouseButton(0)) //Ateş sayacı 0 dan düşükse ve maus sol click basılıyorsa ateş eder
            {
                atesEt(); //ateş etme fonksiyonu çağırılır.
                atesSayaci = 50; //ateş zaman aralığı yeniden 50 atanır.
            }

            if(atesSayaci > 0) //Eğer büyükse azaltılır
            {
                atesSayaci--;
            }
        }
    }

    void atesEt()
    {
        GameObject olusanMermi = Instantiate(mermi, mermiOlusmaNoktasi.position,
                                            mermiOlusmaNoktasi.rotation); //Mermi objesi oluşturulur
        Rigidbody olusanMermiRB = olusanMermi.GetComponent<Rigidbody>(); //Mermi objesinin RigidBody componenti alınır.

        olusanMermiRB.velocity = olusanMermi.transform.forward * mermiHizi * Time.fixedDeltaTime; //Rigidbody ile mermiye hareket kazandırılır.
    }
}
