using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy2Player1 : MonoBehaviour
{
    private float health; //Playerin Canı
    public TextMeshProUGUI gameOverUI; //Oyun bittiğinde gelen paneldeki text
    public Slider healthSlider; //Player Can Slider'ı
    public Animator winAnimator; //Player öldükten sonra gelecek panelin animatörü (değişken adı loseAnimator olmalıydı orada hata yapmışım ama olması gerektiği gibi çalışıyor.)
    public Button nextLevelBlockButton; //Player ölürse sonraki levele geçilecek buton görünmemesi için.

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerDeath", 0); //Playerin ölmesi durumunda diğer scriptleri etkileyebilmek için eklenen PlayerPrefs
        health = 1f; //Başlangıçta can değeri
        healthSlider.value = health; //Can değeri slider değeri olarak atanır

        winAnimator.SetBool("GameEnd", false); //başlangıçta oyun bitiş panel animasyonu false dir
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health; //Her update de player canı slidere atanır. Bu sayede slider'da can görülür.
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyBullet1")) //Eğer playere 1.Düşmanın Mermisi çarparsa
        {
            health -= 0.1f; //Canı 0.1 azalır
            healthSlider.value = health; //Health slidere health atanır. (Hata olmaması için atanıyor)
            if (health <= 0f) //eğer player canı 0 veya 0 dan az ise
            {
                gameOverUI.text = "GAME OVER!"; //Texte GAME OVER yazılır

                nextLevelBlockButton.gameObject.SetActive(false); //Next level butonu kapanır

                PlayerPrefs.SetInt("PlayerDeath", 1); //Diğer scriptler için değişken yollanır
                Cursor.lockState = CursorLockMode.None; //Mause işaretçisi açılır.

                winAnimator.SetBool("GameEnd", true); //Bitiş animasyonu çalışır
                
                this.gameObject.SetActive(false); //Player objesinin aktifliği kapanır. Player görümez.
            }

            Destroy(other.gameObject); //Mermi yokedilir.
        }
    }
}
