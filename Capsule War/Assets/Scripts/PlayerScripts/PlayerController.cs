using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //Karakter (Player) Hızı
    public float jumpForce; //Zıplama gücü
    public CharacterController playerController; //Playerin Character controlleri

    private Vector3 moveDirection; //Gidiş yönü
    public float gravityScale; //Yerçekimi ayarı


    void Start()
    {
        playerController = GetComponent<CharacterController>(); //Playerin Character Controller componentini alırız.
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDeath") == 0 && PlayerPrefs.GetInt("EnemiesDeath") == 0 && PlayerPrefs.GetInt("GamePaused") == 0) //Eğer player ölmemişse, düşmanlar ölmemişse veya oyun durmamışsa player hareket edebilcek.
        {
            float yStore = moveDirection.y; // Camera değişimlerinden dolayı jump işlemini düzeltti.
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")); //Hareket yönü değişkeni
            moveDirection = moveDirection.normalized * moveSpeed; //Örneğin aynı anda w ve a ya basınca sol çapraza giderken hız artar. Bunu engellemek için normalize ederiz.
            moveDirection.y = yStore;

            if (playerController.isGrounded) // Eğer player zeminde değilse zıplayamaz.
            {
                moveDirection.y = 0f;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }

            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); // Daha yumuşak kalkıç ve iniş için. İstersen Time.deltaTime'yi silip gravityScale'i 0.1 jumpForce'u 13 yap.

            playerController.Move(moveDirection * Time.deltaTime); //Player hareket ettirilir.
        }
    }
}
