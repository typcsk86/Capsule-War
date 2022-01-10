using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //Hedef playerdir.

    public Vector3 offset; // Player nereye giderse kamera da oraya gidecek verisini tutuyor.

    public bool useOffsetValues; //Eğer script den farklı bir pozisyon değeri ile takip yapılacaksa diye bu eklenti eklendi.

    public float rotateSpeed; // Kamera dönüş hızı

    public Transform pivot;

    public float maxViewAngle; // Kamera bakışında max sınır için yapılır.
    public float minViewAngle; // Kamera bakışında min sınır için yapılır.

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {

        if (!useOffsetValues) //Eğer farklı bir pozisyon seçilmediyse.
        {
            offset = target.position - transform.position; //offset değeri playerin pozisyonundan kameranın pozisyonunun çıkarılması ile elde edilir.
        }

        pivot.transform.position = target.transform.position; //Pivotun pozisyonu playerin pozisyonu olur
        pivot.transform.parent = target.transform; //Pivot player objesinin içine girer.

        Cursor.lockState = CursorLockMode.Locked; //Maus işaretçisi kapanır.

    }

    void LateUpdate() //LateUpdate() e çevirdik. Çünkü Update den daha sonra çalışıyor. Bunun sebebi de sadece update varken karakteri hareket ettirdiğimizde sanki bir itki kuvveti varmış gibi görünmesi.
    {
        if(PlayerPrefs.GetInt("PlayerDeath") == 0 && PlayerPrefs.GetInt("EnemiesDeath") == 0 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer oyun durmamışsa, düşmanlar veya player ölmediyse kamera kontrol edilebilir.
        {
            //Mouse'nin x pozisyonunu alıyoruz ve "target"i döndürüyoruz.
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0f, horizontal, 0f);

            //Mouse'nin  y pozisyonunu alıyoruz ve "pivot"u döndürüyoruz.
            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

            if (invertY) // Kameranın yukarı aşağı mouse hareketinin düzgün-ters ayarını yapmak için.
            {
                pivot.Rotate(vertical, 0f, 0f);
            }
            else
            {
                pivot.Rotate(-vertical, 0f, 0f);
            }

            //Kameranın yukarı/aşağı dönüş(rotation) limiti
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)  //Önceki değer 180f
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0f, 0f);
            }

            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0f, 0f);
            }

            //Hedefin mevcut dönüşüne ve offset'e göre kamerayı hareket ettirir.
            float desiredYangle = target.eulerAngles.y;
            float desiredXangle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYangle, 0f);
            transform.position = target.position - (rotation * offset);

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z); //Buradaki target.position.y - .5f kısmı y koordinatındaki kısım, kameranın yerin altına 
                                                                                                                       //girmemesi için ayarlandı. Kamera sınırlandırmak.
            }
            transform.LookAt(target); //Kamera player'e bakar.
        }

    }
}
