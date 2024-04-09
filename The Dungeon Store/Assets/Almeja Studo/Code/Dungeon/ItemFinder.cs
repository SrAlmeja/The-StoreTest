using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFinder : MonoBehaviour
{
    #region Variables

    private List<ItemSO> _itemsList;
    public List<ItemSO> foundItems;
    [SerializeField] private StringSO _dificulty;

    #endregion

    private void Awake()
    {
        ItemSO[] itemsArray = Resources.LoadAll<ItemSO>("AlmejaStudio/Scriptables");
        foundItems = new List<ItemSO>(itemsArray);
    }
    

    public int RandomOfFoundItems(string journeyType, int characterNumber = 1)
    {
        float rarity = 1f;
        switch (journeyType)
        {
            case "Collector":
                rarity = 0.05f;
                break;
            case "Adventurous":
                rarity = 0.09f;
                break;
            case "DungeonMaster":
                rarity = 0.1f;
                break;
        }
        rarity += characterNumber * 0.01f;
        rarity -= foundItems.Count * 0.01f;
        return UnityEngine.Random.Range(2,50) + (UnityEngine.Random.value < rarity ? 1:0);
    }

    public void Print()
    {
        int numItems = RandomOfFoundItems(_dificulty.value, 1);
        Debug.Log("Dificultad seleccionada: " + _dificulty.value);
        Debug.Log("Número de ítems encontrados: " + numItems);
    }
}
