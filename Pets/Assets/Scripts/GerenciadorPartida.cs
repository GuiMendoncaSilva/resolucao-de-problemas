using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPartida : MonoBehaviour
{
    // Start is called before the first frame update
    private bool partidaInicianda;

    private void Awake()
    {
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (partidaInicianda) return;
        if(Input.GetMouseButton(0)) {
            partidaInicianda = true;
            Time.timeScale = 1;
        }
    }
}
