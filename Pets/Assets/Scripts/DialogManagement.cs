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

    private void SetName()
    {
        if (name == null) return;
        textName.text = Gerenciador.giveName();
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
        SetName();
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

        Debug.Log(inventoryScript);

        if (inventoryScript != null)
        { 
            inventoryScript.SetInitialCharacter(character);
            inventoryScript.SetDialogManagement(this);
        }
        else
        {
            Debug.LogError("O objeto inventoryPrefab não tem o script InventoryScript anexado.");
        }
    }
}
