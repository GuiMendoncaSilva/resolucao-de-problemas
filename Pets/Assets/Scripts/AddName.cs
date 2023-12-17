using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddName : MonoBehaviour
{
    [SerializeField] static TMP_InputField b;
    public void addName() { 
        Gerenciador.nome = b.textComponent.text;
    }
}
