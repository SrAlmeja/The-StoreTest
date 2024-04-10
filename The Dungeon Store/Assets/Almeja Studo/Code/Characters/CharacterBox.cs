using System;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBox : MonoBehaviour
{
    public CharacterListSO characterListSO;
    private List<CharacterSO> characterList = new List<CharacterSO>(); // Lista privada vacía

    private void Awake()
    {
        if (characterListSO != null)
        {
            characterList.AddRange(characterListSO.characterList); // Llenar la lista con los CharacterSO del CharacterListSO
        }
        else
        {
            Debug.LogError("CharacterListSO is not assigned in CharactersBox.");
        }
        LoadCharacters("AlmejaStudio/Scriptables/Characters"); // Llenar la lista al despertar
    }

    private void LoadCharacters(string path)
    {
        CharacterSO[] characters = Resources.LoadAll<CharacterSO>(path); // Cargar todos los CharacterSO del path
        foreach (CharacterSO character in characters)
        {
            characterList.Add(character); // Agregar cada CharacterSO a la lista
        }
    }

    private void Start()
    {
        Print();
        FillCharacterListSO();
        GetCharacterList();
    }
    
    public void FillCharacterListSO()
    {
        if (characterListSO != null)
        {
            characterListSO.characterList.Clear(); // Limpiar la lista actual en el CharacterListSO

            foreach (CharacterSO character in characterList)
            {
                characterListSO.characterList.Add(character); // Agregar cada CharacterSO de la lista temporal al CharacterListSO
            }

            Debug.Log("CharacterListSO filled with temporary list.");
        }
        else
        {
            Debug.LogError("CharacterListSO is not assigned in CharactersBox.");
        }
    }
    public void Print()
    {
        int count = characterList.Count; // Obtener el número de elementos en la lista
        Debug.Log("Number of Characters: " + count); // Imprimir el número de elementos en la lista

        if (count == 0)
        {
            Debug.Log("CharacterList is empty.");
        }
        else
        {
            foreach (CharacterSO character in characterList)
            {
                Debug.Log("Character Name: " + character.name); // Imprimir el nombre de cada CharacterSO
            }
        }
    }

    public List<CharacterSO> GetCharacterList()
    {
        return characterList; // Devolver la lista de CharacterSO
    }
}