using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathScript3 : MonoBehaviour
{

    public int buildIndex = 0; //Hangi sahnede olduğumuzun değişkeni

    //BossDeathScript.cs ile benzer kodlara sahip olduğu için burada kodlar açıklanmadı.

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex; //buildIndex değişkenine bulunan sahnenin indexi atanır.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("EnemiesDeath") == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("BossBullet3"));

            //Level kilit sistemi için sahne indexi kontrolü ile birlikte indexi yolluyorum.
            int saveIndex = PlayerPrefs.GetInt("saveIndex");
            if (buildIndex > saveIndex)
            {
                PlayerPrefs.SetInt("saveIndex", buildIndex);
            }
        }
    }
}
