using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmTakip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position); //Silah kameraya bakar.
        transform.Rotate(0, 180, 0); //Silahın kamerasını y ekseninde 180 derece döndürürüm. Bu sayede kameraya baktığı açının tam tersine bakar. Ve kameranın hareketi ile nişan alır.
    }
}
