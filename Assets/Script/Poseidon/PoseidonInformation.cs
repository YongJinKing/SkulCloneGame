using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class PoseidonInformation : MonoBehaviour
{
    
    private TMP_Text infoText;
    

    private void Start() 
    {
        infoText = transform.GetChild(1).GetComponent<TMP_Text>();
        PoseidonSkillList.instance.OnSkillListBtnAct += PoseidonSkillList_OnSKillListBtnAct;
    }

    private void PoseidonSkillList_OnSKillListBtnAct(object sender, PoseidonSkillList.OnSkillListBtnActEventArgs e)
    {
        
        int spaceSerching = CountSpecificCharacter(e.poseidonSkillSlot.infoData, '\n');
        if(spaceSerching >= 4)
        {
            infoText.fontSize = 16;
        }
        else
        {
            infoText.fontSize = 20;
        }
        infoText.text = e.poseidonSkillSlot.infoData;
                       
    }
    private int CountSpecificCharacter(string input, char characterToCount)
    {
        return input.Count(c => c == characterToCount);
    }
}
