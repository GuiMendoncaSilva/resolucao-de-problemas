using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image animalImage;
    void Start()
    {
        
    }

    // Update is called once per frame

    internal void UpdateAnimais(CharacterStats characterStats){
        animalImage.sprite = characterStats.animal;
    }
}
