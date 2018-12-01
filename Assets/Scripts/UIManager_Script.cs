using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager_Script : MonoBehaviour
{
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI GameOverText;

    public GameObject GameOverScreen;

    public void SetLifes(int l)
    {
        LifeText.text = "Lifes: " + l.ToString("0");
    }

    public void DoGameOverScreen(string t)
    {
        GameOverText.text = t;
        GameOverScreen.SetActive(true);
    }
}
