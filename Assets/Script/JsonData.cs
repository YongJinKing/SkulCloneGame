

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