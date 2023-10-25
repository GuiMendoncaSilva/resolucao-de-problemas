using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Teste : MonoBehaviour
{
    [SerializeField] Text teste;
    [SerializeField] Personagem personagem;
    // Start is called before the first frame update
    void Start()
    {
        teste.text = personagem.nome;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
