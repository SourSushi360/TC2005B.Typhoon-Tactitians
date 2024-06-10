using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static int globalResources {get; set;}
    public static int runResources {get; set;}

    public static Dictionary<string, int> upgradeLevels = new Dictionary<string, int>();
    
}
