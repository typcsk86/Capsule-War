using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player2EnemyBoss4 : MonoBehaviour
{
    private float health;
    public Slider healthSlider;

    public Animator loseAnimator;
    public TextMeshProUGUI gameOverUI;

    //Player2EnemyBoss1.cs scripti ile bu kodlar benzer olduğu için burada kodlar açıklanmadı

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f;
        healthSlider.value = health;

        Time.timeScale = 1;

        loseAnimator.SetBool("GameEnd", false);

        PlayerPrefs.SetInt("EnemiesDeath", 0);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1") || other.CompareTag("Bullet2") || other.CompareTag("Bullet3") || other.CompareTag("Bullet4") || other.CompareTag("Bullet5"))
        {
            if (other.CompareTag("Bullet5"))
            {
                health -= 0.0751f;
            }
            else
            {
                health -= 0.034f;
            }

            if (health <= 0f)
            {
                gameOverUI.text = "YOU WIN!";

                PlayerPrefs.SetInt("EnemiesDeath", 1);

                loseAnimator.SetBool("GameEnd", true);

                Cursor.lockState = CursorLockMode.None;

                Destroy(this.gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}
