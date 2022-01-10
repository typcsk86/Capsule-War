using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreatingBullet5 : MonoBehaviour
{
    public GameObject mermi; //Oluşturulacak mermi objesi
    public Transform mermiOlusmaNoktasi; //Merminin çıkacağı nokta
    public float mermiHizi;
    private int atesSayaci; //Ateş zaman aralığı

    //PlayerCreatingBullet.cs scriptinde kodlar açıklandığı için ve bu kodlar onun benzeri olduğundan
    //burada açıklanmadı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (atesSayaci <= 0 && Input.GetMouseButton(0))
            {
                atesEt();
                atesSayaci = 30;
            }

            if (atesSayaci > 0)
            {
                atesSayaci--;
            }
        }
    }

    void atesEt()
    {
        GameObject olusanMermi = Instantiate(mermi, mermiOlusmaNoktasi.position,
                                            mermiOlusmaNoktasi.rotation);
        Rigidbody olusanMermiRB = olusanMermi.GetComponent<Rigidbody>();

        olusanMermiRB.velocity = olusanMermi.transform.forward * mermiHizi * Time.fixedDeltaTime;
    }
}
