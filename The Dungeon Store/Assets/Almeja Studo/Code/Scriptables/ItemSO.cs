using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonObject", menuName = "AlmejaStudio/Scritables/DungeonItems")]
public class ItemSO : ScriptableObject
{
    #region Variables

    public string ItemName;
    public string RarityTag;
    public int Cuantity;
    [SerializeField] public Sprite ItemImage;
    public int Value;
    
    #endregion

}
