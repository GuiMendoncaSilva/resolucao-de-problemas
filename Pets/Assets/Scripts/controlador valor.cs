using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controladorvalor : MonoBehaviour
{
    [SerializeField] private TMP_Text pontuacaoText;
    [SerializeField] private Button botao;
    // Start is called before the first frame update

    private void Awake()
    {
        botao.onClick.AddListener(abrir);
    }

    void Start()
    {
        pontuacaoText.text = Gerenciador.recorde.ToString("000000");
    }

    private void abrir()
    {
        SceneManager.LoadScene("Minigame");
    }

}
