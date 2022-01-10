using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject mainMenuPanel; //Ana menü panel objesi
    public GameObject levelsPanel; //Leveller panel objesi

    private void Start()
    {
        Time.timeScale = 1; //Zaman sayacı açıktır.
        mainMenuPanel.SetActive(true); //Ana menü paneli görünür. (Başlangıçta)
        levelsPanel.SetActive(false); //Level paneli görünmez.
    }

    public void playGame()
    {
        int saveIndex = PlayerPrefs.GetInt("saveIndex"); //Play Game ye bastığında hangi levelde kaldıysa o leveli çekeriz.

        if(saveIndex < 50)
        {
            SceneManager.LoadScene(saveIndex + 1);

        } else
        {
            SceneManager.LoadScene(saveIndex);
        }
    }

    public void openLevel(string level_name) //Level panelindeki butonlara basıldığında
    {
        SceneManager.LoadScene(level_name); //hangi buton hangi levele gidiyosa o sahneye gider.
    }

    public void openMainMenu() //Level menüsünde back butonuna basılınca level menüsü kapanır. Ana menü açılır
    {
        mainMenuPanel.SetActive(true);
        levelsPanel.SetActive(false);
    }

    public void openLevelsMenu() //Ana menüde LEVELS butonuna basılınca ana menü kapanır. Levels menüsü açılır
    {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void quitGame() //QUIT butonuna basılırsa oyun kapatılır.
    {
        Application.Quit();
    }
}
