using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFinder : MonoBehaviour
{
    #region Variables

    private List<ItemSO> _itemsList;
    public List<ItemSO> foundItems;

    #endregion

    private void Awake()
    {
        ItemSO[] itemsArray = Resources.LoadAll<ItemSO>("AlmejaStudio/Scriptables");
        foundItems = new List<ItemSO>(itemsArray);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int RandomOfFoundItems()
    {
        return UnityEngine.Random.Range(5,31);
    }
}
