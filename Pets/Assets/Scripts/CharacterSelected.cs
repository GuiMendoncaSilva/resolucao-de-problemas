using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelected : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    //public Text nameText;
    private GameObject characterPrefab;
    public GameObject parentGameObject;
    void Start()
    {
        if (MainManagement.characters == null) return;

        for (int i = 0; i < MainManagement.characters.Length; i++)
        {
            UpdateCharacter(MainManagement.characters[i]);
        }
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDatabase.GetCharacter(selectedOption);
        character.Life = 100;
        character.Energy = 100;
        character.Satiation = 100;
        characterPrefab = character.prefabToInstantiate;

        GameObject instantiatedCharacter = Instantiate(characterPrefab, parentGameObject.transform);
        instantiatedCharacter.transform.localScale = new Vector3(0.48f, 0.48f);
        float randomX = Random.Range(26, 260); 
        float randomY = Random.Range(100, 380);
        Vector3 randomPosition = new Vector3(randomX, randomY);
        instantiatedCharacter.transform.position = randomPosition;
    }

}
