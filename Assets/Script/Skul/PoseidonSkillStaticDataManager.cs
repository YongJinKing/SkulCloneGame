using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class PoseidonSkillStaticDataManager
{
    private static PoseidonSkillStaticDataManager instance;

    public Dictionary<int, Poseidon_Skill_DataTable> dicSkill_dataTable;
    public Dictionary<int, Poseidon_Skill_ImageResourcesTable> dicSkill_imageResourcesTable;
    public Dictionary<int, Poseidon_Skill_StringTable> dicSkill_stringTable;
   
    
    public static PoseidonSkillStaticDataManager GetInstance()
    {
        if(PoseidonSkillStaticDataManager.instance == null)
            PoseidonSkillStaticDataManager.instance = new PoseidonSkillStaticDataManager();
        return PoseidonSkillStaticDataManager.instance;
    }
    public void LoadSkillDatas()
    {
        var skill_dataTable = Resources.Load<TextAsset>("Json/Poseidon/Poseidon_Skill_DataTable").text;
        var skill_imageResourcesTable = Resources.Load<TextAsset>("Json/Poseidon/Poseidon_Skill_ImageResourcesTable").text;
        var skill_stringTable = Resources.Load<TextAsset>("Json/Poseidon/Poseidon_Skill_StringTable").text;
        
        
        var arrSkill_dataTable = JsonConvert.DeserializeObject<Poseidon_Skill_DataTable[]>(skill_dataTable);
        var arrSkill_imageResourcesTable = JsonConvert.DeserializeObject<Poseidon_Skill_ImageResourcesTable[]>(skill_imageResourcesTable);
        var arrSkill_stringTable = JsonConvert.DeserializeObject<Poseidon_Skill_StringTable[]>(skill_stringTable);
        /* foreach(var data in arrSkill_DataTable)
        {
            Debug.LogFormat("{0} ",data.Skill_index);
        } */
        
        this.dicSkill_dataTable = arrSkill_dataTable.ToDictionary(x => x.skill_index);
        this.dicSkill_imageResourcesTable = arrSkill_imageResourcesTable.ToDictionary(x => x.skill_imageResources_index);
        this.dicSkill_stringTable = arrSkill_stringTable.ToDictionary(x => x.string_index);

    }
}

