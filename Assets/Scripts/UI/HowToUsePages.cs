﻿/*
 * This code is executed only at the runtime.
 * Functions used by the buttons in the "How To Use" Menu: "Fast Backward", "Backward" etc.
 */

using UnityEngine;
using UnityEngine.UI;

public class HowToUsePages : MonoBehaviour
{
    public Button buttonFastBw, buttonBw, buttonFw, buttonFastFw;
    public GameObject slide1, slide2, slide3, slide4, slide5, slide6, slide7, slide8;

    private const int NUM_OF_SLIDES = 8;
    public int currSlide = 1; // By default first slide



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
    }

    public void buttonForwardPressed()
    {
        currSlide += 1;
        if (currSlide > NUM_OF_SLIDES) currSlide = NUM_OF_SLIDES;
        setSlide(currSlide);
    }

    public void buttonBackwardPressed()
    {
        currSlide -= 1;
        if (currSlide < 1) currSlide = 1;
        setSlide(currSlide);
    }

    public void buttonFastForwardPressed()
    {
        currSlide = NUM_OF_SLIDES;
        setSlide(currSlide);
    }

    public void buttonFastBackwardPressed()
    {
        currSlide = 1;
        setSlide(currSlide);
    }
}
