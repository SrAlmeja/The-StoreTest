using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Adventurer", menuName = "AlmejaStudio/Scriptables/Characters")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public int characterCost;
    [Range(15f, 80f)]
    public float posibility;
    public bool isDeath;
    public GameObject CharacterPrefab;
    
    public void CalculateDeathProbability()
    {
        float probability = posibility / 100f;
        
        isDeath = UnityEngine.Random.value <= probability;
    }
}
