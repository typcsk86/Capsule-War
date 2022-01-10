using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseUI : MonoBehaviour
{
    public GameObject pausePanel; //Pause Paneli Objesi

    void Start()
    {
        pausePanel.SetActive(false); //Oyun başında obje kapalıdır.

        PlayerPrefs.SetInt("GamePaused", 0); //Diğer scriptlere gönderilecek sayı başlangıçta 0 dır yani kapalılığı belirtir.
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //eğer Esc tuşuna basılırsa
        {
            pausePanel.SetActive(true); //Panel aktif olur
            Cursor.lockState = CursorLockMode.None; //Mause işaretçisi görünür
            PlayerPrefs.SetInt("GamePaused", 1); //Diğer scriptler için oyun durduruldu bilgisi 1 yani açık olarak gönderilir.
            Time.timeScale = 0; //Oyunun genel zaman sayacı durdurulur. 0 yapılarak.
            
        }
    }

    public void resumeGame() //Oyunun devam etme durumu (Resume Game butonuna basıldığında)
    {
        Time.timeScale = 1; //Oyunun genel zaman sayacı başlatılır. 1 Yapılarak
        PlayerPrefs.SetInt("GamePaused", 0); //Diğer scriptlere pause paneli kapalı bilgisi yollanır.
        pausePanel.SetActive(false); //Panelin aktifliği kapanır.
        Cursor.lockState = CursorLockMode.Locked; //Maus işaretçisi kapanır.
    }

}
