using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5SkillScript2 : MonoBehaviour
{
    public GameObject rockObject; //Taş Objesi

    private float tasZamanSayaci; //Taşların düşmeye başladıktan sonraki zamanının aralığı
    private int tasAdetSayaci; //Kaç tane taş düşeceğini belirler

    public Collider forceShieldCollider; //5.Bossun Güç Kalkanı Collider

    private float randomPosition;

    //3.Bossun yetenek scripti ile bu scriptin kodları benzediğinden yorum satırı eklenmedi.

    // Start is called before the first frame update
    void Start()
    {
        tasZamanSayaci = Random.Range(0.1f, 0.15f);
        tasAdetSayaci = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") != 1 && PlayerPrefs.GetInt("GamePaused") == 0)
        {
            if (forceShieldCollider.enabled == true)
            {
                if (tasAdetSayaci <= 0)
                {
                    tasAdetSayaci = 10;
                }
                else
                {
                    randomPosition = Random.Range(-1.0f, 1.0f);
                    transform.localPosition = new Vector3(randomPosition, 10.0f, randomPosition);
                    if (tasZamanSayaci > 0)
                    {
                        tasZamanSayaci -= Time.deltaTime;
                    }
                    else
                    {
                        rockFall();
                        tasZamanSayaci = Random.Range(0.1f, 0.15f);
                        tasAdetSayaci--;
                    }
                }
            }
        }
    }

    void rockFall()
    {
        GameObject olusanRock1 = Instantiate(rockObject, transform.position, transform.rotation);
    }
}
