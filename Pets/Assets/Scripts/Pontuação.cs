using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuação : MonoBehaviour
{
    // Start is called before the first frame update
    private float tempo;
    private int pontuacao;
    [SerializeField]private TMP_Text pontuacaoText;

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        pontuacao = (int)(tempo * 5);
        if(pontuacao > Gerenciador.recorde)Gerenciador.recorde = pontuacao;
        pontuacaoText.text = pontuacao.ToString("000000");
    }
}
