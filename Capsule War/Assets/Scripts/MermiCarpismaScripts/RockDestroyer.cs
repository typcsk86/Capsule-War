using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroyer : MonoBehaviour
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
        //Bu kontrolün sebebi Boss3 ve Boss5 in yetenekleri olan taş düşürme yeteneğinde taşlar düşerken yerin altında bir collider ile
        //bu taşları yokediyor oluşum. Bu sayede performans kaybını azaltıyorum.
        if (other.CompareTag("Rock1"))
        {
            Destroy(other.gameObject);
        }
    }
}
