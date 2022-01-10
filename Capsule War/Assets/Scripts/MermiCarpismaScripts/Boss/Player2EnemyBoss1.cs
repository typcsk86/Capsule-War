using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player2EnemyBoss1 : MonoBehaviour
{

    private float health; //Boss1 Canı
    public Slider healthSlider; //Boss1 Can Slider'ı
    
    public Animator loseAnimator; //Panel Animatörü
    public TextMeshProUGUI gameOverUI; //Oyun bitiş panelinin text'i

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f; //Boss1 canı
        healthSlider.value = health; //boss1 canı slider'a atanır

        Time.timeScale = 1; //Oyun genel zaman scale'i 1 dir. Eğer 0 olursa oyun tamamen donar.

        loseAnimator.SetBool("GameEnd", false); //Oyun bitiş animatörü başlangıçta kapalıdır.

        PlayerPrefs.SetInt("EnemiesDeath", 0); //Boss ölümü gerçekleşmesi ve diğer scriptlerde kontrol sağlamak için oluşturulmuş PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health; //Her Update dönüşünde slidera can atanır
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5")) //Eğer player mermileri düşmana çarparsa
        {
            if (other.CompareTag("Bullet5")) //eğer bu mermi 5.mermiyse yani ateş silahının ateşi ise
            {
                health -= 0.101f; //Can 0.101 azalır
            } else //değilse
            {
                health -= 0.051f; //Diğer 4 mermi ise 0.051 azalır
            }
            
            if (health <= 0f) //can 0 dan düşük veya eşitse
            {
                gameOverUI.text = "YOU WIN!"; //Player oyunu kazanır texte YOU WIN yazar

                PlayerPrefs.SetInt("EnemiesDeath", 1); //Düşmanlar öldü bilgisi yollanır

                loseAnimator.SetBool("GameEnd", true); //Panel animatörü çalışır

                Cursor.lockState = CursorLockMode.None; //Mause işaretçisi görünür

                Destroy(this.gameObject); //Düşman yokedilir.
            }
            
            Destroy(other.gameObject); //Mermi yokedilir.
        }
    }
}
