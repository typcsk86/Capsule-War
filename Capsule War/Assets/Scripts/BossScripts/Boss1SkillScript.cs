using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1SkillScript : MonoBehaviour
{

    private int randomTeleportPoint; //Bu değişken boss1 in ışınlanacağı bölgeyi rastgele olarak belirleyecek değişkendir.
    private float teleportTimer; //Bu değişken boss1 in ne kadar sürede bir ışınlanacağını belirleyen değişkendir.

    // Start is called before the first frame update
    void Start()
    {
        teleportTimer = Random.Range(3.0f, 4.0f); //boss1 in ışınlanma süresi 3 saniye ile 4 saniye arası değişir
        randomTeleportPoint = 0; //Başlangıçta random ışınlanma değeri 0 olarak atanır.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(PlayerPrefs.GetInt("GamePaused") == 0 && PlayerPrefs.GetInt("PlayerDeath") == 0 && PlayerPrefs.GetInt("EnemiesDeath") == 0) //Oyunun durdurulması, bitmesi gibi durumlar olmadığı sürece çalışır
        {
            if (teleportTimer > 0) //Eğer ışınlanma süresi 0 dan büyükse sürekli azalır
            {
                teleportTimer -= Time.deltaTime;
            }
            else //0 dan büyükse rastgele bir ışınlanma yeri atanır ve boss1 in pozisyonu ışınlanacağı pozisyon olur. Bu şekilde ışınlanmış olur.
            {
                randomTeleportPoint = Random.Range(1, 6); //Rastgele değer atandı

                if (randomTeleportPoint == 1) //Değere göre rastgele bir bölgeye ışınlandı.
                {
                    transform.position = new Vector3(5f, 1.5f, 15f); //boss1 in pozisyonu değiştirildi.
                }
                else if (randomTeleportPoint == 2)
                {
                    transform.position = new Vector3(-5f, 1.5f, 15f);
                }
                else if (randomTeleportPoint == 3)
                {
                    transform.position = new Vector3(10f, 1.5f, 20f);
                }
                else if (randomTeleportPoint == 4)
                {
                    transform.position = new Vector3(0f, 1.5f, 20f);
                }
                else if (randomTeleportPoint == 5)
                {
                    transform.position = new Vector3(-10f, 1.5f, 20f);
                }
                teleportTimer = Random.Range(3.0f, 4.0f);
            }
        }
        
    }
}
