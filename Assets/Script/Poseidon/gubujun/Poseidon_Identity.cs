using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Poseidon_Identity : MonoBehaviour
{
    [SerializeField] private Poseidon_SkillExplain poseidon_SkillExplain;
    private Poseidon_SkillList poseidon_skillList;
    private Transform identity1;
    private Transform identity2;
    private bool identity1Check;
    private bool identity2Check;

    public class OnIdentityBtnActEventArgs : EventArgs
    {
        public int selectedSkillId;
        public int index;
    }
    public event EventHandler<OnIdentityBtnActEventArgs> OnIdentityBtnAct;
    private int selectedSkillId;
    

    
    private PoseidonSkillStaticDataManager instance;
    private Button[] identityButtons;
    
    
    
    
    private void Start() 
    {
        identity1 = transform.GetChild(0);
        identity2 = transform.GetChild(1);
        instance = PoseidonSkillStaticDataManager.GetInstance();
        poseidon_skillList = PoseidonMainBar.instance.skillList.GetComponent<Poseidon_SkillList>();

        
        poseidon_SkillExplain.OnSelectedSkillAct += Poseidon_SkillExplain_OnSelectedSkillAct;
        poseidon_skillList.OnSkillListBtnAct += OnSkillListBtnAct_Poseidon_SkillList;
        identityButtons = GetComponentsInChildren<Button>();
        for(int i = 0; i < identityButtons.Length; i++)
        {
            int index = i;
            identityButtons[index].onClick.AddListener(() => IdentityBtnAct(index));
        }
        
    }
    private void Poseidon_SkillExplain_OnSelectedSkillAct(object sender, Poseidon_SkillExplain.OnSelectedkillActEventArgs e)
    {
        instance.LoadSkillDatas();
        selectedSkillId = e.selectedSkillId;
        var identity1Text = identity1.GetChild(1).GetComponent<TMP_Text>();
        var identity2Text = identity2.GetChild(1).GetComponent<TMP_Text>();
        identity1Text.text = "";
        identity2Text.text = "";
        identity1Text.text = instance.dicSkill_identityTable[instance.dicSkill_dataTable[e.selectedSkillId].skill_identityAffectIdx].identity1_desc;
        identity2Text.text = instance.dicSkill_identityTable[instance.dicSkill_dataTable[e.selectedSkillId].skill_identityAffectIdx].identity2_desc;      
    }
    private void IdentityBtnAct(int index)
    {
        if(index == 0)
        {
            identity2Check = false;
            identity1Check = !identity1Check;
        }
        if(index == 1)
        {
            identity1Check = false;
            identity2Check = !identity2Check;
        }

        SetRiggingBtnText();
        if(identity1Check)
        {
            OnIdentityBtnAct?.Invoke(this, new OnIdentityBtnActEventArgs
            {
                selectedSkillId = selectedSkillId,
                index = 1,
                
            });
        }
        else if(identity2Check)
        {
            OnIdentityBtnAct?.Invoke(this, new OnIdentityBtnActEventArgs
            {
                selectedSkillId = selectedSkillId,
                index = 2,
                
            });
        }
        else
        {
            OnIdentityBtnAct?.Invoke(this, new OnIdentityBtnActEventArgs
            {
                selectedSkillId = selectedSkillId,
                index = 0,
                
            });
        }
    }

    private void OnSkillListBtnAct_Poseidon_SkillList(object sender, Poseidon_SkillList.OnSkillListBtnActEventArgs e)//스킬리스트에서 선택한 스킬 바꾸기
    {
    }
    private void SetRiggingBtnText()
    {
        var identity1Text = identity1.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        var identity2Text = identity2.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        if(identity1Check)
        {
            identity1Text.text = "선택 해제";
        }
        else
        {
            identity1Text.text = "선택";
        }


        if(identity2Check)
        {
            identity2Text.text = "선택 해제";
        }
        else
        {
            identity2Text.text = "선택";
        }
    }
    
}
