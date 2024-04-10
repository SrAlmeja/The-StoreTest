using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonObject", menuName = "AlmejaStudio/Scriptables/DungeonItems")]
public class ItemSO : ScriptableObject
{
    #region Variables

    public string ItemName;
    public string RarityTag;
    public int Quantity;
    [SerializeField] public Sprite ItemImage;
    [TextArea] public string ItemDescription;
    public int SellPrice;

    #endregion
    
}
