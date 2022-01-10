using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Collider targetCollider; //Hedef collideri değişkeni
    private float targetTime; //Hedef colliderinin kapalı kalma süresi

    private void Awake() //Awake fonksiyonu Start fonksiyonundan önce (en başta) çalıştığı için hedef colliderinin componentini burada aldım.
    {
        targetCollider = GetComponent<Collider>(); //
    }

    void Start()
    {

        targetTime = 2.0f; //Başlangıçta 2 değeri atanır. Eğer collider kapalıysa 2 saniye sonra geri açılır.
    }

    // Update is called once per frame
    void Update()
    {
        
        if(targetCollider.enabled == false && targetTime > 0) //eğer hedef collideri kapalıysa ve collider kapalılık süresi 0 dan büyükse süre azalır
        {
            targetTime -= Time.deltaTime;
        }

        if(targetTime <= 0) //Eğer süre 0 dan küçük-eşitse collider tekrardan açılır. Bu vesileyle eğer bir ajan bir hedefte takılı kalırsa o ajanın başka hedeflere doğru hareket etmesine zorlanır.
        {
            targetCollider.enabled = true; //Collider açılır
            targetTime = 2.0f; //Kapalılık süresine yeniden 2 saniye atanır.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5"))
        {
            //Bu kontrol hedef objesine bir mermi çarptığında oyunda hata vermesi sonucu eklendi.
            //Hedef sadece kendi colliderini tetikleyecek bir ajan beklediği için ajan dışında bir obje ile tetiklenince hata veriyordu.
            //Bu yüzden bu kontrol eklendi.
            return;
        }
        

        if (other.CompareTag("Enemy1") || other.CompareTag("Enemy2") || other.CompareTag("Enemy3") || other.CompareTag("Enemy4") || other.CompareTag("Enemy5"))
        {
            targetCollider.enabled = false; //Eğer bir düşman ajanı hedefe ulaşırsa collideri kapanır.
            ((EnemyFindTarget)other.gameObject.GetComponent(typeof(EnemyFindTarget))).findNewTarget(); //Ve düşman yeni hedefe ilerlemek için EnemyFindTarget scriptindeki findNewTarget fonksiyonunu çağırarak yeni hedefe ilerler.
        }
        else
        {
            return; //Yukarıdaki şartlar haricinde herhangi bir hata olmaması için return döner.
        }
    }
}
