using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathScript : MonoBehaviour
{

    public int buildIndex = 0; //Hangi sahnede olduğumuzun değişkeni

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex; //buildIndex değişkenine bulunan sahnenin indexi atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("EnemiesDeath") == 1) //Eğer boss ölmüşse
        {
            Destroy(GameObject.FindGameObjectWithTag("BossBullet1")); //Bossun varolan herhangi mermisi playere çarpmasın diye tüm boss mermileri yokedilir.

            //Level kilit sistemi için sahne indexi kontrolü ile birlikte indexi yolluyorum.
            int saveIndex = PlayerPrefs.GetInt("saveIndex");
            if (buildIndex > saveIndex)
            {
                PlayerPrefs.SetInt("saveIndex", buildIndex);
            }
        }
    }
}
