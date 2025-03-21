/*
 * This code is executed only at the runtime.
 * Contains functions for translating all text:
 * 1) ukr -> eng;
 * 2) eng -> ukr.
 */

using UnityEngine;
using TMPro;

public class LanguagesForText : MonoBehaviour
{
    public int DEFAULT_LANGUAGE = 0; // English

    public enum LanguageNow {English, Ukrainian};
    public LanguageNow languageNow = LanguageNow.English;

    // Main Menu
    public TextMeshProUGUI mainMenuRun, mainMenuOptions, mainMenuExit, mainMenuHowUse, 
    mainMenuHowUseInfo, mainMenuHowWork, mainMenuHowWorkInfo, mainMenuCredits;

    // Settings Menu
    public TextMeshProUGUI settMenuTitle, settMenuLanguage, settMenuScale, settMenuBack, 
    settMenuRotationSensitivity, settMenuZoomingSpeed, settMenuAngleOfView, 
    settMenuCurrentDistance, settMenuRotationSmoothTime, settMenuDistanceLerpTime;
    public TMP_Dropdown settMenuDropdownLanguage, settMenuDropdownScale;

    // App
    public TextMeshProUGUI appSeed, appLacunarity, appPersistance, appScale, appOffsetSpeed;

    // Preferences
    public TextMeshProUGUI prefTitle, prefWidth, prefHeight, prefMultiplier, prefOctaves, 
    prefDrawMode, prefNote, prefProbabilityOfPlain, prefProbabilityOfGorge, prefBack;
    public TMP_Dropdown prefDropdown;

    // Credits
    public TextMeshProUGUI creditsTitle, creditsInfo, creditsBack;

    // How To Use
    public TextMeshProUGUI howUseBack;
    public TextMeshProUGUI howUseTitle1, howUseTitle2, howUseTitle3, howUseTitle4, howUseTitle5, howUseTitle6, howUseTitle7, howUseTitle8;
    public TextMeshProUGUI howUseInfo1, howUseInfo2, howUseInfo3, howUseInfo4, howUseInfo5, howUseInfo6, howUseInfo7, howUseInfo8;

    // How Does It Work
    public TextMeshProUGUI howWorkBack;
    public TextMeshProUGUI howWorkTitle1, howWorkTitle2, howWorkTitle3, howWorkTitle4, howWorkTitle5, 
    howWorkTitle6, howWorkTitle7, howWorkTitle8, howWorkTitle9, howWorkTitle10;
    public TextMeshProUGUI howWorkInfo1, howWorkInfo2, howWorkInfo3, howWorkInfo4, howWorkInfo5,
    howWorkInfo6, howWorkInfo7, howWorkInfo8, howWorkInfo9, howWorkInfo10;

    // Files
    public TextMeshProUGUI filesTitle, filesMapTitle, filesMapSave, filesMapLoad, filesPresetTitle, 
    filesPresetSave, filesPresetLoad, filesImageTitle, filesImageSaveToPNG, filesImageSaveToBMP,
    filesMapArithmeticTitle, filesMapArithmeticAdd, filesMapArithmeticSubtract, filesBack;

    // Static Points
    public TextMeshProUGUI staticPointsTitle, staticPointsAddNewPoint, staticPointsRemoveLastPoint,
    staticPointsClearAll, staticPointsXCoordinate, staticPointsYCoordinate, staticPointsNewPointHeight,
    staticPointsBack;

    // Colors
    public TextMeshProUGUI colorsTitle, colorsNote, colorsBack;



