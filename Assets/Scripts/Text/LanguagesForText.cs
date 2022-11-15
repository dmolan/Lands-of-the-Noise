using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguagesForText : MonoBehaviour
{
    public enum Language {English, Ukrainian};

    Language language = Language.Ukrainian;

    public TextMeshProUGUI textMainMenuRun;
    public TextMeshProUGUI textMainMenuOptions;
    public TextMeshProUGUI textMainMenuExit;

    public TextMeshProUGUI textSettingsMenuTitle;
    public TextMeshProUGUI textSettingsMenuVolume;
    public TextMeshProUGUI textSettingsMenuLanguage;



    void Start()
    {
        if (language == Language.English)
        {
            textMainMenuRun.text = "Run";
            textMainMenuOptions.text = "Options";
            textMainMenuExit.text = "Exit";

            textSettingsMenuTitle.text = "Settings";
            textSettingsMenuVolume.text = "Volume";
            textSettingsMenuLanguage.text = "Language";

        }
        if (language == Language.Ukrainian)
        {
            textMainMenuRun.text = "Запуск";
            textMainMenuOptions.text = "Опції";
            textMainMenuExit.text = "Вихід";

            textSettingsMenuTitle.text = "Опції";
            textSettingsMenuVolume.text = "Гучність";
            textSettingsMenuLanguage.text = "Мова";
        }
    }
}
