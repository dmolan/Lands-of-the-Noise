using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguagesForText : MonoBehaviour
{
    public TextMeshProUGUI textMainMenuRun;
    public TextMeshProUGUI textMainMenuOptions;
    public TextMeshProUGUI textMainMenuExit;

    public TextMeshProUGUI textSettMenuTitle;
    public TextMeshProUGUI textSettMenuVolume;
    public TextMeshProUGUI textSettMenuLanguage;
    public TMP_Dropdown textSettMenuDrodown;

    public TextMeshProUGUI textAppSeed;
    public TextMeshProUGUI textAppLacunarity;
    public TextMeshProUGUI textAppPersistance;
    public TextMeshProUGUI textAppScale;
    public TextMeshProUGUI textAppOffsetSpeed;

    private void changeLanguageToUkr()
    {
        textMainMenuRun.text = "Запуск";
        textMainMenuOptions.text = "Опції";
        textMainMenuExit.text = "Вихід";

        textSettMenuTitle.text = "Опції";
        textSettMenuVolume.text = "Гучність";
        textSettMenuLanguage.text = "Мова";
        textSettMenuDrodown.options.Clear();
        textSettMenuDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Українська"});
        textSettMenuDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Англійська"}); 
        textSettMenuDrodown.captionText.text = "Українська";

        textAppSeed.text = "Зерно";
        textAppLacunarity.text = "Лакунарність";
        textAppPersistance.text = "Наполегливість";
        textAppScale.text = "Масштаб";
        textAppOffsetSpeed.text = "Швидкість зсуву";
    }

    private void changeLanguageToEng()
    {
        textMainMenuRun.text = "Run";
        textMainMenuOptions.text = "Options";
        textMainMenuExit.text = "Exit";

        textSettMenuTitle.text = "Settings";
        textSettMenuVolume.text = "Volume";
        textSettMenuLanguage.text = "Language";
        textSettMenuDrodown.options.Clear();
        textSettMenuDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Ukrainian"});
        textSettMenuDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "English"});
        textSettMenuDrodown.captionText.text = "English";

        textAppSeed.text = "Seed";
        textAppLacunarity.text = "Lacunarity";
        textAppPersistance.text = "Persistance";
        textAppScale.text = "Scale";
        textAppOffsetSpeed.text = "Offset Speed";
    }

    public void changeLanguage(int val)
    {
        if (val == 0) changeLanguageToUkr();
        else if (val == 1) changeLanguageToEng();
    }

    void Start()
    {
        changeLanguageToUkr();
    }
}