    private void changeLanguageToUkr()
    {
        // Main Menu
        {
        mainMenuRun.text = "Запуск";
        mainMenuOptions.text = "Опції";
        mainMenuExit.text = "Вихід";
        mainMenuHowUse.text = "Документація";
        mainMenuHowUseInfo.text = "Детальні інструкції для користувача";
        mainMenuHowWork.text = "Як це працює?"; 
        mainMenuHowWorkInfo.text = "Пояснення щодо роботи процедурної генерації";
        mainMenuCredits.text = "Подяки";
        }

        // Settings Menu
        {
        settMenuTitle.text = "Опції";
        settMenuLanguage.text = "Мова";
        settMenuDropdownLanguage.options.Clear();
        settMenuDropdownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Англійська"});
        settMenuDropdownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Українська"}); 
        settMenuDropdownLanguage.captionText.text = "Українська";
        settMenuScale.text = "Масштаб";
        settMenuDropdownScale.options.Clear();
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "50%"});
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "100%"}); 
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "150%"}); 
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "200%"}); 
        settMenuDropdownScale.captionText.text = "100%";

        settMenuRotationSensitivity.text = "Чутливість обертання";
        settMenuZoomingSpeed.text = "Чутливість зуму";
        settMenuAngleOfView.text = "Кут огляду";
        settMenuCurrentDistance.text = "Відстань до камери";
        settMenuRotationSmoothTime.text = "Інерційність обертання";
        settMenuDistanceLerpTime.text = "Швидкість зуму";

        settMenuBack.text = "Назад";
        }

        // App
        {
        appSeed.text = "Зерно";
        appLacunarity.text = "Лакунарність";
        appPersistance.text = "Посіченість";
        appScale.text = "Масштаб";
        appOffsetSpeed.text = "Швидкість зсуву";
        }

        // Preferences
        {
        prefTitle.text = "Уподобання";
        prefWidth.text = "Ширина";
        prefHeight.text = "Висота";
        prefMultiplier.text = "Множник висоти";
        prefOctaves.text = "Октави";
        prefDrawMode.text = "Тип візулізації";
        prefDropdown.options.Clear();
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Шум"});
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Колір"}); 
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Сітка"}); 
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Таблиця"}); 
        prefDropdown.captionText.text = "Сітка";
        prefNote.text = "Примітка: видно лише в збережених значеннях";
        prefProbabilityOfPlain.text = "Імовірність плоскогір'їв"; 
        prefProbabilityOfGorge.text = "Імовірність обривів"; 
        prefBack.text = "Назад";
        }

        // Credits
        {
        creditsTitle.text = "Подяка";
        creditsInfo.text = @"Спеціальна подяка
    1) Sebastian Lague - за чудові ютюб-уроки та ключову механіку: використання шуму Перлина для генерації Кольорової та Сіткової карт 
    2) Deniz Simsek - за гарний ютюб урок з повертання камери
    3) Gökhan Gökçe - за неймовірний ""Автономний Файловий Переглядач"" у відкритому доступі
    4) Avionx - за прекрасні текстури, використані на задньому плані в програмі
    5) Derrick Taylor з ""The Taylor Series"" - за зрозумілі та чіткі ілюстрації для ""Як це працює"" меню
    6) Craig Perko - за корисне ютюб відео про витоки пам'яті
    7) Flaticon and others - за прегарні значки для кнопок";
        creditsBack.text = "Назад";
        }
    
        // How To Use
        {
        howUseBack.text = "Назад";        
        howUseTitle1.text = "Документація";
        howUseTitle2.text = "1. Головне меню";
        howUseTitle3.text = "2. Опції";
        howUseTitle4.text = "3. Програма";
        howUseTitle5.text = "4. Уподобання";
        howUseTitle6.text = "5. Файли";
        howUseTitle7.text = "6. Статичні точки";
        howUseTitle8.text = "7. Кольори";
        howUseInfo1.text = @"Є шість найважливіших меню в програмі:
1) Головне меню;
2) Опції;
3) Програма;
4) Уподобання;
5) Файли;
6) Статичні точки.

Усі вони будуть детально описані на наступних слайдах.";
        howUseInfo2.text = @"У Головному меню є шість кнопок:
