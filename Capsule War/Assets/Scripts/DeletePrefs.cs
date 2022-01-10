using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefs : MonoBehaviour
{
    public void deletePrefs()
    {
        //Bu kod oyundaki level kilit sisteminin Prefsini silmek ve oyunu yeniden başlatabilmek için eklendi. (TEST AMAÇLI)
        PlayerPrefs.DeleteKey("saveIndex");
    }
}
