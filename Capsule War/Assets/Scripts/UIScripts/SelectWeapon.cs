using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectWeapon : MonoBehaviour
{
    public Button weapon1; //1.Silah Buton
    public Button weapon2; //2.Silah Buton
    public Button weapon3; //3.Silah Buton
    public Button weapon4; //4.Silah Buton
    public Button weapon5; //5.Silah Buton

    public GameObject weapon1Object; //1.Silah Objesi
    public GameObject weapon2Object; //2.Silah Objesi
    public GameObject weapon3Object; //3.Silah Objesi
    public GameObject weapon4Object; //4.Silah Objesi
    public GameObject weapon5Object; //5.Silah Objesi

    public bool silahKontrol1; //Silah Seçimi Kontrolü (1.Silah)
    public bool silahKontrol2; //Silah Seçimi Kontrolü (2.Silah)
    public bool silahKontrol3; //Silah Seçimi Kontrolü (3.Silah)
    public bool silahKontrol4; //Silah Seçimi Kontrolü (4.Silah)
    public bool silahKontrol5; //Silah Seçimi Kontrolü (5.Silah)

    private int saveIndex; //Level kilit sistemine göre geçilmiş leveller ile birlikte kilidi açılacak silahların bilgisi.

    // Start is called before the first frame update
    void Start()
    {
        weapon1.enabled = false; //Silah butonu 1 in basılabilirliği kapatılır.
        weapon2.enabled = false; //Silah butonu 2 in basılabilirliği kapatılır.
        weapon3.enabled = false; //Silah butonu 3 in basılabilirliği kapatılır.
        weapon4.enabled = false; //Silah butonu 4 in basılabilirliği kapatılır.
        weapon5.enabled = false; //Silah butonu 5 in basılabilirliği kapatılır.

        weapon1.interactable = false; //Silah butonu 1 in etkileşimi kapanır.
        weapon2.interactable = false; //Silah butonu 2 in etkileşimi kapanır.
        weapon3.interactable = false; //Silah butonu 3 in etkileşimi kapanır.
        weapon4.interactable = false; //Silah butonu 4 in etkileşimi kapanır.
        weapon5.interactable = false; //Silah butonu 5 in etkileşimi kapanır.

        weapon1.interactable = true; //Silah butonu 1 in etkileşimi açılır. Öncelikle kapatmamın sebebi bazı hatalar vermişti o yüzden bu şekilde ayarladım.

        weapon1Object.SetActive(true); //1.Silah Objesi görünür. (Başlangıçta)
        weapon2Object.SetActive(false); //2.Silah Objesi görünmez. (Başlangıçta)
        weapon3Object.SetActive(false); //3.Silah Objesi görünmez. (Başlangıçta)
        weapon4Object.SetActive(false); //4.Silah Objesi görünmez. (Başlangıçta)
        weapon5Object.SetActive(false); //5.Silah Objesi görünmez. (Başlangıçta)

        silahKontrol1 = false; //Tüm silah Kontrolleri kapanır
        silahKontrol2 = false;
        silahKontrol3 = false;
        silahKontrol4 = false;
        silahKontrol5 = false;

        saveIndex = PlayerPrefs.GetInt("saveIndex"); //Level kilit sisteminden geçilmiş levelin bilgisi alınır.

        if (SceneManager.GetActiveScene().buildIndex >= 1 || saveIndex >= 1) //O an bulunan levelin durumuna göre veya kilit sisteminden alınan bilgiye göre silah seçimi yapılır.
        {
            silahKontrol1 = true; //1.Silah kontrolü true yapılır. (Eğer Level 1-10 içerisinde ise veya ilk 10 level geçilmişse)
        }

        if (SceneManager.GetActiveScene().buildIndex >= 11 || saveIndex >= 11)
        {
            silahKontrol2 = true; //2.Silah kontrolü true yapılır. (Eğer Level 11-20 içerisinde ise veya 11-20 level geçilmişse)
        }

        if (SceneManager.GetActiveScene().buildIndex >= 21 || saveIndex >= 21)
        {
            silahKontrol3 = true; //3.Silah kontrolü true yapılır. (Eğer Level 21-30 içerisinde ise veya 21-30 level geçilmişse)
        }

        if (SceneManager.GetActiveScene().buildIndex >= 31 || saveIndex >= 31)
        {
            silahKontrol4 = true; //4.Silah kontrolü true yapılır. (Eğer Level 31-40 içerisinde ise veya 31-40 level geçilmişse)
        }

        if (SceneManager.GetActiveScene().buildIndex >= 41 || saveIndex >= 41)
        {
            silahKontrol5 = true; //5.Silah kontrolü true yapılır. (Eğer Level 41-50 içerisinde ise veya 41-50 level geçilmişse)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) //Klavyedeki 1 den 5 e kadar olan tuşlara göre silah seçimi yapılır
        {
            weapon1Activate(); //Silah 1 fonksiyonu çağırılır
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weapon2Activate(); //Silah 2 fonksiyonu çağırılır
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weapon3Activate(); //Silah 3 fonksiyonu çağırılır
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weapon4Activate(); //Silah 4 fonksiyonu çağırılır
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            weapon5Activate(); //Silah 5 fonksiyonu çağırılır
        }
    }

    public void weapon1Activate()
    {
        //1.Silah açık diğerleri kapalı
        if (silahKontrol1)
        {
            weapon1.interactable = true;
            weapon2.interactable = false;
            weapon3.interactable = false;
            weapon4.interactable = false;
            weapon5.interactable = false;

            weapon1Object.SetActive(true);
            weapon2Object.SetActive(false);
            weapon3Object.SetActive(false);
            weapon4Object.SetActive(false);
            weapon5Object.SetActive(false);
        }
            
    }

    public void weapon2Activate()
    {
        //2.Silah açık diğerleri kapalı
        if (silahKontrol2)
        {
            weapon1.interactable = false;
            weapon2.interactable = true;
            weapon3.interactable = false;
            weapon4.interactable = false;
            weapon5.interactable = false;

            weapon1Object.SetActive(false);
            weapon2Object.SetActive(true);
            weapon3Object.SetActive(false);
            weapon4Object.SetActive(false);
            weapon5Object.SetActive(false);
        }
    }

    public void weapon3Activate()
    {
        //3.Silah açık diğerleri kapalı
        if (silahKontrol3)
        {
            weapon1.interactable = false;
            weapon2.interactable = false;
            weapon3.interactable = true;
            weapon4.interactable = false;
            weapon5.interactable = false;

            weapon1Object.SetActive(false);
            weapon2Object.SetActive(false);
            weapon3Object.SetActive(true);
            weapon4Object.SetActive(false);
            weapon5Object.SetActive(false);
        }
    }

    public void weapon4Activate()
    {
        //4.Silah açık diğerleri kapalı
        if (silahKontrol4)
        {
            weapon1.interactable = false;
            weapon2.interactable = false;
            weapon3.interactable = false;
            weapon4.interactable = true;
            weapon5.interactable = false;

            weapon1Object.SetActive(false);
            weapon2Object.SetActive(false);
            weapon3Object.SetActive(false);
            weapon4Object.SetActive(true);
            weapon5Object.SetActive(false);
        }
    }

    public void weapon5Activate()
    {
        //5.Silah açık diğerleri kapalı
        if (silahKontrol5)
        {
            weapon1.interactable = false;
            weapon2.interactable = false;
            weapon3.interactable = false;
            weapon4.interactable = false;
            weapon5.interactable = true;

            weapon1Object.SetActive(false);
            weapon2Object.SetActive(false);
            weapon3Object.SetActive(false);
            weapon4Object.SetActive(false);
            weapon5Object.SetActive(true);
        }
    }
}
