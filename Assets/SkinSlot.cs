using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    public bool isOwned = false;
    public GameObject costHeader;
    public TMP_Text buttonText;
    public Button button;

    public int price;

    public SaveScriptableObject SaveScriptableObject;
    public int index;
    public CoinCount coinCount;

    private void Start()
    {
        costHeader.GetComponentInChildren<TMP_Text>().text = price.ToString("n0");

        if (SaveScriptableObject.owned[index] == true)
        {
            isOwned = true;
        }
    }

    void Update()
    {
        if (isOwned)
        {
            costHeader.SetActive(false);
            buttonText.text = "USE";
            button.onClick.RemoveListener(() => Buy());
            button.onClick.AddListener(() => Use());

            if (SaveScriptableObject.skinIndex == index && SaveScriptableObject.owned[index] == true)
            {
                button.interactable = false;
            }
        }
        else
        {
            costHeader.SetActive(true);
            buttonText.text = "BUY";
            button.onClick.RemoveListener(() => Use());
            button.onClick.AddListener(() => Buy());

            if (SaveScriptableObject.coins >= price)
                button.interactable = true;
            else
                button.interactable = false;
        }
    }

    public void Buy()
    {
        if(SaveScriptableObject.coins >= price)
        {
            SaveScriptableObject.coins -= price;
            SaveScriptableObject.owned[index] = true;
            isOwned = true;
            SaveManager.instance.Save();
            coinCount.UpdateCoinText();
        }
    }

    public void Use()
    {
        SaveScriptableObject.skinIndex = index;
        SaveManager.instance.Save();
    }
}
