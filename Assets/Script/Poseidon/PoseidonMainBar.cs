using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonMainBar : MonoBehaviour
{
    #region prefab

    [SerializeField] private Transform skillSlot;
    #endregion
    #region variable
    private Transform mainBarDetail;
    private Transform skillExplain;
    private Transform skillInfo;
    private Transform skillArousal;
    private Transform skillIdentity1;
    private Transform skillIdentity2;
    private Transform skillPreset;
    private Transform skillList;

    #endregion
    private void Start() 
    {
        mainBarDetail = transform.GetChild(0);
        skillExplain = mainBarDetail.GetChild(0);
        skillInfo = mainBarDetail.GetChild(1);
        skillArousal = mainBarDetail.GetChild(2);
        skillIdentity1 = mainBarDetail.GetChild(3);
        skillIdentity2 = mainBarDetail.GetChild(4);
        skillPreset = mainBarDetail.GetChild(5);
        skillList = mainBarDetail.GetChild(7).GetChild(0).GetChild(0);
        UpdateSkillList();
    }

    private void UpdateSkillList()
    {
        var poseidonInstance = PoseidonSkillStaticDataManager.GetInstance();
        poseidonInstance.LoadSkillDatas();

        foreach(var skill in poseidonInstance.dicSkill_dataTable)
        {
            var skillInstance = Instantiate(skillSlot, skillList);
            skillInstance.GetComponent<Poseidon_SkillSlot>().Init(skill.Key);   
        }

    }
}
