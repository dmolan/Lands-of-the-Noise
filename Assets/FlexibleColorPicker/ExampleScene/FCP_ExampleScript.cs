using UnityEngine;
using UnityEngine.UI;

public class FCP_ExampleScript : MonoBehaviour 
{
    public bool getStartingColorFromMaterial;
    public FlexibleColorPicker fcp;
    public GameObject fcpGameObject;
    public Button button;

    private void Start() 
    {
        if (getStartingColorFromMaterial)
        {
            // fcp.color = material.color;
            fcp.color = button.image.color;
        }

        fcp.onColorChange.AddListener(OnChangeColor);
    }

    private void OnChangeColor(Color co) 
    {
        button.image.color = co;
        // material.color = co;
    }
}
