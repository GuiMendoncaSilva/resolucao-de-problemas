using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class MessageStatusManagement : MonoBehaviour
{
    public GameObject messageStatus;
    public GameObject parentGameObject;
    public Sprite[] sprites;

    public void ShowMessage(Character character)
    {

        StartCoroutine(ShowMessageStatus(character));
    }

    private IEnumerator ShowMessageStatus(Character character)
    {
        GameObject messageObject = Instantiate(messageStatus, parentGameObject.transform);
        messageObject.transform.localScale = new Vector3(0.6f, 0.6f);
        Vector3 ballomPosition = new Vector3(parentGameObject.transform.position.x + 24, parentGameObject.transform.position.y + 16);
        messageObject.transform.position = ballomPosition; 


        GameObject emotionalStatusChild = GameObject.FindWithTag("EmotionalStatus");
        Debug.Log(emotionalStatusChild);
        
        Image emotionalStatusImage = emotionalStatusChild.GetComponent<Image>();

        int life = character.Life;

        if (life >= 80)
        {
            emotionalStatusImage.sprite = sprites[0];
        }
        else if (life >= 60)
        {
            emotionalStatusImage.sprite = sprites[1];
        }
        else if (life >= 40)
        {
            emotionalStatusImage.sprite = sprites[2];
        }
        else if (life >= 20)
        {
            emotionalStatusImage.sprite = sprites[3];
        }
        else
        {
            emotionalStatusImage.sprite = sprites[4];
        }
        
        yield return new WaitForSeconds(5f);
        Destroy(messageObject);
    }

}
