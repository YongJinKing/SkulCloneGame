using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Poseidon_Identity : MonoBehaviour
{
    [SerializeField] private Poseidon_SkillExplain poseidon_SkillExplain;
    [SerializeField] private TMP_Text identity1Desc;
    [SerializeField] private TMP_Text identity2Desc;

    private class IdentityData
    {
        public int identity_index;
        public bool identity1_selected;
        public bool identity2_selected;

        public IdentityData(int identity_index, bool identity1_selected, bool identity2_selected)
        {
            this.identity_index = identity_index;
            this.identity1_selected = identity1_selected;
            this.identity2_selected = identity2_selected;
        }
    }
    
    private Dictionary<int, IdentityData> dic_identityData = new Dictionary<int, IdentityData>();
    private PoseidonSkillStaticDataManager instance;
    private Button[] identityButtons;
    
    private int selectedId;
    

    private void Start() 
    {
        instance = PoseidonSkillStaticDataManager.GetInstance();
        poseidon_SkillExplain.OnSelectedSkillAct += Poseidon_SkillExplain_OnSelectedSkillAct;
        identityButtons = GetComponentsInChildren<Button>();
        for(int i = 0; i < identityButtons.Length; i++)
        {
            int index = i;
            identityButtons[index].onClick.AddListener(() => IdentityBtnAct(index));
        }
        
    }
    private void Poseidon_SkillExplain_OnSelectedSkillAct(object sender, Poseidon_SkillExplain.OnSelectedkillActEventArgs e)
    {
        selectedId = e.selectedSkillId;
        instance.LoadSkillDatas();
        identity1Desc.text = "";
        identity2Desc.text = "";
        identity1Desc.text = instance.dicSkill_identityTable[instance.dicSkill_dataTable[e.selectedSkillId].skill_identityAffectIdx].identity1_desc;
        identity2Desc.text = instance.dicSkill_identityTable[instance.dicSkill_dataTable[e.selectedSkillId].skill_identityAffectIdx].identity2_desc;      
    }
    private void IdentityBtnAct(int index)
    {

    }
}
