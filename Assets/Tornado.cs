using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private int elapsedTime;
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
            
            if(elapsedTime % 3 == 0){
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1);
        }
        
    }
}
