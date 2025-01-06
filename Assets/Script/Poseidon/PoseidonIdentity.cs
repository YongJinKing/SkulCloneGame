using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class PoseidonIdentity : MonoBehaviour
{
    
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
    
    private Button[] identityButtons;
    
    private int selectedId;
    

    private void Start() 
    {
        
        PoseidonSkillList.instance.OnSkillListBtnAct += Poseidon_SkillExplain_OnSelectedSkillAct;
        identityButtons = GetComponentsInChildren<Button>();
        for(int i = 0; i < identityButtons.Length; i++)
        {
            int index = i;
            identityButtons[index].onClick.AddListener(() => IdentityBtnAct(index));
        }
        
    }
    private void Poseidon_SkillExplain_OnSelectedSkillAct(object sender, PoseidonSkillList.OnSkillListBtnActEventArgs e)
    {
        selectedId = e.poseidonSkillSlot.id;
        
        
        identity1Desc.text = e.poseidonSkillSlot.identity1Desc;
        identity2Desc.text = e.poseidonSkillSlot.identity2Desc;
        ChangeFontSize(identity1Desc);
        ChangeFontSize(identity2Desc);
    }
    private void ChangeFontSize(TMP_Text desc1)
    {
        int spaceSerching = CountSpecificCharacter(desc1.text, '\n');
        if(spaceSerching >= 2)
        {
            desc1.fontSize = 16;
        }
        else
        {
            desc1.fontSize = 20;
        }
    }
    
    private int CountSpecificCharacter(string input, char characterToCount)
    {
        return input.Count(c => c == characterToCount);
    }
    private void IdentityBtnAct(int index)
    {

    }
}
