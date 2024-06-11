using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    // Singleton functionality, there should only be one instance of this object
    public static HUD Instance {
        get;
        private set;
    }
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI vida;
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI instructions;
    private int minutos, segundos;

    private int elapsedTime = 0;
    void Awake()
    {
        // Corrective singleton
        // We check if the instance exists
        if(Instance != null){
            Destroy(gameObject);
        } else {
            // If not, we pick the space
            Instance = this;
        }
    }

    void Start(){
        StartCoroutine(Timer());
        StartCoroutine(InstructionsFade());
        puntos.text = "Resources collected: " + GameData.runResources.ToString();
        vida.text = "Remaining hitpoints: " + PlayerMovement.Instance.GetHealth();
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
        puntos.text = "Resources collected: " + GameData.runResources.ToString();
        
    }

    public void updateHealth(){
        vida.text = "Remaining hitpoints: " + PlayerMovement.Instance.GetHealth();
    }

}
