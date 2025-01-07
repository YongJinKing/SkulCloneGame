using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PoseidonSkillSlot : MonoBehaviour
{
    #region variable

    public int id{get; private set;}
    public Sprite sprite{get; private set;}
    public string skill_name{get; private set;}
    public string skill_desc{get; private set;}
    public string infoData{get; private set;}
    public string identity1Desc{get; private set;}
    public string identity2Desc{get; private set;}
    public string identityDisplay{get; private set;}
    

    
    private bool isRigging;
    private Transform riggingText;
    private PoseidonSkillStaticDataManager instance;
    
    #endregion

    private void Awake()
    {
        instance = PoseidonSkillStaticDataManager.GetInstance();
        riggingText = transform.GetChild(1);
    }
    public void Init(int id ,Sprite sprite)
    { 
        instance.LoadSkillDatas();
        this.id = id;
        this.sprite = sprite;
        skill_name = instance.dicSkill_stringTable[id].skill_name;
        skill_desc = instance.dicSkill_stringTable[id].skill_desc;
        identity1Desc = instance.dicSkill_identityTable[instance.dicSkill_dataTable[id].skill_identityAffectIdx].identity1_desc;
        identity2Desc = instance.dicSkill_identityTable[instance.dicSkill_dataTable[id].skill_identityAffectIdx].identity2_desc;
        identityDisplay = null;
        
        InitSKillInformation();
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }
    public void riggingStatus(bool value)
    {
        isRigging = value;
        riggingText.gameObject.SetActive(isRigging);  
    }
    
    private void InitSKillInformation()
    {
        instance.LoadSkillDatas();
        
        infoData = "";
        var detailAffectData = instance.dicSkill_dataTable[id].skill_detailAffectIdx;
        foreach(var affectData in detailAffectData)
        {
            if(instance.dicSkill_affectTable.ContainsKey(affectData))
            {
                infoData += instance.dicSkill_affectTable[affectData].affect_desc;
                if(instance.dicSkill_affectTable[affectData].affect_desc != "")
                {
                    infoData += "\n";
                }
            }
        }
        if(instance.dicSkill_dataTable[id].skill_duration > 0)
        {
            infoData += "지속시간 : " + instance.dicSkill_dataTable[id].skill_damage + "\n";
        }
        if(instance.dicSkill_dataTable[id].skill_damage > 0)
        {
            infoData += "데미지 : " + instance.dicSkill_dataTable[id].skill_damage + "\n";
        }
        if(instance.dicSkill_dataTable[id].skill_coolTime > 0)
        {
            infoData += "쿨 타임 : " + instance.dicSkill_dataTable[id].skill_damage;
        }
    }
    private void SetIdentity()
    {
        
    }
   
    
    
}
