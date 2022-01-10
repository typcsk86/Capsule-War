using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPhysics : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rigidbody; //Taşın rigidbody componenti

    public bool useGraivty = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //Taşın rigidbody componentini alırız.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.useGravity = false; //Taşın rigidbodysinde olan yerçekimi kapatılır.
        if(useGraivty)
        {
            rigidbody.AddForce((Physics.gravity * (rigidbody.mass * rigidbody.mass)) * 0.4f); //Burada taşa oyunun fiziğinden farklı bir fizik ve kütle eklenerek taşın daha hızlı düşmesi sağlanır.
        }
    }
}
