using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UpgradeStat : MonoBehaviour
{
    public TextMeshProUGUI upgdLvlText;
    public TextMeshProUGUI priceText;

    public string upgdName;

    private int level;

    private int price;

    [SerializeField]
    private UnityEvent _levelUp;

    void Start()
    {
        level = GameData.upgradeLevels[upgdName];
        
        if (level == 0){
            price = 5;
        }else{
            price = level * 10;
        }

        updateText();
    }

    public void IncreaseLevel(){
        if(GameData.globalResources >= price){
            level += 1;
            GameData.upgradeLevels[upgdName] = level;
            
            GameData.globalResources -= price; 
            price = level * 10;
            
            updateText();
            _levelUp.Invoke();
        }
    }

    void updateText(){
        upgdLvlText.text = "Level: " + level.ToString();
        priceText.text = "Price: " + price + " scrap";
    }
}
