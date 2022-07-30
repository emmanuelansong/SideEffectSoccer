using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerbarUI : MonoBehaviour
{
    private Image progressBar;

    public float currentValue;
    public float maxValue;

    public PlayerScript player;
    private float shotPower;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Image>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        shotPower = player.distance;
        currentValue = shotPower;

        progressBar.fillAmount =  currentValue / maxValue;

        if (currentValue < 0)
            currentValue = 0;

        if (currentValue > maxValue)
            currentValue = maxValue;
    }

}
