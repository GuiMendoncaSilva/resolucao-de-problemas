using Assets.SimpleLocalization.Scripts;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsManagement : MonoBehaviour
{
    [SerializeField] private AudioSource m_Source;
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        m_Source.volume = volume;  
    }

    public void SetQuality (int qualityIndex)
    {
        if (qualityIndex == 0) qualityIndex = 2;
        else if (qualityIndex == 2) qualityIndex = 0;

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetLanguage (int languageIndex)
    {
        if (languageIndex == 0)
        {
            LocalizationManager.Language = "english";
            MainManagement.language = "english";
        }
        else
        {
            LocalizationManager.Language = "portuguese-brazilian";
            MainManagement.language = "portuguese-brazilian";
        }
    }

    public void SetSelectedCharacter()
    {
        MainManagement.sectedCharacter = true;
    }
}
