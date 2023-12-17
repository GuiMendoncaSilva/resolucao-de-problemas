using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagemColisão : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "inimigo" || collision.gameObject.tag == "limite")
        {
            GameOver();

        }
    }

    private void GameOver() 
    {
        SceneManager.LoadScene("MainGame");
    }
}
