using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreatingBullet : MonoBehaviour
{
    public GameObject enemyBullet; //Düşman Mermi Objesi
    public Transform enemyBulletCreatingPoint; //Düşman Mermi Oluşma Noktası
    public float mermiHizi; //Mermi hızı katsayısı
    private float atesSayaci; //Mermi ateş zaman aralığı

    public Collider forceShieldCollider; //Bossun güç kalkanının collideri (Eğer false ise yani forceshield kapalıysa mermi atabilsin)

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = Random.Range(0.2f, 0.5f); //Mermi sayacına rastgele aralıkta sayı atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0 && forceShieldCollider.enabled == false) //Eğer player ölmemişse veya oyun durmamışsa veya güç kalkanı kapalıysa mermi atılır.
        {
            if (atesSayaci <= 0) //eğer sayac 0 dan küçükse
            {
                enemyFire(); //Mermi oluşturacak fonksiyon çağırılır.
                atesSayaci = Random.Range(0.2f, 0.5f); //Sayaca yeniden rastgele değer atanır
            }
            else //Eğer 0 dan büyükse
            {
                atesSayaci -= Time.deltaTime; //Sayaç azalır
            }
        }
    }

    void enemyFire()
    {
        if (transform.position.y >= -3) //Oyun platformunun altında orjinal düşman bulunduğu için belli bir y pozisyonunun üstünde olduğu durumlarda mermi atabilsin diye bu kontrol yapılır. Orjinal düşman mermi atamasın diye.
        {
            GameObject enemyOlusanMermi = Instantiate(enemyBullet, enemyBulletCreatingPoint.position,
                                                    enemyBulletCreatingPoint.rotation); //Mermi oluşturulur.
            Rigidbody enemyOlusanMermiRB = enemyOlusanMermi.GetComponent<Rigidbody>(); //Merminin rigidbody componenti alınır.

            enemyOlusanMermiRB.velocity = enemyOlusanMermi.transform.forward * mermiHizi * Time.fixedDeltaTime; //Rigidbody vasıtası ile mermiye hareket kazandırılır.
        }
    }
}
