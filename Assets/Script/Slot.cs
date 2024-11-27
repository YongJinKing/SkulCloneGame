using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;

public class Slot : MonoBehaviour
{
    int id;
    string skullName;

    string passiveSkillDesc;
    
    public void Init(int id)
    {
        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadSkullDatas();
        
        this.id = id;
        var skullData = skullInstance.dicSkullDataTable[id];
        skullName = skullInstance.dicSkullStringDataTable[skullData.base_imageName].name;
        var staticSkillInstance = skullInstance.dicStaticSkillDataTable[skullData.base_staticSkill];
        for(int i = 0; i < staticSkillInstance.passiveAffectArr.Length; i++)
        {
            int placeholderCount = GetPlaceholderCount(skullInstance.dicPassiveAffectDataTable[staticSkillInstance.passiveAffectArr[i]].desc);

            // Extract required integers from the 2D array
            object[] intValues = new object[placeholderCount];
            
            for (int j = 0; j < placeholderCount; j++)
            {
                intValues[j] = staticSkillInstance.passiveAffectValueArr[i][j]; // Ensure the array index matches
                if(staticSkillInstance.passiveAffectValueArr[i][j] == 900000)
                {
                    intValues[j] = "출혈";
                }
                if(staticSkillInstance.passiveAffectValueArr[i][j] == 900001)
                {
                    intValues[j] = "빙결";
                }
                if(staticSkillInstance.passiveAffectValueArr[i][j] == 900002)
                {
                    intValues[j] = "방화";
                }
            }
            var stringFormatting = string.Format($"{skullInstance.dicPassiveAffectDataTable[staticSkillInstance.passiveAffectArr[i]].desc}",intValues);
            passiveSkillDesc += (stringFormatting + "\n");
            //Debug.Log(stringFormatting);
        }
        Debug.Log(passiveSkillDesc);
    }
    private int GetPlaceholderCount(string template)
    {
        return Regex.Matches(template, @"\{\d+\}").Count;
    }
}
