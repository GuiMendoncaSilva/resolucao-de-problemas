using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManagement : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public string nameText;
    public GameObject characterPrefab;
    public GameObject parentGameObject;

    private GameObject instantiatedCharacter;
    private int selectedOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }


        UpdateCharacter(selectedOption);
    }

    public void NextOption() 
    { 
        selectedOption++;

        if (selectedOption >= characterDatabase.characterCount) 
        { 
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDatabase.characterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption) 
    { 
        if (instantiatedCharacter != null)
        {
            Destroy(instantiatedCharacter);
        }

        Character character = characterDatabase.GetCharacter(selectedOption);
        characterPrefab = character.prefabToInstantiate;
        nameText = character.characterName;
        instantiatedCharacter = Instantiate(characterPrefab, parentGameObject.transform);
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
