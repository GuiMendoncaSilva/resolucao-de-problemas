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

    private float waitTime = 10f;

    private void Awake()
    {
        if (MainManagement.characters == null) return;
        
        string currentScene = SceneManager.GetActiveScene().name;
        
        for (int i = 0; i < MainManagement.characters.Length; i++)
        {
            character = characterDatabase.GetCharacter(MainManagement.characters[i]);
            messageStatus = GetComponent<MessageStatusManagement>();
            if (currentScene == "MainGame")
            {
                StartCoroutine(UpdateStatusCharacter());
            }

        }
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
                Debug.LogError("O objeto dialogManagementScript n„o tem o script dialogManagementScript anexado.");
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
                    Debug.LogError("childImage n„o estÅEatribu˙Åo. Atribua um Sprite v·lido no Inspector ou atravÈs de cÛdigo.");
                }
            }
            else
            {
                Debug.LogError("O objeto com a tag 'Profile' n„o tem um componente SpriteRenderer.");
            }
        }
        else
        {
            Debug.LogError("Objeto com a tag 'Profile' n„o encontrado em ChildPrefab.");
        }
    }
}
