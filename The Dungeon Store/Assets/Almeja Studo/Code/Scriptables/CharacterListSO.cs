using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterList", menuName = "AlmejaStudio/Scriptables/CharacterList")]
public class CharacterListSO : ScriptableObject
{
    public List<CharacterSO> characterList = new List<CharacterSO>();
}