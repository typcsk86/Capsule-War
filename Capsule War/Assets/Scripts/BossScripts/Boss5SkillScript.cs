using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5SkillScript : MonoBehaviour
{
    public MeshRenderer forceShieldMesh; //5.Bossun Güç Kalkanı Mesh
    public Collider forceShieldCollider; //5.Bossun Güç Kalkanı Collider

    private float forceShieldSayaci; //Güç Kalkanının Süresi

    private bool forceShieldKontrol; //Güç Kalkanı açık-kapalı durumu

    //4.Boss yetenek scripti ile bu scriptin kodları benzer olduğundan buraya yorum satırı eklenmedi.

    // Start is called before the first frame update
    void Start()
    {
        forceShieldSayaci = 5.0f;

        forceShieldKontrol = false;

        forceShieldMesh.enabled = false;
        forceShieldCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (forceShieldSayaci <= 0f && forceShieldKontrol == false)
        {
            forceShieldMesh.enabled = true;
            forceShieldCollider.enabled = true;
            forceShieldKontrol = true;
            forceShieldSayaci = 5.0f;


        }

        if (forceShieldSayaci <= 0f && forceShieldKontrol == true)
        {
            forceShieldMesh.enabled = false;
            forceShieldCollider.enabled = false;
            forceShieldKontrol = false;
            forceShieldSayaci = 5.0f;
        }


        if (forceShieldSayaci > 0f)
        {
            forceShieldSayaci -= Time.deltaTime;
        }

    }

}
