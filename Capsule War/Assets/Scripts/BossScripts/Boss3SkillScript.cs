using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3SkillScript : MonoBehaviour
{
    public GameObject rockObject; //Taş Objesi

    public GameObject rockSign; //Taşın düşmeden önce düşeceğini gösteren işaret

    private float tasZamanSayaci; //Taşların düşmeye başladıktan sonraki zamanının aralığı
    private int tasAdetSayaci; //Kaç tane taş düşeceğini belirler

    private float genelSayac; //Taşların kaç saniyede bir düşeceğini gösteren sayaç

    private float randomPosition; //Merminin düşeceği random pozisyon değişkeni.

    // Start is called before the first frame update
    void Start()
    {
        genelSayac = 5.0f; //Genel taş düşme sayacı 5 saniyedir.
        tasZamanSayaci = Random.Range(0.1f, 0.15f); //Taş düşmeye başladıktan sonraki düşme aralığı.
        rockSign.SetActive(false); //Taş düşmeden önce kullanıcının taş düşeceğini anlaması için eklenen işaret başlangıçta false olarak atanır.
        tasAdetSayaci = 10; //Düşen taş sayısı 10 olarak atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer oyun durmamışsa veya player ölmediyse taş düşer.
        {
            if(genelSayac <= 0) //Genel sayaç 0 dan küçükse taş düşmeye başlar
            {
                if(tasAdetSayaci <= 0) //Eğer 10 taş düşmüşse kontrolü
                {
                    genelSayac = 5.0f; //genel sayaç yeniden 5 saniye yapılır.
                    rockSign.SetActive(false); //taş düşme işaretçisi kapanır.
                    tasAdetSayaci = 10; //düşecek taş sayısı yeniden 10 olarak belirlenir.
                }
                else //Eğer 10 taş düşmeye başladıysa
                { 
                    randomPosition = Random.Range(-1.0f, 1.0f); //Taşın playerin üstünde belli bir aralıkta rastgele düşeceği konumu belirleyecek değer atanır.
                    transform.localPosition = new Vector3(randomPosition, 10.0f, randomPosition); //Taşın düşeceği objenin konumu ayarlanır.
                    if(tasZamanSayaci > 0) //Taşın düşme aralığı 0 dan büyükse süre azalır
                    {
                        tasZamanSayaci -= Time.deltaTime;
                    }
                    else //0 dan küçükse taş düşmeye başlar.
                    {
                        rockSign.SetActive(true); //Taş düşmeye başlayınca kullanıcı için olan işaretçi görünür ve kullanıcı yukarıdan taş düşeceğini anlar.
                        rockFall(); //Taşı oluşturacak fonksiyon çağırılır.
                        tasZamanSayaci = Random.Range(0.1f, 0.15f); //Taş düşme zaman aralığı tekrardan belirlenir.
                        tasAdetSayaci--; //10 Tane taşın sayısı azalır.
                    }
                }
            }
            else //0 dan büyükse saniye azalır.
            {
                genelSayac -= Time.deltaTime;
            }
        }
    }

    void rockFall()
    {
        GameObject olusanRock1 = Instantiate(rockObject, transform.position, transform.rotation); //Taş burada oluşturulur.
    }
}
