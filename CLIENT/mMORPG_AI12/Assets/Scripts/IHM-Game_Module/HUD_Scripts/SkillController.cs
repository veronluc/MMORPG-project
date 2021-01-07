using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{

    private Text buttonText;
    private IHMGameModule ihmGameModule;

    private void Start()
    {
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();  
    }

    // Test button click
    public void UseSkill(int skillNumber)
    {
        buttonText = GameObject.Find("ButtonSkill_" + skillNumber).GetComponentInChildren<Text>();
        buttonText.text = "This skill's number is n°" + skillNumber;
        ihmGameModule.clickOnSkill("Attaque");
    }
}
