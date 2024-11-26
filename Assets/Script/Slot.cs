using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    int id;
    string skullName;

    string passiveSkillDesc;
    
    public void Init(int id)
    {
        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadItemDatas();
        
        this.id = id;
        var skullData = skullInstance.dicSkullDataTable[id];
        skullName = skullInstance.dicSkullStringDataTable[skullData.base_imageName].name;

        var staticSkillData = skullInstance.dicPassiveAffectDataTable[skullData.base_staticSkill].affect_index;





    }
}
