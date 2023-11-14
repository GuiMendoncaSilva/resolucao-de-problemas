using Assets.SimpleLocalization.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManagement : MonoBehaviour
{
    public static string language = "english";
    public static float volumeSound = 1f;
    public static bool muted = false;
    public static bool sectedCharacter = false;

    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Slider slider;

    public void Awake()
    {
        LocalizationManager.Read();

        LocalizationManager.Language = language;

        if (dropdown != null)
        {
            SetDropdownLanguage();
        }
  
    }

    public void SetDropdownLanguage()
    {
        if (language.Equals("english"))
        {
            dropdown.SetValueWithoutNotify(0);
        }
        else
        {
            dropdown.SetValueWithoutNotify(1);
        }
    }
    public void SetVolumeSlider()
    {
        if (slider != null) 
            slider.SetValueWithoutNotify(volumeSound);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        if(sectedCharacter)
        {
            SceneManager.LoadScene("MainGame"); 
        }
        else
        {
            SceneManager.LoadScene("SelectionCharacter");
        }

    }

    public void ReturnToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        SetDropdownLanguage();
        SetVolumeSlider();
    }
}
