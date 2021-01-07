using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{

    private Text buttonText;
    private IHMGameModule ihmGameModule;
    public List<GameObject> ButtonList;
    
    private void Start()
    {
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        for (int i = 0; i < ihmGameModule.player.entityClass.skills.Count; i++)
        {
            ButtonList[i].GetComponentInChildren<Text>().text = ihmGameModule.player.entityClass.skills[i].name;
        }
    }

    public void UseSkill(int skillNumber)
    {
        ihmGameModule.clickOnSkill(ButtonList[skillNumber].GetComponentInChildren<Text>().text);
    }    
    public void EndTurn()
    {
        ihmGameModule.handleEndOfTurn();
    }
}
