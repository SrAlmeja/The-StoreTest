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
    public int quantity;
    [SerializeField] public Sprite ItemImage;
    public int SellPrice;
    
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    
    #endregion

}
