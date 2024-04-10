using System;
using UnityEngine;

public class GroupController : MonoBehaviour
{
    public CharacterSO characterSO;
    public IntSO groupNumber;
    
    [SerializeField] private int rows = 3;
    [SerializeField] private int cols = 3;
    [SerializeField] private float spacingX = 0.5f;
    [SerializeField] private float spacingY = -0.5f;

    private void Awake()
    {
        FindPlayerGroup();
    }

    private void Start()
    {
        if (groupNumber.value <= 1)
        {
            groupNumber.value = 1;
        }
        if (groupNumber.value >= 11)
        {
            groupNumber.value = 10;
        }
        SpawnCharacter(groupNumber.value);
    }

    public static GameObject FindPlayerGroup()
    {
        GameObject playerGroup = GameObject.Find("PlayerGroup");
        if (playerGroup == null)
        {
            Debug.LogError("No se encontró un GameObject llamado 'PlayerGroup' en la escena.");
        }
        return playerGroup;
    }
    
    private void SpawnCharacter(int characterNumber)
    {
        GameObject playerGroup = FindPlayerGroup();
        if (playerGroup != null && characterSO != null && characterSO.CharacterPrefab != null)
        {
            float startX = -0.5f; // Posición inicial en x
            float startY = 0.5f; // Posición inicial en y

            for (int i = 0; i < characterNumber; i++)
            {
                float xPos = startX + (i % cols) * spacingX; // Calcular la posición en x
                float yPos = startY + (i / cols) * spacingY; // Calcular la posición en y
                Vector3 spawnPosition = new Vector3(xPos, yPos, transform.position.z); // Posición de spawn
                GameObject character = Instantiate(characterSO.CharacterPrefab, spawnPosition, Quaternion.identity);
                character.transform.SetParent(playerGroup.transform);
            }
        }
        else
        {
            Debug.LogError("El CharacterSO o el Prefab del personaje no están configurados correctamente.");
        }
    }
}