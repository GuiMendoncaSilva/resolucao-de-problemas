using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAnimal : MonoBehaviour
{

    [SerializeField] Personagem personagem;
    [SerializeField] private Button ButtonRight;
    [SerializeField] private Button ButtonLeft;

    private void Awake()
    {
        ButtonRight.onClick.AddListener(UpdateAnimalha);
        ButtonLeft.onClick.AddListener(UpdateAnimalha2);
    }
    void Start(){
        AnimalList.Instance.selectAnimalIndex = 0;

    }
    private void UpdateAnimalha(){
        personagem.UpdateAnimais(AnimalList.Instance.GetNext());
       // AnimalList.Instance.selectAnimalIndex++;
    }

    private void UpdateAnimalha2(){
        personagem.UpdateAnimais(AnimalList.Instance.GetPrevious());
        //AnimalList.Instance.selectAnimalIndex--;
    }
}
