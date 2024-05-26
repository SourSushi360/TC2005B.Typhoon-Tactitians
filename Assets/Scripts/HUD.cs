using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI instructions;
    private int minutos, segundos;

    private int elapsedTime = 0;
    
    void Start(){
        StartCoroutine(Timer());
        StartCoroutine(InstFade());
        puntos.text = GameData.resources.ToString();
    }

    void Update()
    {
        minutos = Mathf.FloorToInt(elapsedTime / 60);
        segundos = Mathf.FloorToInt(elapsedTime % 60);
        tiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        puntos.text = GameData.resources.ToString();
    }

    public IEnumerator Timer()
    {
        while(true){
            elapsedTime += 1;
            yield return new WaitForSeconds(1);
        }
        
    }

    public IEnumerator InstFade()
    {
        yield return new WaitForSeconds(3);
        while(instructions.alpha > 0){
            instructions.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

}
