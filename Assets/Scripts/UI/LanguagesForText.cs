/*
 *  This code is executed only at the runtime.
 *  Contains functions for translating all text:
 *  1) ukr -> eng;
 *  2) eng -> ukr.
*/
using UnityEngine;
using TMPro;

public class LanguagesForText : MonoBehaviour
{
    public TextMeshProUGUI textMainMenuRun;
    public TextMeshProUGUI textMainMenuOptions;
    public TextMeshProUGUI textMainMenuExit;

    public TextMeshProUGUI textSettMenuTitle;
    public TextMeshProUGUI textSettMenuVolume;
    public TextMeshProUGUI textSettMenuLanguage;
    public TMP_Dropdown textSettMenuDrodownLanguage;
    public TextMeshProUGUI textSettMenuScale;
    public TMP_Dropdown textSettMenuDrodownScale;
    public TextMeshProUGUI textSettMenuBack;

    public TextMeshProUGUI textAppSeed;
    public TextMeshProUGUI textAppLacunarity;
    public TextMeshProUGUI textAppPersistance;
    public TextMeshProUGUI textAppScale;
    public TextMeshProUGUI textAppOffsetSpeed;

    public TextMeshProUGUI textPrefTitle;
    public TextMeshProUGUI textPrefWidth;
    public TextMeshProUGUI textPrefHeight;
    public TextMeshProUGUI textPrefMultiplier; 
    public TextMeshProUGUI textPrefOctaves; 
    public TextMeshProUGUI textPrefDrawMode;
    public TMP_Dropdown textPrefDrodown;
    public TextMeshProUGUI textPrefBack; 



    private void changeLanguageToUkr()
    {
        textMainMenuRun.text = "Запуск";
        textMainMenuOptions.text = "Опції";
        textMainMenuExit.text = "Вихід";

        textSettMenuTitle.text = "Опції";
        textSettMenuVolume.text = "Гучність";
        textSettMenuLanguage.text = "Мова";
        textSettMenuDrodownLanguage.options.Clear();
        textSettMenuDrodownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Українська"});
        textSettMenuDrodownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Англійська"}); 
        textSettMenuDrodownLanguage.captionText.text = "Українська";
        textSettMenuScale.text = "Масштаб";
        textSettMenuDrodownScale.options.Clear();
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "50%"});
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "100%"}); 
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "150%"}); 
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "200%"}); 
        textSettMenuDrodownScale.captionText.text = "100%";
        textSettMenuBack.text = "Назад";

        textAppSeed.text = "Зерно";
        textAppLacunarity.text = "Лакунарність";
        textAppPersistance.text = "Наполегливість";
        textAppScale.text = "Масштаб";
        textAppOffsetSpeed.text = "Швидкість зсуву";

        textPrefTitle.text = "Налаштування";
        textPrefWidth.text = "Ширина";
        textPrefHeight.text = "Висота";
        textPrefMultiplier.text = "Множник висоти";
        textPrefOctaves.text = "Октави";
        textPrefDrawMode.text = "Тип візулізації";
        textPrefDrodown.options.Clear();
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Шум"});
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Колір"}); 
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Сітка"}); 
        textPrefDrodown.captionText.text = "Сітка";
        textPrefBack.text = "Назад";
    }

    private void changeLanguageToEng()
    {
        textMainMenuRun.text = "Run";
        textMainMenuOptions.text = "Options";
        textMainMenuExit.text = "Exit";

        textSettMenuTitle.text = "Settings";
        textSettMenuVolume.text = "Volume";
        textSettMenuLanguage.text = "Language";
        textSettMenuDrodownLanguage.options.Clear();
        textSettMenuDrodownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Ukrainian"});
        textSettMenuDrodownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "English"});
        textSettMenuDrodownLanguage.captionText.text = "English";
        textSettMenuBack.text = "Back";

        textAppSeed.text = "Seed";
        textAppLacunarity.text = "Lacunarity";
        textAppPersistance.text = "Persistance";
        textAppScale.text = "Scale";
        textAppOffsetSpeed.text = "Offset Speed";

        textPrefTitle.text = "Preferences";
        textPrefWidth.text = "Width";
        textPrefHeight.text = "Height";
        textPrefMultiplier.text = "Mesh Height Multiplier";
        textPrefOctaves.text = "Octaves";
        textPrefDrawMode.text = "Draw Mode";
        textPrefDrodown.options.Clear();
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Noise"});
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Color"}); 
        textPrefDrodown.options.Add(new TMP_Dropdown.OptionData() {text = "Mesh"}); 
        textPrefDrodown.captionText.text = "Mesh";
        textSettMenuScale.text = "Scale";
        textSettMenuDrodownScale.options.Clear();
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "50%"});
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "100%"}); 
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "150%"}); 
        textSettMenuDrodownScale.options.Add(new TMP_Dropdown.OptionData() {text = "200%"}); 
        textSettMenuDrodownScale.captionText.text = "100%";
        textPrefBack.text = "Back";
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
