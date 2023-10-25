using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpdateAnimal : MonoBehaviour
{

    [SerializeField] Personagem personagem;
    [SerializeField] private Button ButtonRight;
    [SerializeField] private Button ButtonLeft;
    [SerializeField] private Button SelectButton;
    [SerializeField] private TMP_InputField AnimalText;

    private void Awake()
    {
        ButtonRight.onClick.AddListener(UpdateAnimalha);
        ButtonLeft.onClick.AddListener(UpdateAnimalha2);
        SelectButton.onClick.AddListener(selecionar);
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

    private void selecionar()
    {
        SceneManager.LoadScene("MainScene");
        personagem.nome = AnimalText.text;
    }
}
