using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2EnemyBoss5ForceShield : MonoBehaviour
{
    public GameObject bossPosition; //Boss objesinin içine attığımızda force shield e giren mermiler boss a çarpmasa bile boss a hasar veriyor. 
                                    //Bu yüzden boss un içinden çıkarıp script ile takip ettirmek için kullanıyorum.

    //Player2EnemyBoss4ForceShield.cs scripti ile bu scriptin kodları benzer olduğundan burada açıklama yapılmadı.
    
    void Update()
    {
        if (GameObject.Find("Boss5"))
        {
            transform.position = bossPosition.transform.position;
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5"))
        {
            Destroy(other.gameObject);
        }
    }
}
