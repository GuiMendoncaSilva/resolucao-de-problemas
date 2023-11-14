using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterBehaviour : MonoBehaviour
{

    public CharacterDatabase characterDatabase;
    public GameObject childPrefab;
    public Sprite childImage;
    public Sprite died;
    private GameObject childObject;
    private Character character;
    private MessageStatusManagement messageStatus;

    private int selectedOption = 0;
    private float waitTime = 10f;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        character = characterDatabase.GetCharacter(selectedOption);
        messageStatus = GetComponent<MessageStatusManagement>();
        StartCoroutine(UpdateStatusCharacter());
    }

    private IEnumerator UpdateStatusCharacter()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime); 
            character.DecrementStatus();
            Debug.Log("Character: " + character);
            messageStatus.ShowMessage(character);
            if (character.Life == 0) break;
        }
        CharacterDied();
    }

    private void CharacterDied()
    {
        Animator animator = GetComponent<Animator>();
        Image image = GetComponent<Image>();
        Debug.Log(animator);

        if (image != null && animator != null)
        {
            animator.enabled = false;
            image.sprite = died;
        }
    }

    public void OnMouseDown()
    {        
        if (childObject == null && SceneManager.GetActiveScene().name.Equals("MainGame"))
        {
            childObject = Instantiate(childPrefab, transform.position, Quaternion.identity);

            SetSpriteProfile();
            SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = childImage;
            }
 
            childObject.transform.parent = transform;
            DialogManagement dialogManagementScript = childObject.GetComponent<DialogManagement>();

            if (dialogManagementScript != null)
            {
                dialogManagementScript.SetInitialCharacter(character);
                float life = 1 - (float)character.Life / 100f;
                float energy = 1 - (float)character.Energy / 100f;
                float satiation = 1 - (float)character.Satiation / 100f;
                dialogManagementScript.SetSliderValues(life, energy, satiation);
            }
            else
            {
                Debug.LogError("O objeto dialogManagementScript não tem o script dialogManagementScript anexado.");
            }
        }
    }

    private void SetSpriteProfile()
    {
        GameObject profileObject = GameObject.FindWithTag("Profile");

        if (profileObject != null)
        {
            Image imageComponent = profileObject.GetComponent<Image>();

            if (imageComponent != null)
            {
               
                if (childImage != null)
                {
                    imageComponent.sprite = childImage;
                }
                else
                {
                    Debug.LogError("childImage não está atribuído. Atribua um Sprite válido no Inspector ou através de código.");
                }
            }
            else
            {
                Debug.LogError("O objeto com a tag 'Profile' não tem um componente SpriteRenderer.");
            }
        }
        else
        {
            Debug.LogError("Objeto com a tag 'Profile' não encontrado em ChildPrefab.");
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
