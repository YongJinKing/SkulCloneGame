using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon_SkillSlot : MonoBehaviour
{
    #region variable

    private Image image;
    private Button button;

    #endregion

    private void Start() 
    {
        image = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>();
    }
    public void Init(int id)
    {
        var poseidonInstance = PoseidonSkillStaticDataManager.GetInstance();
        poseidonInstance.LoadSkillDatas();
        transform.GetChild(0).GetComponent<Image>().sprite = 
        Resources.Load<Sprite>($"Image/Posaidon/{poseidonInstance.dicSkill_imageResourcesTable[poseidonInstance.dicSkill_dataTable[id].skill_imageNameIdx].skill_imageResources_imageName}");
        
    }
}
