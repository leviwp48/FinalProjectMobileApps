﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text HPTextP1;

    [SerializeField]
    private Text HPTextP2;

    public Player1 p1;
    public Player2 p2;



    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            string[] temp = HPTextP1.text.Split(':');
            HPTextP1.text = temp[0] + ": " + value + "/" + MaxValue;

            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       /* if(GameManager.instance.p1Turn)
        {
            p1 = GameObject.Find("Player1").GetComponent<Player1>();
            p1.currHealth = Map(p1.currHealth, 0, MaxValue, 0, 1);
        }
        else if(GameManager.instance.p2Turn)
        {
            p2 = GameObject.Find("Player2").GetComponent<Player2>();
            p2.currHealth = Map(p1.currHealth, 0, MaxValue, 0, 1);
        } */
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }

        /*if (fillAmount2 != content.fillAmount2)
        {
            content.fillAmount2 = fillAmount2;
        } */

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // this function sets the health bar's fill amount to our current health
        // by calculating the percentage of our health bar that should still be filled
        // value is our current health, inMin is our lowest possible health(0)
        // inMax is our highest possible health(50), outMin is our lowest possible
        // fill amount for our health(0), and outMax is our highest possible fill amount(1)
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

   /* private float Map2(float value2, float inMin, float inMax, float outMin, float outMax)
    {
        // this function sets the health bar's fill amount to our current health
        // by calculating the percentage of our health bar that should still be filled
        // value is our current health, inMin is our lowest possible health(0)
        // inMax is our highest possible health(50), outMin is our lowest possible
        // fill amount for our health(0), and outMax is our highest possible fill amount(1)
        return (value2 - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    } */
}
