using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthValueText;
    public TextMeshProUGUI economyValueText;
    public TextMeshProUGUI militaryValueText;
    public TextMeshProUGUI popularityValueText;
    


    // Update is called once per frame
    void Update()
    {
        healthValueText.text = "Health Services: " + GameManager.instance.healthValue.ToString();
        economyValueText.text = "Economy: " + GameManager.instance.economyValue.ToString();
        militaryValueText.text = "Military: " + GameManager.instance.militaryValue.ToString();
        popularityValueText.text = "Happiness: " + GameManager.instance.popularityValue.ToString();
    }
}
