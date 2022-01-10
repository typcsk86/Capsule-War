using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBoss2Player1 : MonoBehaviour
{
    private float health; //Player canı
    public TextMeshProUGUI gameOverUI; //Oyun bitiş panelinin texti
    public Slider healthSlider; //Player can slider'i
    public Animator winAnimator; //Oyun bitiş animatörü
    public Button nextLevelBlockButton; //Player kaybedince sonraki levele geçiş butonunun görünmez olması için eklenen Button objesi

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerDeath", 0); //Başlangıçta player ölmedi olarak ayarlanır. Sebebi diğer scriptlerde kontrol sağlamak.
        health = 1f; //Player canı 1f olarak atanır
        healthSlider.value = health; //Slider'a can atanır

        winAnimator.SetBool("GameEnd", false); //Animatör kapalıdır.
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health; //Update her döndüğünde slider'a can bilgisi atanır.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossBullet1")) //Eğer boss mermisi çarparsa
        {
            health -= 0.15f; //Canı 0.15f azalt
            healthSlider.value = health; //Slider'a canı ata
            if (health <= 0f) //Can 0 dan düşükse
            {
                gameOverUI.text = "GAME OVER!"; //Oyun bitiş text'ine GAME OVER yaz
                
                nextLevelBlockButton.gameObject.SetActive(false); //Sonraki levele geçiş butonunu kapat

                PlayerPrefs.SetInt("PlayerDeath", 1); //Diğer scriptlerde kontrol sağlamak için Player öldü bilgisi gönder
                Cursor.lockState = CursorLockMode.None; //Mause işaretçisini görünür yap

                winAnimator.SetBool("GameEnd", true); //Panel animatörünü başlat

                this.gameObject.SetActive(false); //Player objesinin aktifliğini kapat
            }

            Destroy(other.gameObject); //Mermiyi yok et
        }
    }
}
