using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class Poseidon_Information : MonoBehaviour
{
    [SerializeField]private Poseidon_SkillExplain poseidon_SkillExplain;
    private PoseidonSkillStaticDataManager instance;
    private TMP_Text infoText;
    private string textData;

    private void Start() 
    {
        instance = PoseidonSkillStaticDataManager.GetInstance();
        infoText = transform.GetChild(1).GetComponent<TMP_Text>();
        poseidon_SkillExplain.OnSelectedSkillAct += Poseidon_SkillExplain_OnSelectedSkillAct;
    }

    private void Poseidon_SkillExplain_OnSelectedSkillAct(object sender, Poseidon_SkillExplain.OnSelectedkillActEventArgs e)
    {
        instance.LoadSkillDatas();
        
        textData = "";
        var detailAffectData = instance.dicSkill_dataTable[e.selectedSkillId].skill_detailAffectIdx;
        foreach(var affectData in detailAffectData)
        {
            if(instance.dicSkill_affectTable.ContainsKey(affectData))
            {
                textData += instance.dicSkill_affectTable[affectData].affect_desc;
                if(instance.dicSkill_affectTable[affectData].affect_desc != "")
                {
                    textData += "\n";
                }
            }
        }
        if(instance.dicSkill_dataTable[e.selectedSkillId].skill_duration > 0)
        {
            textData += "지속시간 : " + instance.dicSkill_dataTable[e.selectedSkillId].skill_damage + "\n";
        }
        if(instance.dicSkill_dataTable[e.selectedSkillId].skill_damage > 0)
        {
            textData += "데미지 : " + instance.dicSkill_dataTable[e.selectedSkillId].skill_damage + "\n";
        }
        if(instance.dicSkill_dataTable[e.selectedSkillId].skill_coolTime > 0)
        {
            textData += "쿨 타임 : " + instance.dicSkill_dataTable[e.selectedSkillId].skill_damage;
        }
        
        int spaceSerching = CountSpecificCharacter(textData, '\n');
        if(spaceSerching >= 4)
        {
            infoText.fontSize = 16;
        }
        else
        {
            infoText.fontSize = 20;
        }
        infoText.text = textData;
                       
    }
    public int CountSpecificCharacter(string input, char characterToCount)
    {
        return input.Count(c => c == characterToCount);
    }
}
