using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagement : MonoBehaviour
{
    public GameObject childObject;
    public GameObject inventory;
    private Character character;
    public TextMeshProUGUI textName;
    public Slider sliderLife;
    public Slider sliderEnergy;
    public Slider sliderSatiation;

    private void SetName(string name)
    {
        if (name == null) return;
        textName.text = name;
    }

    public void SetSliderValues(float valueLife, float valueEnergy, float valueSatiation)
    {
        if (sliderLife != null)
        {
            sliderLife.value = valueLife;
        }

        if (sliderEnergy != null)
        {
            sliderEnergy.value = valueEnergy;
        }

        if (sliderSatiation != null)
        {
            sliderSatiation.value = valueSatiation;
        }
    }

    public void SetInitialCharacter(Character character)
    {
        this.character = character;
        SetName(character.characterName);
    }

    public void CloseDialog()
    {
        if (childObject != null)
        {
            Destroy(childObject);
        }
    }

    public void OpenInventory()
    {
        if (inventory == null) return;

        GameObject instantiatedInventory = Instantiate(inventory);
        InventoryManagement inventoryScript = instantiatedInventory.GetComponent<InventoryManagement>();

        if (inventoryScript != null)
        { 
            inventoryScript.SetInitialCharacter(character);
            inventoryScript.SetDialogManagement(this);
            inventoryScript.StartItems();
        }
        else
        {
            Debug.LogError("O objeto inventoryPrefab não tem o script InventoryScript anexado.");
        }
    }
}
