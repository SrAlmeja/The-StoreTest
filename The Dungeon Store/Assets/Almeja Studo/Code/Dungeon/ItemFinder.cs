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
        ItemsFound();
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
        _itemsList = new List<ItemSO>();

        for (int i = 0; i < _numItemsFound; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, foundItems.Count);
            ItemSO selectedItem = foundItems[randomIndex];
            _itemsList.Add(selectedItem);
            Debug.Log("Item selected: " + selectedItem.ItemName);
        }

        return _itemsList;
    }

    public Dictionary<ItemSO, int> FindDuplicateItems()
    {
        if (_itemsList == null)
        {
            Debug.LogError("Error: _itemsList is null");
            return new Dictionary<ItemSO, int>();
        }
        Dictionary<ItemSO, int> duplicates = new Dictionary<ItemSO, int>();

        foreach (ItemSO item in _itemsList)
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

        return duplicates;
    }

    public void Print(string dificulty, int characterNumber)
    {
        //Debug.Log("Dificultad seleccionada: " + _dificulty.value);
        Debug.Log("Número de ítems encontrados: " + _numItemsFound);
        
        Dictionary<ItemSO, int> duplicates = FindDuplicateItems();

        foreach (var pair in duplicates)
        {
            _inventoryManager.AddItem(pair.Key, pair.Value);
        }
    }
}
