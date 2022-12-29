/*
 * This code is executed only at the runtime.
 * Functions used by the buttons in the "How Does It Work" Menu: "Fast Backward", "Backward" etc.
 */

using UnityEngine;
using UnityEngine.UI;

public class HowDoesItWorkPages : MonoBehaviour
{
    public Button buttonFastBackward, buttonBackward, buttonForward, buttonFastForward;
    public GameObject slide1, slide2, slide3, slide4, slide5, slide6, slide7, slide8, slide9, slide10;

    private const int NUMBER_OF_SLIDES = 10;
    public int currentSlide = 1; // By default first slide



    public void setSlide(int val)
    {
        slide1.SetActive(val == 1);
        slide2.SetActive(val == 2);
        slide3.SetActive(val == 3);
        slide4.SetActive(val == 4);
        slide5.SetActive(val == 5);
        slide6.SetActive(val == 6);
        slide7.SetActive(val == 7);
        slide8.SetActive(val == 8);
        slide9.SetActive(val == 9);
        slide10.SetActive(val == 10);
    }

    public void buttonForwardPressed()
    {
        currentSlide += 1;
        if (currentSlide > NUMBER_OF_SLIDES) currentSlide = NUMBER_OF_SLIDES;
        setSlide(currentSlide);
    }

    public void buttonBackwardPressed()
    {
        currentSlide -= 1;
        if (currentSlide < 1) currentSlide = 1;
        setSlide(currentSlide);
    }

    public void buttonFastForwardPressed()
    {
        currentSlide = NUMBER_OF_SLIDES;
        setSlide(currentSlide);
    }

    public void buttonFastBackwardPressed()
    {
        currentSlide = 1;
        setSlide(currentSlide);
    }
}
