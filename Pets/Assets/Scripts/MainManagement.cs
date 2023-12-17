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
    public static bool selectedCharacter = false;
    public static int[] characters;
    public static int amountCoins = 100;
    public static int amountDiamonds = 50;
    public static int[] amountItems = new int[12] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

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

        LoadGame();  
    }

    private static void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        Debug.Log("Amount" + amountItems[1]);

        if (data != null)
        {
            Debug.Log("Data exist");
            if (data.characters != null)
            {
                characters = data.characters;
                selectedCharacter = true;                
            }
            amountCoins = data.amountCoins;
            amountDiamonds = data.amountDiamonds;
            amountItems = data.amountItems;
        }
    }

    private void OnEnable()
    {
        SetDropdownLanguage();
        SetVolumeSlider();
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
        GameData gameData = new GameData();
        gameData.characters = characters;
        gameData.amountCoins = amountCoins; 
        gameData.amountDiamonds = amountDiamonds;
        gameData.amountItems = amountItems; 

        SaveSystem.SaveGame(gameData);

        if(selectedCharacter)
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

}
