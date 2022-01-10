using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2EnemyBoss4ForceShield : MonoBehaviour
{
    public GameObject bossPosition; //Boss objesinin içine attığımızda force shield e giren mermiler boss a çarpmasa bile boss a hasar veriyor. 
                                   //Bu yüzden boss un içinden çıkarıp script ile takip ettirmek için kullanıyorum.

    void Update()
    {
        if (GameObject.Find("Boss4")) //Oyundaki Boss4 objesini arar. Eğer varsa
        {
            transform.position = bossPosition.transform.position; //Forceshield Boss4 ü takip eder.
            //Boss4 ün içine atmak yerine bu şekilde takip ettirmemin sebebi içine attığımda kalkana çarpan mermiler bossun canını azaltıyordu.
        }
        else //Yoksa
        {
            return; //return döner.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5")) //Eğer 5 mermi kalkana çarparsa
        {
            Destroy(other.gameObject); //Mermi yokedilir.
        }
    }
}
