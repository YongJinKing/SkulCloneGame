using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class SkullStaticDataManager
{
    private static SkullStaticDataManager instance;
    public Dictionary<int, Skull_PassiveAffectTable> dicSkull_PassiveAffectTable;
    public Dictionary<int, Skull_DataTable> dicSkull_DataTable;
    public Dictionary<int, Skull_ImageResourcesTable> dicSkull_ImageResourcesTable;
    public Dictionary<int, Skull_StringTable> dicSkull_StringDataTable;
    public Dictionary<int, Skull_StaticSkillTable> dicSkull_StaticSkillDataTable;
    
    public static SkullStaticDataManager GetInstance()
    {
        if(SkullStaticDataManager.instance == null)
            SkullStaticDataManager.instance = new SkullStaticDataManager();
        return SkullStaticDataManager.instance;
    }
    public void LoadSkullDatas()
    {
        var Skull_PassiveAffect_DataTable = Resources.Load<TextAsset>("Json/Skull_PassiveAffectTable").text;
        var Skull_DataTable = Resources.Load<TextAsset>("Json/Skull_DataTable").text;
        var Skull_ImageResources_DataTable = Resources.Load<TextAsset>("Json/Skull_ImageResourcesTable").text;
        var Skull_String_DataTable = Resources.Load<TextAsset>("Json/Skull_StringTable").text;
        var Skull_StaticSkill_DataTable = Resources.Load<TextAsset>("Json/Skull_StaticSkillTable").text;
        
        
        var arrSkull_PassiveAffect_DataTable = JsonConvert.DeserializeObject<Skull_PassiveAffectTable[]>(Skull_PassiveAffect_DataTable);
        var arrSkull_DataTable = JsonConvert.DeserializeObject<Skull_DataTable[]>(Skull_DataTable);
        var arrSkull_ImageResources_DataTable = JsonConvert.DeserializeObject<Skull_ImageResourcesTable[]>(Skull_ImageResources_DataTable);
        var arrSkull_String_DataTable = JsonConvert.DeserializeObject<Skull_StringTable[]>(Skull_String_DataTable);
        var arrSkull_StaticSkill_DataTable = JsonConvert.DeserializeObject<Skull_StaticSkillTable[]>(Skull_StaticSkill_DataTable);
 
        /* foreach(var data in arrSkull_DataTable)
        {
            Debug.LogFormat("{0} ",data.skull_index);
        } */
        this.dicSkull_PassiveAffectTable = arrSkull_PassiveAffect_DataTable.ToDictionary(x => x.skull_PassiveAffect_index);
        this.dicSkull_DataTable = arrSkull_DataTable.ToDictionary(x => x.skull_index);
        this.dicSkull_ImageResourcesTable = arrSkull_ImageResources_DataTable.ToDictionary(x => x.skull_imageResources_index);
        this.dicSkull_StringDataTable = arrSkull_String_DataTable.ToDictionary(x => x.skull_string_index);
        this.dicSkull_StaticSkillDataTable = arrSkull_StaticSkill_DataTable.ToDictionary(x => x.skull_staticSkill_index);

    }
}

