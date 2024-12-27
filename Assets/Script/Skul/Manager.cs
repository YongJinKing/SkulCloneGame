using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField]private Transform slotGrid;
    [SerializeField]private Transform slot;
    [SerializeField]private Transform DetailInfo;

    private string skullName;
    private string passiveSkillDesc;
    
    private void OnEnable()
    {
        Slot.OnBtnClick += ShowDetailInfo;
    }

    private void OnDisable()
    {
        Slot.OnBtnClick -= ShowDetailInfo;
    }
    private void Start() 
    {
        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadSkullDatas();
        foreach(var data in skullInstance.dicSkull_DataTable)
        {
            Transform instantSlot = Instantiate(slot,slotGrid);
            instantSlot.GetComponent<Slot>().Init(data.Key);
        }
        DetailInfo.gameObject.SetActive(false);
    }
    private void ShowDetailInfo(int id)
    {
        DetailInfo.gameObject.SetActive(true);

        passiveSkillDesc = "";

        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadSkullDatas();

        var skullData = skullInstance.dicSkull_DataTable[id];
        var staticSkillInstance = skullInstance.dicSkull_StaticSkillDataTable[skullData.skull_staticSkill];

        skullName = skullInstance.dicSkull_StringDataTable[skullData.skull_imageName].skull_string_name;
        //Debug.Log(skullInstance.dicSkullResouseTable[skullData.base_imageName].imageName);
        

        #region PassiveFormatting
        for(int i = 0; i < staticSkillInstance.skull_passiveAffectArr.Length; i++)
        {
            int placeholderCount = GetPlaceholderCount(skullInstance.dicSkull_PassiveAffectTable[staticSkillInstance.skull_passiveAffectArr[i]].skull_PassiveAffect_desc);
            object[] intValues = new object[placeholderCount];
            
            for (int j = 0; j < placeholderCount; j++)
            {
                intValues[j] = staticSkillInstance.skull_passiveAffectValueArr[i][j]; // Ensure the array index matches
                if(staticSkillInstance.skull_passiveAffectValueArr[i][j] == 900000)
                {
                    intValues[j] = "출혈";
                }
                if(staticSkillInstance.skull_passiveAffectValueArr[i][j] == 900001)
                {
                    intValues[j] = "빙결";
                }
                if(staticSkillInstance.skull_passiveAffectValueArr[i][j] == 900002)
                {
                    intValues[j] = "방화";
                }
            }
            
            passiveSkillDesc += string.Format($"{skullInstance.dicSkull_PassiveAffectTable[staticSkillInstance.skull_passiveAffectArr[i]].skull_PassiveAffect_desc}",intValues) + "\n";
        }
        #endregion

        //Debug.Log(passiveSkillDesc);
        DetailInfo.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"SkulImage/{skullInstance.dicSkull_ImageResourcesTable[skullData.skull_imageName].skull_imageResources_imageName}");
        DetailInfo.GetChild(1).GetComponent<TMP_Text>().text = skullName;
        DetailInfo.GetChild(3).GetComponent<TMP_Text>().text = passiveSkillDesc;
    }
    
    private int GetPlaceholderCount(string template)
    {
        return Regex.Matches(template, @"\{\d+\}").Count;
    }

}
