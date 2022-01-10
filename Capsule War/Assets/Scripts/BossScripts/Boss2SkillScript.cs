using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2SkillScript : MonoBehaviour
{
    public GameObject boss2Bullet; //Düşman Boss2 Oluşan Mermi
    public Transform enemyBulletCreatingPoint1; //Düşman Boss2 Mermi Oluşma Noktası 1
    public Transform enemyBulletCreatingPoint2; //Düşman Boss2 Mermi Oluşma Noktası 2
    public Transform enemyBulletCreatingPoint3; //Düşman Boss2 Mermi Oluşma Noktası 3
    public float mermiHizi; //Mermi dikeninin hızını belirleyen katsayı
    private float atesSayaci; //Merminin (Diken) atış sayacı

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = Random.Range(0.2f, 0.5f); //Sayaca başlangıçta 0.2f ve 0.5f arasında rastgele değer atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer player ölmediyse veya oyun durdurulmadıysa mermi atması için eklenen kontrol.
        {
            if (atesSayaci <= 0) //Ateş sayacı 0 dan düşükse ateş eder
            {
                enemyFire(); //Ateş etme fonksiyonu çağırılır.
                atesSayaci = Random.Range(0.2f, 0.5f); //Ateş sayacına yeni rastgele değer atanır.
            }
            else //0 dan büyükse ateş sayacı azalır.
            {
                atesSayaci -= Time.deltaTime;
            }
        }
    }

    void enemyFire()
    {
        if (transform.position.y >= -3)
        {
            GameObject enemyOlusanMermi1 = Instantiate(boss2Bullet, enemyBulletCreatingPoint1.position, enemyBulletCreatingPoint1.rotation); //Mermi oluşturulur.
            GameObject enemyOlusanMermi2 = Instantiate(boss2Bullet, enemyBulletCreatingPoint2.position, enemyBulletCreatingPoint2.rotation); //Mermi oluşturulur.
            GameObject enemyOlusanMermi3 = Instantiate(boss2Bullet, enemyBulletCreatingPoint3.position, enemyBulletCreatingPoint3.rotation); //Mermi oluşturulur.

            Rigidbody enemyOlusanMermiRB1 = enemyOlusanMermi1.GetComponent<Rigidbody>(); //Merminin rigidbody componenti alınır.
            Rigidbody enemyOlusanMermiRB2 = enemyOlusanMermi2.GetComponent<Rigidbody>(); //Merminin rigidbody componenti alınır.
            Rigidbody enemyOlusanMermiRB3 = enemyOlusanMermi3.GetComponent<Rigidbody>(); //Merminin rigidbody componenti alınır.

            enemyOlusanMermiRB1.velocity = enemyOlusanMermi1.transform.forward * mermiHizi * Time.fixedDeltaTime; //Mermi objesinin rigidbodysi kullanılarak ona bir hız eklenir. Bu sayede hareket eder.
            enemyOlusanMermiRB2.velocity = enemyOlusanMermi2.transform.forward * mermiHizi * Time.fixedDeltaTime; //Merminin oluşturulma noktasına göre yön verilir. Mermi hızı katsayısı ile çarpılır.
            enemyOlusanMermiRB3.velocity = enemyOlusanMermi3.transform.forward * mermiHizi * Time.fixedDeltaTime; //Sonra mermi sabit bir hızda ilerleyebilsin diye fixedDeltaTime ile çarpılır.
        }
    }
}
