using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBoss2Player3 : MonoBehaviour
{
    private float health;
    public TextMeshProUGUI gameOverUI;
    public Slider healthSlider;
    public Animator winAnimator;
    public Button nextLevelBlockButton;

    //EnemyBoss2Player1.cs scriptinde kodlar açıklandığı için ve bu kodlar onun benzeri olduğundan
    //burada açıklanmadı

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerDeath", 0);
        health = 1f;
        healthSlider.value = health;

        winAnimator.SetBool("GameEnd", false);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossBullet3") || other.CompareTag("Rock1"))
        {

            health -= 0.21f;

            healthSlider.value = health;
            if (health <= 0f)
            {
                gameOverUI.text = "GAME OVER!";

                nextLevelBlockButton.gameObject.SetActive(false);

                PlayerPrefs.SetInt("PlayerDeath", 1);
                Cursor.lockState = CursorLockMode.None;

                winAnimator.SetBool("GameEnd", true);

                this.gameObject.SetActive(false);
            }

            Destroy(other.gameObject);
        }
    }
}
