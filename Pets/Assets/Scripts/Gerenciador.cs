using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Gerenciador : MonoBehaviour
{

    [SerializeField] TMP_InputField b;
    // Start is called before the first frame update
    public static string nome;
    public static int recorde = 0;
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static string giveName() {
        return nome;
    }

    public void setName()
    {
        nome = b.text;
    }



}
