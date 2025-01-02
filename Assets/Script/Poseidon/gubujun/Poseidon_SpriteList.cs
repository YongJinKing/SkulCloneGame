using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poseidon_SpriteList : MonoBehaviour
{
    public static Poseidon_SpriteList instance;
    private class Sprite_Data
    {
        public int sprite_index;
        public Sprite sprite;

        public Sprite_Data(int sprite_index, Sprite sprite)
        {
            this.sprite_index = sprite_index;
            this.sprite = sprite;
        }
    }
    
    private Dictionary<int, Sprite_Data> dic_SpriteData = new Dictionary<int, Sprite_Data>();
    private PoseidonSkillStaticDataManager poseidonInstance;
    private Sprite[] sprites;
    
    private void Awake()
    {
        instance = this;
        poseidonInstance  = PoseidonSkillStaticDataManager.GetInstance();
        sprites = Resources.LoadAll<Sprite>("Image/Poseidon");
        poseidonInstance.LoadSkillDatas();
        
        foreach(var data in poseidonInstance.dicSkill_dataTable)
        {
            
            foreach(var sp in sprites)
            {
               
                if(sp.name == poseidonInstance.dicSkill_imageResourcesTable[data.Key].skill_imageResources_imageName)
                {
                    dic_SpriteData.Add(data.Key, new Sprite_Data(data.Key, sp));
                    break;
                }
            }    
        }

        
    }
    
    public Sprite GetSprite(int id)
    {
        if(dic_SpriteData.ContainsKey(id))
        {
            var sprite = dic_SpriteData[id].sprite;
            return sprite;
        }
        Debug.Log("아이디 없음");
        return null;
        
    }
    
}
