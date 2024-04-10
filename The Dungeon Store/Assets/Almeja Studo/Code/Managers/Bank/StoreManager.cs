using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    
    public Sprite characterImage;
    public TextMeshPro characterNameText;
    public TextMeshPro costText;
    
    public List<CharacterSO> characterList;
    [SerializeField] private Canvas storeCanvas;
    
    private GameObject storeSlotContainer;

    void Awake()
    {
        characterList = LoadCharactersFromResources("AlmejaStudio/Scriptables/Characters");
        storeSlotContainer = GameObject.FindWithTag("StoreSlotContainer");
        if (storeSlotContainer == null)
        {
            Debug.LogError("No se encontró un GameObject con el tag 'StoreSlotcontainer' en la escena.");
            return;
        }
    }


    private List<CharacterSO> LoadCharactersFromResources(string path)
    {
        List<CharacterSO> characters = new List<CharacterSO>();

        // Cargar todos los CharacterSO del directorio especificado en Resources
        CharacterSO[] loadedCharacters = Resources.LoadAll<CharacterSO>(path);

        foreach (CharacterSO character in loadedCharacters)
        {
            characters.Add(character);
        }

        return characters;
    }

    public void StoreSwitch()
    {
        storeCanvas.enabled = !storeCanvas.enabled;
    }

    private int CountCharacters()
    {
        return characterList.Count;
    }
    
    private void PrintCharacters()
    {
        foreach (CharacterSO character in characterList)
        {
            Debug.Log("Nombre: " + character.characterName + ", Costo: " + character.characterCost);
        }
    }
}