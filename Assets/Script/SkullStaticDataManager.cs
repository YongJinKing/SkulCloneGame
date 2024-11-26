using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class SkullStaticDataManager : MonoBehaviour
{
    private static SkullStaticDataManager instance;
    public Dictionary<int, PassiveAffect_DataTable> dicPassiveAffectDataTable;
    public Dictionary<int, Skull_DataTable> dicSkullDataTable;
    public Dictionary<int, Skull_ImageResources_DataTable> dicSkullResouseTable;
    public Dictionary<int, Skull_String_DataTable> dicSkullStringDataTable;
    public Dictionary<int, StaticSkill_DataTable> dicStaticSkillDataTable;
    
    public static SkullStaticDataManager GetInstance()
    {
        if(SkullStaticDataManager.instance == null)
            SkullStaticDataManager.instance = new SkullStaticDataManager();
        return SkullStaticDataManager.instance;
    }
    public void LoadItemDatas()
    {
        var Skull_PassiveAffect_DataTable = Resources.Load<TextAsset>("PassiveAffect_DataTable").text;
        var Skull_DataTable = Resources.Load<TextAsset>("Skull_DataTable").text;
        var Skull_ImageResources_DataTable = Resources.Load<TextAsset>("Skull_ImageResources_DataTable").text;
        var Skull_String_DataTable = Resources.Load<TextAsset>("Skull_String_DataTable").text;
        var Skull_StaticSkill_DataTable = Resources.Load<TextAsset>("StaticSkill_DataTable").text;
        
        
        var arrSkull_PassiveAffect_DataTable = JsonConvert.DeserializeObject<PassiveAffect_DataTable[]>(Skull_PassiveAffect_DataTable);
        var arrSkull_DataTable = JsonConvert.DeserializeObject<Skull_DataTable[]>(Skull_DataTable);
        var arrSkull_ImageResources_DataTable = JsonConvert.DeserializeObject<Skull_ImageResources_DataTable[]>(Skull_ImageResources_DataTable);
        var arrSkull_String_DataTable = JsonConvert.DeserializeObject<Skull_String_DataTable[]>(Skull_String_DataTable);
        var arrSkull_StaticSkill_DataTable = JsonConvert.DeserializeObject<StaticSkill_DataTable[]>(Skull_StaticSkill_DataTable);
 
        /* foreach(var data in arrItem_DataTables)
        {
            Debug.LogFormat("{0} ",data.ItemData_Index);
        } */
        this.dicPassiveAffectDataTable = arrSkull_PassiveAffect_DataTable.ToDictionary(x => x.affect_index);
        this.dicSkullDataTable = arrSkull_DataTable.ToDictionary(x => x.skull_index);
        this.dicSkullResouseTable = arrSkull_ImageResources_DataTable.ToDictionary(x => x.skull_imageResources_index);
        this.dicSkullStringDataTable = arrSkull_String_DataTable.ToDictionary(x => x.skullString_index);
        this.dicStaticSkillDataTable = arrSkull_StaticSkill_DataTable.ToDictionary(x => x.staticSkill_index);

    }
}

