using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatingPoint : MonoBehaviour
{

    public GameObject enemyReference; //Oluşturulacak düşman objesi
    public int enemyTimeCountMax; //İki düşmanın çıkış aralığı süresi
    private int enemyTimeCountGecerli; //Düşman çıkışından bu yana geçen süre
    public int enemyNumber; //Çıkan düşman sayısı

    // Start is called before the first frame update
    void Start()
    {
        enemyTimeCountGecerli = 60; //Düşmanların oluşma aralığı

        enemyNumber = (int) (enemyNumber * enemyTimeCountMax); //Düşman sayısı ile Maximum sayac çarpılarak kaç tane düşman çıkacağı belirlenir.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyNumber >= 0) //Oluşturulacak düşman sayısı 0 dan büyükse kontrolü.
        {
            if(enemyTimeCountGecerli <= 0) //eğer geçerli sayaç 0 dan küçükse düşman oluşturulur
            {
                //Düşman oluştur
                Vector3 EnemyCreatingPoint = transform.position;
                EnemyCreatingPoint.y = 0.1f;

                Instantiate(enemyReference, EnemyCreatingPoint, transform.rotation);
                enemyTimeCountGecerli = enemyTimeCountMax;
            }
            else //0 dan büyükse sayaç azalır.
            {
                enemyTimeCountGecerli--;
            }
            enemyNumber--; //Düşman sayısı azalır.
        }
    }
}
