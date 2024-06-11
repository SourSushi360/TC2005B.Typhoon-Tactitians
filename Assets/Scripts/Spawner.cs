using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int elapsedTime = 0;
    [SerializeField] private int timeToSpawn = 10;
    [SerializeField] private int timeBetweenSpawns = 5;
    [SerializeField] private GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn += GameData.upgradeLevels["sensorUpgrade"] * 3;
        StartCoroutine(Delay());
    }

    public IEnumerator Timer()
    {
        Instantiate(
                    objectToSpawn,
                    this.transform
                );
        while(true){
            elapsedTime += 1;
            
            if(elapsedTime % timeBetweenSpawns == 0){
                elapsedTime = 0;
                Instantiate(
                    objectToSpawn,
                    this.transform
                );
            }
            yield return new WaitForSeconds(1);
        }
        
    }
    public IEnumerator Delay()
    {
        int timeFromStart = 0;
        while(timeFromStart < timeToSpawn){
            timeFromStart += 1;

            yield return new WaitForSeconds(1);
        }
        StartCoroutine(Timer());
        
    }
}
