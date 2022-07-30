using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A quick fix to making a crafting system. 
/// </summary>
[CreateAssetMenu]
public class TrapRecipe : ScriptableObject
{
    [Range(0, 10)] public int bbearTrapAmount = 0;

          
    [Range(0, 10)]public int branchAmount = 0;

          
    [Range(0, 10)] public int ropeAmount = 0;

          
    [Range(0, 10)] public int vineAmount = 0;


    public Sprite weaponSprite; 

    public GameObject weaponPrefab;
}


