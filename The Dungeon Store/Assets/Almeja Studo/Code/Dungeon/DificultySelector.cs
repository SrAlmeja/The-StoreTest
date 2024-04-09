using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultySelector : MonoBehaviour
{
    [SerializeField] private StringSO _dificulty;

    public void ShortAdventure()
    {
        _dificulty.value = "Collector";
    }
    public void MediumAdventure()
    {
        _dificulty.value = "adventurous";
    }
    public void LongAdventure()
    {
        _dificulty.value = "DungeonMaster";
    }
}
