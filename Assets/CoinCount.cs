using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TMP_Text coinText;
    public SaveScriptableObject save;

    void OnEnable()
    {
        coinText.text = ((int)save.coins).ToString();
    }
}