1) Запуск - відкриває головну частину програми;
2) Опції - відкриває меню Опцій (див. слайд 2);
3) Вихід - закриє програму;
4) Як використовувати? - веде до меню, де можна навчитися користуванню інтерфейсом;
5) Як це працює? - веде до меню, де можна зрозуміти як працює процедурна генерація;
6) Подяки - відкриває слайд з подяками.";
    howUseInfo3.text = @"В Опціях є декілька елементів:
1) ""Мова"" спадний список - можна вибрати мову;
2) ""Масштаб"" спадний список - можна змінювати масштаб карти.;
3) ""Чутливість обертання"" - на скільки камера повертається при русі мишки
4) ""Чутливість зуму"" - наскільки швидко карта наближаться/віддаляється
5) ""Плавність обертання"" - наскільки скоро камера перестане обертатися (більше чило - довше)
6) ""Плавність зуму"" - наскільки скоро камера перестане наближатися/віддалятися (більше чило - довше)
7) ""Відстань до камери"" - змінює стандартну відстань від камери до центру карти
8) ""Кут огляду"" - змінєю кут між картою й камерою (від 0 до 90 градусів)";
        howUseInfo4.text = @"У Програмі є декілька елементів:
1) Поле вводу ""Зерно"" у лівому-верхньому куті - сюди можна ввести зерно для карти (див. ""Як це працює?"");
2) Чотири позунки в правому-верхньому куті - змінюють параметри генерації карти (див. ""Як це працює?"");
3) Кнопка з символом графіка в правому нижньому куті - відкриває меню ""Статичні точки"";
4) Кнопка з символом папки в правому нижньому куті - відкриває меню ""Файли"";
5) Кнопка з символом коліщатка в правому нижньому куті - відкриває меню ""Уподобання"";
6) Кнопка ""Назад"" - вертає в головне меню.

Примітка: у цьому меню щоб обертати камеру горизонтально, потрібно затиснути Праву Кнопку Миші, а щоб обертати камеру вертикально - ""Ctrl"" + Праву Кнопку Миші.";
        howUseInfo5.text = @"В ""Уподобаннях"" є декілька елементів:
1) Поля вводу ""Ширина""/""Висота"" - встановлюють ширину/висоту, не більшу ніж 300 через технічні причини;
2) Повзунок ""Октави"" - змінює кількість октав (див. ""Як це працює?"");
3) Спадний список ""Тип візулізації"" - змінює тип візуалізації (значення в кожній точці ті ж, але відображаються через Чорний/Білий, Різні кольори або Обє'мну фігуру);
4) Кнопка ""Назад"" - вертає в головне меню.";
        howUseInfo6.text = @"У ""Файлах"" є декілька елементів:
1) ""Зберегти""/""Завантажити"" під текстом ""Карта"" - зберігає всю карту в ""txt"" як таблицю, або завантажує мапу за п'ятьма числами;
2) ""Зберегти""/""Завантажити"" під текстом ""Поточний проєкт"" - зберігає усі значення в ""txt"", або завантажує всі значення з ""txt"";
3) ""PNG""/""BMP"" під текстом ""Зображення"" - зберігає мапу в ""PNG"" або ""BMP"";
4) ""Додати""/""Відняти"" під текстом ""Арифметика карт"" - додавання/віднімання карт, які були збережені раніше.";     
        howUseInfo7.text = @"У ""Статичних точках"" є декілька елементів:
1) Кнопка зі знаком плюс - додає статичну точку з координатами й висотою, взятими з полів ліворуч;
2) Кнопка зі знаком мінус - витирає останню статичну точку;
3) Кнопка із символом урни - витирає всі статичні точки.";
        howUseInfo8.text = @"У меню ""Кольори"" є дві групи елементів:
