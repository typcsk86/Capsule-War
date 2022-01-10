using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{

    public void mainMenu(string sceneName) //Fonksiyon oyun bitişinde MainMenu sahnesinin adını parametre olarak alır.
    {
        SceneManager.LoadScene(sceneName); //eğer Home butonuna basılırsa Ana menüye döner
    }

    public void reloadLevel() //Eğer aynı leveli tekrar oynamak istiyorsa
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Aynı levelin indexine göre level açılır.
    }

    public void nextLevel() //Sonraki levele gitmek istiyorsa
    {
        if(SceneManager.GetActiveScene().buildIndex == 50) //Eğer o level son level ise
        {
            SceneManager.LoadScene("MainMenu"); //Ana menüye gider.
        }
        else //Diğer tüm leveller ise
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1); //Sahne indexine göre bir sonraki sahne yani sonraki levele gider.
        }
    }
    
}
