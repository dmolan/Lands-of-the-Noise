/*
 *  This code is executed only at the runtime.
 *  Functions used by the buttons in the "How To Use" Menu: "Fast Backward", "Backward" etc.
*/
using UnityEngine;
using UnityEngine.UI;

public class HowUsePages : MonoBehaviour
{
    public Button buttonFastBw, buttonBw, buttonFw, buttonFastFw;
    public GameObject slide1, slide2, slide3, slide4, slide5;

    private const int numOfSlides = 5;
    private int currSlide = 1;

    private void setSlide(int val)
    {
        slide1.SetActive(val == 1);
        slide2.SetActive(val == 2);
        slide3.SetActive(val == 3);
        slide4.SetActive(val == 4);
        slide5.SetActive(val == 5);
    }

    public void buttonFwPressed()
    {
        currSlide += 1;
        if (currSlide > numOfSlides) currSlide = numOfSlides;
        setSlide(currSlide);
    }
    public void buttonBwPressed()
    {
        currSlide -= 1;
        if (currSlide < 1) currSlide = 1;
        setSlide(currSlide);
    }
    public void buttonFastFwPressed()
    {
        currSlide = numOfSlides;
        setSlide(currSlide);
    }
    public void buttonFastBwPressed()
    {
        currSlide = 1;
        setSlide(currSlide);
    }

    void Start()
    {
        setSlide(currSlide);
    }
}
