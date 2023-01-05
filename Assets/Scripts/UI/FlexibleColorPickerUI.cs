using UnityEngine;
using UnityEngine.UI;

public class FlexibleColorPickerUI : MonoBehaviour 
{
    public MapGenerator mapGenerator;
    public FlexibleColorPicker fcp;
    public Button button;

    // This parameter is set from Unity Editor, because script works with multiple buttons
    public int indexOfButton;

    private void Start() 
    {
        button.image.color = mapGenerator.regions[indexOfButton].color;
        fcp.color = button.image.color;
        fcp.onColorChange.AddListener(onChangeColor);
    }

    private void onChangeColor(Color newColor) 
    {
        button.image.color = newColor;
        mapGenerator.regions[indexOfButton].color = newColor;
        mapGenerator.visualiseMap();
    }

    
}
