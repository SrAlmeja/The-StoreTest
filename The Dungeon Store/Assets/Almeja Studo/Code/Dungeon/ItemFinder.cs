using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFinder : MonoBehaviour
{
    #region Variables

    private InventoryManager _inventoryManager;

    private List<ItemSO> _itemsList;
    public List<ItemSO> foundItems;
    [SerializeField] private StringSO _dificulty;

    private int _numItemsFound;

    #endregion

    private void Awake()
    {
        ItemSO[] itemsArray = Resources.LoadAll<ItemSO>("AlmejaStudio/Scriptables");
        foundItems = new List<ItemSO>(itemsArray);
        _inventoryManager = FindObjectOfType<InventoryManager>();
        if (_inventoryManager == null)
        {
            Debug.LogWarning("El InventoryManager no se encuentra dentro de la escena");
        }
    }

    public void GenerateItems(string dificulty, int characterNumber)
    {
        _numItemsFound = RandomOfFoundItems(dificulty, characterNumber);
    }

    public int RandomOfFoundItems(string journeyType, int characterNumber)
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

    public List<ItemSO> ItemsFound()
    {
        List<ItemSO> itemsFound = new List<ItemSO>();

        while (itemsFound.Count <= _numItemsFound)
        {
            int randomIndex = UnityEngine.Random.Range(0, foundItems.Count);
            itemsFound.Add(foundItems[randomIndex]);
        }

        return itemsFound;
    }

    public Dictionary<ItemSO, int> FindDuplicateItems()
    {
        Dictionary<ItemSO, int> duplicates = new FlexibleDictionary<ItemSO, int>();

        foreach (ItemSO item in ItemsFound())
        {
            if (duplicates.ContainsKey(item))
            {
                duplicates[item]++;
            }
            else
            {
                duplicates[item] = 1;
            }
        }
        foreach (var pair in duplicates)
        {
            pair.Key.Quantity = pair.Value;
        }
        return duplicates;
    }

    public void Print(string dificulty, int characterNumber)
    {
        int numItems = RandomOfFoundItems(dificulty, characterNumber);
        Debug.Log("Dificultad seleccionada: " + _dificulty.value);
        Debug.Log("Número de ítems encontrados: " + numItems);
        
        List<ItemSO> itemsFound = ItemsFound();

        foreach (ItemSO item in itemsFound)
        {
            _inventoryManager.AddItem(item);
        }
    }
}