1) Вісім кольорових кнопок - кожна відкриє меню вибирання кольору з кольором кнопки за промовчанням; вибраний колір буде застосовано до мапи з висотою попорційною індексу кнопки;
2) Меню вибирання кольору - тут можна тягати різні повзунки щоб отримати бажаний колір, який буде застосовано до кнопки, яку було натиснуто останньою.";
        }
    
        // How Does It Work
        {
        howWorkBack.text = "Назад";
        howWorkTitle1.text = @"Пояснення ""Процедурної генерації""";
        howWorkTitle2.text = "1. Використання зерна";
        howWorkTitle3.text = "2. Блоки й Перетини";
        howWorkTitle4.text = @"3. Отримання ""шорстких"" карт";
        howWorkTitle5.text = "4. Лінійна інтерполяція";
        howWorkTitle6.text = @"5. Метод ""Плавного кроку""";
        howWorkTitle7.text = "6. Перша октава";
        howWorkTitle8.text = "7. Лакунарність";
        howWorkTitle9.text = "8. Деталізованість";
        howWorkTitle10.text = "9. Останній етап";
        howWorkInfo1.text = @"У Процедурній генерації методом шуму Перлина (Фрактального) є п'ять ключових кроків:
1) Отримання безперервного Потоку чисел із зерна;
2) Поділ карти на Блоки уявними лініями, присвоєння кожному перетину ліній випадково повернутого одничного вектора;
3) Отримання чотирьох шорстких карт;
4) Використання Лінійної інтерполяції та методу ""Плавного кроку"" на двох парах карт;
5) Додавання наступних октав.

Кожен з кроків буде детально пояснено на наступних слайдах. 

Приклад багатооктавної карти можна бачити на #1.";
        howWorkInfo2.text = @"Щоб отримати випадкові значення із заданого зерна, використаймо Генератор ПсевдоВипадкових Чисел (ГПВЧ): за заданим зерном завжди повертає однаковий набір цифр.

Примітка: називається ""ПсевдоВипадкових Чисел"", бо насправді є алгоритм, але для наших цілей його випадковості достатньо.";
        howWorkInfo3.text = @"Намалюймо уявну сітку на нашій карті (роздільна здатність визначає її розмір), кожній точці перетину ліній присвоймо одиничний повернутий на кут із зерна вектор. Наприклад, якщо будемо брати двоцифрові числа з Потоку, матимемо 32 варінти повороту для кожного вектора (див. #1). 

