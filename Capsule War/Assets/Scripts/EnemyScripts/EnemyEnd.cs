using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyEnd : MonoBehaviour
{
    public Animator loseAnimator; //Tüm düşmanlar bittiyse kazanma paneli animasyon ile ekrana gelir. (değişken adı winAnimator olmalıydı. hatalı yazmışım)
    public GameObject[] enemies; //Tüm düşmanları tutan bir obje dizisi
    private int enemyCreatingTime; //Başlangıçta hemen panel aktifleşmesin diye önceden bir zaman sayacı veriyorum. Bu sayede oyun başladığı anda panel gelmiyor.
    public TextMeshProUGUI gameOverUI; //Oyun sonu panelde yazan metinin ayarlanması.

    public int buildIndex = 0; //Hangi sahnede olduğumuzun değişkeni

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //Oyun zamanı 1 dir. Eğer 0 olsaydı oyunda hareket dururdu.
        enemyCreatingTime = 150; //Başlangıç zamanı 150 dir.
        loseAnimator.SetBool("GameEnd", false); //Panel animasyonu kapalıdır.

        PlayerPrefs.SetInt("EnemiesDeath", 0); //PlayerPrefs burada bir global değişken gibi kullanılıp oyun bittiğinde diğer scriptlere değer yollar.

        buildIndex = SceneManager.GetActiveScene().buildIndex; //buildIndex değişkenine bulunan sahnenin indexi atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCreatingTime >= 0 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer başlangıç zamanı 0 dan büyükse ve oyun durdurulmamışsa süre azalır.
        {
            enemyCreatingTime--;
        }

        if(SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 10)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy1"); //Enemy1 tag'ina sahip objeleri oyun içinde arar ve obje dizisine atar.
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 11 && SceneManager.GetActiveScene().buildIndex <= 20)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy2"); //Enemy1 tag'ina sahip objeleri oyun içinde arar ve obje dizisine atar.
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 21 && SceneManager.GetActiveScene().buildIndex <= 30)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy3"); //Enemy1 tag'ina sahip objeleri oyun içinde arar ve obje dizisine atar.
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 31 && SceneManager.GetActiveScene().buildIndex <= 40)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy4"); //Enemy1 tag'ina sahip objeleri oyun içinde arar ve obje dizisine atar.
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 41 && SceneManager.GetActiveScene().buildIndex <= 50)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy5"); //Enemy1 tag'ina sahip objeleri oyun içinde arar ve obje dizisine atar.
        }

        if (enemyCreatingTime < 0)
        {
            if(enemies.Length <= 1)
            {
                gameOverUI.text = "YOU WIN!"; //Düşmanlar bitince Game Over text'ine kazanıldığı bilgi yazılır.
                PlayerPrefs.SetInt("EnemiesDeath", 1); //Tüm düşmanlar öldükten sonra başka scriptlere bunun bilgisini yolluyor.

                //Eğer player bir vuruşla ölecek duruma gelirse ve tüm düşmanları öldürdüğü an düşmanın attığı bir mermi playera çarpacak olursa hem kazanmış hem kaybetmiş olabilir.
                //Bu riski ortadan kaldırmak için tüm düşmanlar bittiğinde tüm düşman mermilerini yokediyorum.
                Destroy(GameObject.FindGameObjectWithTag("EnemyBullet1"));
                Destroy(GameObject.FindGameObjectWithTag("EnemyBullet2"));
                Destroy(GameObject.FindGameObjectWithTag("EnemyBullet3"));
                Destroy(GameObject.FindGameObjectWithTag("EnemyBullet4"));
                Destroy(GameObject.FindGameObjectWithTag("EnemyBullet5"));

                //Level kilit sistemi için sahne indexi kontrolü ile birlikte indexi yolluyorum.
                int saveIndex = PlayerPrefs.GetInt("saveIndex");
                if(buildIndex > saveIndex)
                {
                    PlayerPrefs.SetInt("saveIndex", buildIndex);
                }

                loseAnimator.SetBool("GameEnd", true); //Tüm düşmanlar bitince panelin geliş animasyonu çalışır. (loseAnimator değişken adı hatalı yazılmış fakat oyun bozulma çıkarmasın diye değiştirmiyorum.)
                Cursor.lockState = CursorLockMode.None; //Tüm düşmanlar bitince mause cursor'u ortaya çıkar.
            }
        }
    }
}
