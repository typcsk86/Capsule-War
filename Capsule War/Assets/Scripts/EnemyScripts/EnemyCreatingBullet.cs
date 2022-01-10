using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatingBullet : MonoBehaviour
{
    public GameObject enemyBullet; //Düşman Mermi Objesi
    public Transform enemyBulletCreatingPoint; //Düşman Mermi Oluşma Noktası
    public float mermiHizi; //Mermi hızı katsayısı
    private float atesSayaci; //Mermi ateş aralığı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = Random.Range(0.2f, 0.5f); //Ateş aralığına rastgele değer atanır
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer oyun durdurulmamışsa veya player ölmemişse mermi atsın kontrolü
        {
            if (atesSayaci <= 0) //eğer sayaç 0 dan küçükse kontrolü
            {
                enemyFire(); //Mermi oluşturma fonksiyonu çağırılır.
                atesSayaci = Random.Range(0.2f, 0.5f); //Sayaca yeniden rastgele değer atanır
            }
            else //Eğer 0 dan büyükse sayaç azalır.
            {
                atesSayaci -= Time.deltaTime;
            }
        }
    }

    void enemyFire()
    {
        if (transform.position.y >= -3) //Düşman belli bir y pozisyonunun üstündeyse mermi atabilir.
        {
            GameObject enemyOlusanMermi = Instantiate(enemyBullet, enemyBulletCreatingPoint.position,
                                                    enemyBulletCreatingPoint.rotation); //Mermi oluşturulur.
            Rigidbody enemyOlusanMermiRB = enemyOlusanMermi.GetComponent<Rigidbody>(); //Rigidbody componenti alınır.

            enemyOlusanMermiRB.velocity = enemyOlusanMermi.transform.forward * mermiHizi * Time.fixedDeltaTime; //Mermiye hareket kazandırılır.
        }
    }
}