Варто додати, що присвоювати числа рекомендовано по спіралі, що глядач бачив ""свіжі"" блоки в кожному напряку (див. #2).";
        howWorkInfo4.text = @"Присвоймо кожному Блоку чотири скаляри (числа) використовуючи скалярний векторний добуток (див. #1), таким чином отримавши чотири клітинчасті карти (див. #2). Для візулізації, присвоймо чорний колір мінімальному значенню, білий - максимальному.";
        howWorkInfo5.text = @"Змішаймо дві пари карт між собою горизонтально, а результати - вертикально. Перша частина змішування є ""Лінійна інтерполяція"" - процес побудови кривої між двома відрізками (див. #1). Інтерполюваваши між кожними двома відповідними відрізками на зрізі карти, отримуємо дещо зглажену версію-нащадок попередньої пари карт (див. #2).";
        howWorkInfo6.text = @"Проте там, де криві сходяться, виникають гострі куточки (див #1 і #2). Щоб їх згладити, використаймо метод ""Плавного кроку"" (див. #3) й отримаймо згладжену криву-нащадок двох кривих з минулих карт (див. #4). Як наслідок, отримуємо карту, згладжену в одному напрямку (див. #5).";
        howWorkInfo7.text = @"Тепер можемо змішати дві пари з чотирьох карт (див. #1), а їхні результати - між собою вертикально й отримати те, що називають ""Перша Октава"" шуму Перлина (див. #2)";
        howWorkInfo8.text = @"Для того щоб підвищити деталізованість карти, згенеруймо нові Октави з щільнішими сітками, а наскільки щільнішими визначає параметр ""Лакунарність"". Наприклад, якщо Лакунарність дорівнює 2, сітка другої октави вдвічі більша (див. #1 і #2) і т.д. Але якщо ми просто додамо нові Октави до старої, отримаємо щось схоже на Білий шум (див. #3).";
        howWorkInfo9.text = @"Рішенням до попередньої проблеми є введенення парамерта ""Деталізованість"", який визначає ваговий множник, з яким октава додається до першої. Так, якщо Деталізованість дорівнює ""0.5"", вплив кожної нової октави вдвічі менше ніж вплив попередньої (див. #1). Отож, маємо фінальний результат (див. #2).

Примітка: потрібно знайти новий мінімум і максимум та переприсвоїти кольори після цього.";
        howWorkInfo10.text = @"Маючи Шумову карту (див. #1), можемо присвоїти різним діапазонам в межах 0-1 різні кольори (див. #2), або навіть сконструювати об'ємну фігуру - Сітку (див. #3). А наскільки високою буде Сітка, визначає множник у меню ""Уподобання"". Оскільки ми використовуємо ГПВЧ, можемо змінювати масштаб карти, рухати її тощо.";     
        }
    
        // Files
        {
            filesTitle.text = "Файли"; 
            filesMapTitle.text = "Карта";
            filesMapSave.text = "Зберегти"; 
            filesMapLoad.text = "Завантажити"; 
            filesPresetTitle.text = "Поточний проєкт"; 
            filesPresetSave.text = "Зберегти"; 
            filesPresetLoad.text = "Завантажити"; 
            filesImageTitle.text = "Зображення"; 
            filesImageSaveToPNG.text = "PNG"; 
            filesImageSaveToBMP.text = "BMP";
            filesMapArithmeticTitle.text = "Арифметика Карт"; 
            filesMapArithmeticSubtract.text = "Відняти"; 
            filesMapArithmeticAdd.text = "Додати"; 
            filesBack.text = "Назад";
        }

        // Static Points
        {
            staticPointsTitle.text = "Статичні точки";
            staticPointsAddNewPoint.text = "Додати нову точку";
            staticPointsRemoveLastPoint.text = "Прибрати останню точку";
            staticPointsClearAll.text = "Очистити все";
            staticPointsXCoordinate.text = "Координата X нової точки";
            staticPointsYCoordinate.text = "Координата Y нової точки";
            staticPointsNewPointHeight.text = "Висота нової точки";
            staticPointsBack.text = "Назад";
        }
    
        // Colors
        {
            colorsTitle.text = "Кольори";
            colorsNote.text = "Примітка: натисність на колір щоб змінити";
            colorsBack.text = "Назад";
        }
    }

    private void changeLanguageToEng()
    {
        // Main Menu
        {
        mainMenuRun.text = "Run";
        mainMenuOptions.text = "Options";
        mainMenuExit.text = "Exit";
        mainMenuHowUse.text = "How to use?";
        mainMenuHowUseInfo.text = "See detailed instructions for Graphical User Interface";
        mainMenuHowWork.text = "How does it work?"; 
        mainMenuHowWorkInfo.text = "See explanation on how does procedural generation works";
        mainMenuCredits.text = "Credits";
        }

        // Settings Menu
        {
        settMenuTitle.text = "Settings";
        settMenuLanguage.text = "Language";
        settMenuDropdownLanguage.options.Clear();
        settMenuDropdownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "English"});
        settMenuDropdownLanguage.options.Add(new TMP_Dropdown.OptionData() {text = "Ukrainian"});
        settMenuDropdownLanguage.captionText.text = "English";

        settMenuRotationSensitivity.text = "Mouse Sensitivity";
        settMenuZoomingSpeed.text = "Zooming Speed";
        settMenuAngleOfView.text = "Angle Of View";
        settMenuCurrentDistance.text = "Camera Distance";
        settMenuRotationSmoothTime.text = "Inertia of rotation";
        settMenuDistanceLerpTime.text = "Distance Smoothing";

        settMenuBack.text = "Back";
        }

        // App
        {
        appSeed.text = "Seed";
        appLacunarity.text = "Lacunarity";
        appPersistance.text = "Persistance";
        appScale.text = "Scale";
        appOffsetSpeed.text = "Offset Speed";
        }

        // Preferences
        {
        prefTitle.text = "Preferences";
        prefWidth.text = "Width";
        prefHeight.text = "Height";
        prefMultiplier.text = "Mesh Height Multiplier";
        prefOctaves.text = "Octaves";
        prefDrawMode.text = "Draw Mode";
        prefDropdown.options.Clear();
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Noise"});
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Color"}); 
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Mesh"}); 
        prefDropdown.options.Add(new TMP_Dropdown.OptionData() {text = "Table"}); 
        prefDropdown.captionText.text = "Mesh";
        settMenuScale.text = "Scale";
        settMenuDropdownScale.options.Clear();
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "50%"});
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "100%"}); 
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "150%"}); 
        settMenuDropdownScale.options.Add(new TMP_Dropdown.OptionData() {text = "200%"}); 
        settMenuDropdownScale.captionText.text = "100%";
        prefNote.text = "Note: visible only in saved values";
        prefProbabilityOfPlain.text = "Probability of Plain"; 
        prefProbabilityOfGorge.text = "Probability of Gorge"; 
        prefBack.text = "Back";
        }

        // Credits
        {
        creditsTitle.text = "Credits";
        creditsInfo.text = @"Special thanks to 
    1) Sebastian Lague - for wonderful YouTube tutorials and core feature of using Perlin Noise for Color and Mesh Maps generation;
    2) Deniz Simsek - for great camera-rotation tutorial on YouTube;
    3) Gökhan Gökçe - for amazing Standalone File Browser project on GitHub;
    4) Avionx - for gorgeus assets used in app background;
    5) Derrick Taylor from ""The Taylor Series"" - for clear illustrations used in ""How Does It Work"" menu;
    6) Craig Perko - for helpful YouTube video on memory leaks;
    7) Flaticon and others - for gorgeous icons.";
        creditsBack.text = "Back";
        }
    
        // How To Use
        {
        howUseBack.text = "Back";
        howUseTitle1.text = "How to use?";
        howUseTitle2.text = "1. Main Menu";
        howUseTitle3.text = "2. Options Menu";
        howUseTitle4.text = "3. App";
        howUseTitle5.text = "4. Preferences";
        howUseTitle6.text = "5. Files";
        howUseTitle7.text = "6. Static points";
        howUseTitle8.text = "7. Colors";
        howUseInfo1.text = @"There are six most important menus in the app:
1) Main Menu;
2) Options Menu;
3) App;
4) Preferences
5) Files
6) Static points

