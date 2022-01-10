using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreatingBullet2 : MonoBehaviour
{
    public GameObject mermi; //Oluşturulacak mermi objesi
    public Transform mermiOlusmaNoktasi1; //Merminin çıkacağı nokta
    public Transform mermiOlusmaNoktasi2; //Merminin çıkacağı nokta
    public Transform mermiOlusmaNoktasi3; //Merminin çıkacağı nokta
    public float mermiHizi;
    private int atesSayaci; //Ateş zaman aralığı

    //PlayerCreatingBullet.cs scriptinde kodlar açıklandığı için ve bu kodlar onun benzeri olduğundan
    //Burada açıklanmadı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (atesSayaci <= 0 && Input.GetMouseButton(0))
            {
                atesEt();
                atesSayaci = 50;
            }

            if (atesSayaci > 0)
            {
                atesSayaci--;
            }
        }
    }

    void atesEt()
    {
        GameObject olusanMermi1 = Instantiate(mermi, mermiOlusmaNoktasi1.position, mermiOlusmaNoktasi1.rotation);
        GameObject olusanMermi2 = Instantiate(mermi, mermiOlusmaNoktasi2.position, mermiOlusmaNoktasi2.rotation);
        GameObject olusanMermi3 = Instantiate(mermi, mermiOlusmaNoktasi3.position, mermiOlusmaNoktasi3.rotation);
        Rigidbody olusanMermi1RB = olusanMermi1.GetComponent<Rigidbody>();
        Rigidbody olusanMermi2RB = olusanMermi2.GetComponent<Rigidbody>();
        Rigidbody olusanMermi3RB = olusanMermi3.GetComponent<Rigidbody>();
        olusanMermi1RB.velocity = olusanMermi1.transform.forward * mermiHizi * Time.fixedDeltaTime;
        olusanMermi2RB.velocity = olusanMermi2.transform.forward * mermiHizi * Time.fixedDeltaTime;
        olusanMermi3RB.velocity = olusanMermi3.transform.forward * mermiHizi * Time.fixedDeltaTime;
    }
}
