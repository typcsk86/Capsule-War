using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFindTargetBoss : MonoBehaviour
{
    public Transform target; //Hedefin transformu
    public GameObject[] targetArray; //Ajanın gideceği hedeflerin arrayi
    public int mevcut; //mevcut hedef
    private int targetNumber; //Hedef Sayısı
    private NavMeshAgent enemyAgent; //Düşman ajanı

    // Start is called before the first frame update
    void Start()
    {
        //Bu oyun objesine bağlı NavMeshAgent'a ulaşım sağlar
        enemyAgent = GetComponent<NavMeshAgent>();

        //Maksimum hedef sayısını atar
        targetNumber = targetArray.Length;

        //Yeni bir mevcut hedef hesaplar ve o tarafa doğru yolculuk yapar.
        findNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //Boss playere bakar
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void findNewTarget()
    {
        mevcut = (int)(Random.value * targetNumber); //Mevcut hedef değişkeni atanır.
        enemyAgent.SetDestination(targetArray[mevcut].transform.position); //Boss ajanı o hedefe gider.
    }
}
