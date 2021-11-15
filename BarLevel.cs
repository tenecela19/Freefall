using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLevel : MonoBehaviour
{
    public static bool IsStarting;
    public NextLevel nextlevel;
    public Image imageBar;

    private void Awake()
    {
        IsStarting = false;
        imageBar.fillAmount = 0.0f;
        nextlevel = new NextLevel();
        
    }

    private void Update()
    {
            nextlevel.Update();
            imageBar.fillAmount = nextlevel.GetLevelNormalized();       
    }
}

public class NextLevel {
    public const int lEVEL_BAR = 100;
    public float LEVELAmount;
    float LevelRegeneration;

    public NextLevel() {
        LEVELAmount = 0;
        LevelRegeneration = 23.5f;
    }

    public void Update() {
        if (GameController.GameOver == false && BarLevel.IsStarting == true)
        {
            LEVELAmount += LevelRegeneration * Time.deltaTime;
            LEVELAmount = Mathf.Clamp(LEVELAmount, 0, lEVEL_BAR);

        }
        else
        {
            LEVELAmount.Equals(LEVELAmount);
        }
    }

    public void TrySpendLevel(int amount) {
            LEVELAmount -= amount; 
    }
    public float GetLevelNormalized() {
        return LEVELAmount / lEVEL_BAR;

    }

}
