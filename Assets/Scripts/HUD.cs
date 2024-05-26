using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI tiempo;
    private int minutos, segundos;

    private int elapsedTime = 0;
    
    void Start(){
        StartCoroutine(Timer());
    }

    void Update()
    {
        minutos = Mathf.FloorToInt(elapsedTime / 60);
        segundos = Mathf.FloorToInt(elapsedTime % 60);
        tiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        puntos.text = gameManager.FoodCount.ToString();
    }

    public IEnumerator Timer()
    {
        while(true){
            elapsedTime += 1;
            yield return new WaitForSeconds(1);
        }
        
    }

}
