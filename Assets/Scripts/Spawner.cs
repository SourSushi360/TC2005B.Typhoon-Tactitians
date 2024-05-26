using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int elapsedTime = 0;
    [SerializeField] private int timeToSpawn = 5;
    [SerializeField] private GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Timer()
    {
        while(true){
            elapsedTime += 1;
            
            if(elapsedTime % timeToSpawn == 0){
                elapsedTime = 0;
                Instantiate(
                    objectToSpawn,
                    this.transform
                );
            }
            yield return new WaitForSeconds(1);
        }
        
    }
}
