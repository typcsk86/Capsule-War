using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2Wall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Bu kontrolün sebebi player mermileri, enemy mermileri, boss mermileri eğer köşelerdeki duvarlara veya colliderlara çarparsa mermiyi yoketmek için.
        //Bunu yapmamın sebebi oyun oynanırken eğer mermileri yoketmezsem oyun içerisinde çok fazla obje olacağından performansı düşürecek olmasından dolayı.
        if(other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5"))
        {
            Destroy(other.gameObject);
        }

        if(other.CompareTag("EnemyBullet1") || other.CompareTag("EnemyBullet2") || other.CompareTag("EnemyBullet3") || other.CompareTag("EnemyBullet4") || other.CompareTag("EnemyBullet5"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("BossBullet1") || other.CompareTag("BossBullet2") || other.CompareTag("BossBullet3") || other.CompareTag("BossBullet4") || other.CompareTag("BossBullet5") || other.CompareTag("Boss2SkillBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
