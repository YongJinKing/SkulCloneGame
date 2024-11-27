

public struct Skull_DataTable
{
    public int skull_index;
    public int rarity;
    public int info;
    public int type;
    public int base_attackCycle;
    public int base_staticSkill;
    public int[] base_activeSkillArr;
    public int base_evolution;
    public int base_imageName;
      
}
public struct PassiveAffect_DataTable
{
    public int affect_index;
    public string affect_name;
    public string desc;
}

public struct Skull_ImageResources_DataTable
{
    public int skull_imageResources_index;
    public string imageName;
}
public struct Skull_String_DataTable
{
    public int skullString_index;
    public string name;
}

public struct StaticSkill_DataTable
{
    public int staticSkill_index;
    public int[] passiveAffectArr;
    public int[][] passiveAffectValueArr;
}