using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Enemy1 : MonoBehaviour
{
    private float health; //Düşman canı değişkeni
    public Slider healthSlider; //Düşman canı slider'i

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f; //düşman canı atanır.
        healthSlider.value = health; //Başlangıçta düşman canı slider'a aktarılır
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health; //Her update'de düşman canı slider'a aktarılır
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4")) //Eğer Bullet 1,2,3,4 çarparsa
        {
            health -= 0.1f; //Can 0.1f azalır
            
            if(health <= 0f) //Eğer can 0 dan düşükse
            {
                Destroy(this.gameObject); //Düşman yokedilir
            }

            Destroy(other.gameObject); //Mermi yokedilir
        }
        else if (other.CompareTag("Bullet5")) //Eğer Mermi 5 ise
        {
            health -= 0.21f; //Can 0.21 azalır

            if (health <= 0f) //Eğer can 0 dan düşükse
            {
                Destroy(this.gameObject); //Düşman Yokedilir
            }

            Destroy(other.gameObject); //Mermi yokedilir
        }
    }

}
