using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLockScript : MonoBehaviour
{
    public List<Button> levelButtons; //Level kilit sistemi için içinde 50 tane buton bulunacak bir liste oluşturulur.

    // Start is called before the first frame update
    void Start()
    {
        int saveIndex = PlayerPrefs.GetInt("saveIndex"); //EnemyEnd ve BossDeathScriptler den gelen indexler buradan alınır ve buna göre buton etkileşimi değişir.

        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelButtons[i].interactable = true; //Eğer o level geçilmişse sonraki levelin butonunun erişilebilirliği açılır.
            }
            else
            {
                levelButtons[i].interactable = false; //Geçilmiş leveller harici tüm leveller kilitlidir.
            }
        }
    }

}
