using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public float currentXP;
    public float XPToLevelUp;
    public float currentLevel;

    void Start()
    {
        currentLevel = 1;
        currentXP = 0;
        XPToLevelUp = 2f;
        slider.maxValue = XPToLevelUp;
        slider.value = 0;
    }

    public void GainXP(float xp)
    {
        if (currentXP < XPToLevelUp)
        {
            currentXP += xp;
            if (currentXP > XPToLevelUp)
            {
                LevelUp();
            }
            slider.value = currentXP;
            
        }
        else
        {
            LevelUp();
        }

    }

    void LevelUp()
    {
        currentXP = 0;
        slider.value = 0;
        XPToLevelUp *= 1.5f;
        slider.maxValue = XPToLevelUp;
        currentLevel++;
        Debug.Log("congrats you are now level " + currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentXP >= XPToLevelUp)
        {
            LevelUp();
        }
    }
}
