using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4TurretCreatingBullet : MonoBehaviour
{
    public Transform target; //Hedefin transformu

    public GameObject turretBullet; //Turret Mermi Objesi
    public Transform turretBulletCreatingPoint; //Turret Mermi Oluşma Noktası
    public float mermiHizi; //Turret Mermi hızı
    private float atesSayaci; //Mermi ateş zaman aralığı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = Random.Range(0.2f, 0.5f); //Ateş zaman aralığına rastgele değer atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer oyun durmamışsa veya player ölmemişse turret ateş eder.
        {
            //Silahı sürekli olarak player'e çevirmek için
            transform.LookAt(target);

            if (atesSayaci <= 0) //Ateş sayacı 0 dan küçükse kontrolü
            {
                turretFire(); //Ateş etme fonksiyonu çağırılır.
                atesSayaci = Random.Range(0.2f, 0.5f); //Yeniden ateş sayacına rastgele değer atanır.
            }
            else //ateş sayacı 0 dan büyükse saniye azalır.
            {
                atesSayaci -= Time.deltaTime;
            }
        }
    }

    void turretFire()
    {
        GameObject enemyOlusanMermi = Instantiate(turretBullet, turretBulletCreatingPoint.position,
                                                    turretBulletCreatingPoint.rotation); //Oluşan mermi objesi
        Rigidbody enemyOlusanMermiRB = enemyOlusanMermi.GetComponent<Rigidbody>(); //Merminin rigidbody componenti alınır.

        enemyOlusanMermiRB.velocity = enemyOlusanMermi.transform.forward * mermiHizi * Time.fixedDeltaTime; //Rigidbody componenti ile mermiye hareket kazandırılır.
    }
}
