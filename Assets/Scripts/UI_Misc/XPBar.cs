using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public GameObject upgradeMenu;
    public GameObject firstButton;
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
        Time.timeScale = 0;
        upgradeMenu.SetActive(true);
        currentXP = 0;
        slider.value = 0;
        XPToLevelUp *= 1.5f;
        slider.maxValue = XPToLevelUp;
        currentLevel++;

        // clear and set a new selected object
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);

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