Each of them will be covered in details on the following slides.";
        howUseInfo2.text = @"There are six buttons in the Main Menu:
1) Run - this button will start main part: the App;
2) Options - this button will open Options Menu (see Options Menu slide);
3) Exit - this button will close application;
4) HowToUse - this button is leading to the tutorial menu, where you can learn what each button do;
5) HowDoesItWork - this button is leading to the tutorial menu, where you will learn how does procedural generation works;
6) Credits - this button will open Credits Slide.";
        howUseInfo3.text = @"There are several elements in the Options Menu:
1) ""Language"" Dropdown - here you can choose which language suits you best;
2) ""Scale"" Dropdown - here you can choose the scale of all elements in app;
3) ""Rotation Sensitivity"" - changes how much will camera rotate on mouse movement;
4) ""Zooming Sensitivity"" - changes how fast will mouse wheel zoom in/out;
5) ""Rotation Smoothing"" - how fast will camera stop rotating (bigger number - more time);
6) ""Distance Smoothing"" - how fast will camera stop zooming in/out (bigger number - more time);
7) ""Camera Distance"" - changes default camera distance to the map center;
8) ""Angle Of View"" - changes angle between the map's plane and camera (0 to 90 degrees).";
        howUseInfo4.text = @"There are several elements in the App:
