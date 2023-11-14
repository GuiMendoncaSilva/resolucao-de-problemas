using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        LocalizationManager.Read();

        LocalizationManager.Language = "english";
    }
}
