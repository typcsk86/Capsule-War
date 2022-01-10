using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4SkillScript : MonoBehaviour
{
    public MeshRenderer forceShieldMesh; //4.Bossun Güç Kalkanı Mesh
    public Collider forceShieldCollider; //4.Bossun Güç Kalkanı Collider

    private float forceShieldSayaci; //Güç Kalkanının Süresi

    private bool forceShieldKontrol; //Güç Kalkanı açık-kapalı durumu

    // Start is called before the first frame update
    void Start()
    {
        forceShieldSayaci = 5.0f; //Güç kalkanını açılmadan önce başlangıçta 5 saniye kapalı kalma süresi belirlenir

        forceShieldKontrol = false; //Güç kalkanının açılıp kapanmasını sağlayan bool değişkeni başlangıçta false dir

        forceShieldMesh.enabled = false; //Güç kalkanının MeshRenderer'i başlangıçta kapalıdır
        forceShieldCollider.enabled = false; //Güç kalkanının Collider'i başlangıçta kapalıdır
    }

    // Update is called once per frame
    void Update()
    {

        if(forceShieldSayaci <= 0f && forceShieldKontrol == false) //Eğer güç kalkanı zaman sayacı 0 dan küçük-eşitse ve bool kontrolü false ise güç kalkanı açılır. Kalkan 5 saniye açık kalır.
        {
            forceShieldMesh.enabled = true; //Mesh açıldı. Bu sayede kalkan görünür oldu.
            forceShieldCollider.enabled = true; //Collider açıldı. Bu sayede bossa çarpacak mermiler önce kalkana çarpar ve boss hasar almaz.
            forceShieldKontrol = true; //Kalkan kontrolü true dur
            forceShieldSayaci = 5.0f; //Sayaca kalkan 5 saniye açık kalması için yeniden 5 saniye atanır.
        }

        if (forceShieldSayaci <= 0f && forceShieldKontrol == true) //Eğer güç kalkanı zaman sayacı 0 dan küçük eşitse ve bool kontrolü true ise güç kalkanı kapanır. Kalkan 5 saniye kapalı kalır.
        {
            forceShieldMesh.enabled = false; //Mesh kapandı. Kalkan görünmez oldu.
            forceShieldCollider.enabled = false; //Collider kapandı. Mermiler bossa çarpabilir.
            forceShieldKontrol = false; //Kalkan kontrolü false yapıldı
            forceShieldSayaci = 5.0f; //Sayaca kalkan 5 saniye kapalı kalması için yeniden 5 saniye atanır.
        }


        if(forceShieldSayaci > 0f) //Burası kalkanın 5 saniye açık veya kapalı kalması için eğer 0 dan büyükse saniyeyi azaltacak kısımdır.
        {
            forceShieldSayaci -= Time.deltaTime;
        }

    }

}
