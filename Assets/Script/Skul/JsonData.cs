

public struct Skull_DataTable
{
    public int skull_index;
    public int skull_rarity;
    public int skull_info;
    public int skull_type;
    public int skull_attackCycle;
    public int skull_staticSkill;
    public int[] skull_activeSkillArr;
    public int skull_evolution;
    public int skull_imageName;
}
public struct Skull_PassiveAffectTable
{
    public int skull_PassiveAffect_index;
    public string skull_PassiveAffect_name;
    public string skull_PassiveAffect_desc;
}

public struct Skull_ImageResourcesTable
{
    public int skull_imageResources_index;
    public string skull_imageResources_imageName;
}
public struct Skull_StringTable
{
    public int skull_string_index;
    public string skull_string_name;
}

public struct Skull_StaticSkillTable
{
    public int skull_staticSkill_index;
    public int[] skull_passiveAffectArr;
    public int[][] skull_passiveAffectValueArr;
}


#region Poseidon

public struct Poseidon_Skill_DataTable
{
    public int skill_index;
    public int skill_rarity;
    public int skill_stringIdx;
    public int skill_type;
    public float skill_coolTime;
    public int skill_target;
    public float skill_damage;
    public float skill_duration;
    public int skill_hitValue;
    public int skill_rangeType;
    public int skill_detailAffectIdx;
    public int skill_identityAffect1Idx;
    public int skill_identityAffect2Idx;
    public int skill_arousalIdx;
    public int skill_imageNameIdx;
    
}



public struct Poseidon_Skill_ImageResourcesTable
{
    public int skill_imageResources_index;
    public string skill_imageResources_imageName;
}

#endregion