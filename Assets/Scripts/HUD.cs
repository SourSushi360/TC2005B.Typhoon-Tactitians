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
        StartCoroutine(InstructionsFade());
        puntos.text = "Recursos recogidos: " + GameData.runResources.ToString();
    }

    void Update()
    {
        minutos = Mathf.FloorToInt(elapsedTime / 60);
        segundos = Mathf.FloorToInt(elapsedTime % 60);
        tiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public IEnumerator Timer()
    {
        while(true){
            elapsedTime += 1;
            yield return new WaitForSeconds(1);
        }
        
    }

    public IEnumerator InstructionsFade()
    {
        yield return new WaitForSeconds(3);
        while(instructions.alpha > 0){
            instructions.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public void updateRunResources(){
        puntos.text = "Recursos recogidos: " + GameData.runResources.ToString();
    }

}