1) ""Seed"" input field in the left-up corner - here you can write number which will give you a unique map (see ""How Does It Work"" for more);
2) Four sliders in the right-up corner - with these you can change map generaitng values (see ""How Does It Work"" for more);
3) Button with graph symbol in the right-down corner - opens menu ""Static points"";
4) Button with folder symbol in the right-down corner - opens menu ""Files"";
5) Button with wheel symbol in the right-down corner - opens menu ""Preferences"";
6) ""Back"" button in the left-down corner - will lead you back to the App.

Note: in this menu you can hold Right Mouse Button to rotate camera horizontally and hold Control+Right Mouse Button to rotate camera vertically.";
        howUseInfo5.text = @"There are several elements in the Preferences:
1) ""Width""/""Height"" input fields - here you can write desired map's width/height (note: you cant write numbers bigger than 300 for technical reasons);
2) ""Octaves"" sliders - with this you can change amount of octaves for the map;
3) ""Draw mode"" dropdown - you can choose options of displaying the map (same values, but numbers are given color and height in ""Color Map"" and ""Mesh"" respectively);
4) ""Back"" button - will lead you back to the App.";
        howUseInfo6.text = @"There are several elements in the Files menu:
1) ""Save""/""Load"" under ""Map"" text - saves whole map in ""txt"" as table, or loads map by 5 integer values;
2) ""Save""/""Load"" under ""Preset"" text - saves all settings in ""txt"", or loads all settings from ""txt"";
3) ""PNG""/""BMP"" under ""Image"" text - saves saves map into ""PNG"" or ""BMP"" file types;
4) ""Add""/""Subtract"" under ""Map Arithmetics"" text - allows you to add/subtract map, saved previously.";     
        howUseInfo7.text = @"There are several elements in the Static Points menu:
1) Button with plus sign - adds Static Point with coordinates and height from input filed on the left of it;
2) Button with minus sign - removes last Static Point;
3) Button with bin sign - removes all Static Points.";
        howUseInfo8.text = @"There are two groups of elements in the Colors menu:
1) Eight colorful buttons - each will open color picker starting with button's color; chosen color will be applied to map with height corresponding to button's index;
2) Color picker menu - here you can drag different sliders to get desired color for last clicked button.";
        }

        // How Does It Work
        {
        howWorkBack.text = "Back";
        howWorkTitle1.text = "An overview of Procedural Generation";
        howWorkTitle2.text = "1. Using seed";
        howWorkTitle3.text = "2. Chunks and interceptions";
        howWorkTitle4.text = "3. Getting four non-smooth maps";
        howWorkTitle5.text = "4. Lerping";
        howWorkTitle6.text = "5. Smooth Stepping";
        howWorkTitle7.text = "6. First Octave";
        howWorkTitle8.text = "7. Lacunarity";
        howWorkTitle9.text = "8. Persistance";
        howWorkTitle10.text = "9. Finishing";
        howWorkInfo1.text = @"There are four most important steps in procedural generation using Perlin (Fractal) noise:
1) Getting continious stream of numbers from seed;
2) Dividing map into chunks, assigning each borders interception a vector;
3) Getting four non-smooth maps;
4) Lerping and Smooth stepping two pairs of maps.
5) Adding octaves

Each of them will be covered in details on the following slides. 

The example of several-octave map can be seen on #1.";
        howWorkInfo2.text = @"In order to get random values by the given seed, we can use Pseudo-Random Number Generator (PRNG): by the given seed it will always return same Stream of digits.

Note: it's called ""Pseudo-Random"" because there's an algorithm behind it, but for our purposes it's randomnes is good enough.";
        howWorkInfo3.text = @"We will draw an imaginary grid over the map and on each point of interception assing vector of length 1, each rotated by the number from seed. For example, if we will take a 2-digit numbers from the Stream, we will have 32 rotations for vectors (see #1). 

It is worth noting that we should assign values in a spiral, so that in whatever direction the viewer goes, there will be a fresh chunk (see #2).";
        howWorkInfo4.text = @"Now we will assign to each chunk 4 scalar values (a numbers) using dot product (see #1) thus getting 4 tiled maps (see #2). For the visualisation purposes we can assign minimal value to black, maximum - to white.";
        howWorkInfo5.text = @"We will blend two pairs of maps horizontaly and then resulting maps - vertically. First part of blending is Lerping (lineary interpolating) - process of drawing curve between two lines (see #1). And so we lerp between every curve in the cross section of the map getting smoothed in one direction (horizontal or vertical) map (see #2).";
        howWorkInfo6.text = @"We still have some problem - there are sharp corners where lerped curves meet (see #1 and #2), those are called ""kinks"" in calculus. To smooth them we will use Smooth Stepping function (see #3) and get smoothed curve (see #4). As a result of Lepring and Smooth Stepping we get a smoothed in one direction map (see #5) from the two tiled maps.";
        howWorkInfo7.text = @"Now we can blend 2 pairs of maps horizontaly (see #1), and do the same thing with results - blend them vertically, which will result in One octave of Perlin Noise (see #2)";
        howWorkInfo8.text = @"In order to make more details on the map, we can generate new map (new octave) with bigger grid, and how much bigger is determined by ""Lacunarity"". So if Lacunarity equals 2, the grid of the second map will be two times bigger (see #1 and #2) and so on. But if we will simply add those additional octaves, we will get something similar white noise (see #3).";
        howWorkInfo9.text = @"The solution to previous problem is making parameter ""Persistance"". So if the Persistance is set to 0.5, every octave will be half smaller (see #1). Then we can simply add those diminished octaves and get final result (see #2).

Note: you will need to find minimum and maximum values of the map, and reassign colors.";
        howWorkInfo10.text = @"Now that we have the Noise Map (see #1), we can assign different colors to different values (see #2), or even make Height Map (Mesh) from Noise Map (see #3). How high the Mesh will be controls ""Mesh Height Multiplier"". Because we are using PRNG, we can scale our map, change it's size, and move it.";        
        }
    
        // Files
        {
            filesTitle.text = "Files"; 
            filesMapTitle.text = "Map";
            filesMapSave.text = "Save"; 
            filesMapLoad.text = "Load"; 
            filesPresetTitle.text = "Preset"; 
            filesPresetSave.text = "Save"; 
            filesPresetLoad.text = "Load"; 
            filesImageTitle.text = "Image"; 
            filesImageSaveToPNG.text = "PNG"; 
            filesImageSaveToBMP.text = "BMP";
            filesMapArithmeticTitle.text = "Map Arithmetic"; 
            filesMapArithmeticSubtract.text = "Subtract"; 
            filesMapArithmeticAdd.text = "Add"; 
            filesBack.text = "Back";
        }

        // Static Points
        {
            staticPointsTitle.text = "Static Points";
            staticPointsAddNewPoint.text = "Add New Point";
            staticPointsRemoveLastPoint.text = "Remove Last Point";
            staticPointsClearAll.text = "Clear All";
            staticPointsXCoordinate.text = "New Point's X coordinate";
            staticPointsYCoordinate.text = "New Point's Y coordinate";
            staticPointsNewPointHeight.text = "New Point's Height";
            staticPointsBack.text = "Back";
        }
    
        // Colors
        {
            colorsTitle.text = "Colors";
            colorsNote.text = "Note: tap on the color to change it";
            colorsBack.text = "Back";
        }
    }

    public void changeLanguage(int val)
    {
        if (val == 0) 
        {
            changeLanguageToEng();
            languageNow = LanguageNow.English;
        }
        else if (val == 1) 
        {
            changeLanguageToUkr();
            languageNow = LanguageNow.Ukrainian;
        }
    }
}
