using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PoseidonSkillExplain : MonoBehaviour
{
    
    private Image image;
    private TMP_Text skillName;
    private TMP_Text skillDesc;
    private Button riggingBtn;
    private TMP_Text riggingBtnText;
    private int selectedSkillId;
    private bool isRigging;


    public class OnRiggingSkillActEventArgs : EventArgs
    {
        public int riggingSkillId;
        public bool isRigging;

    }
    public event EventHandler<OnRiggingSkillActEventArgs> OnRiggingSkillAct;
    public class OnSelectedkillActEventArgs : EventArgs
    {
        public int selectedSkillId;
    }
    public event EventHandler<OnSelectedkillActEventArgs> OnSelectedSkillAct;

    private void Start() 
    {
        
        PoseidonSkillList.instance.OnSkillListBtnAct += OnSkillListBtnAct_PoseidonSkillList;
        PoseidonPreset.instance.OnPresetSlotBtnAct += OnPresetSlotBtnAct_PoseidonPreset;

        image = transform.GetChild(0).GetComponent<Image>();
        skillName = transform.GetChild(1).GetComponent<TMP_Text>();
        skillDesc = transform.GetChild(2).GetComponent<TMP_Text>();

        riggingBtn = transform.GetChild(3).GetComponent<Button>();
        riggingBtnText = transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>();

        riggingBtn.onClick.AddListener(OnRiggingBtnAct);
        
        
    }


    private void OnSkillListBtnAct_PoseidonSkillList(object sender, PoseidonSkillList.OnSkillListBtnActEventArgs e)//스킬리스트에서 선택한 스킬 바꾸기
    {
        
        image.sprite = e.poseidonSkillSlot.sprite;
        selectedSkillId = e.poseidonSkillSlot.id;
        skillName.text = e.poseidonSkillSlot.skill_name;
        skillDesc.text = e.poseidonSkillSlot.skill_desc;
        isRigging = false;
        ChangeRiggingBtnText();
    }
    private void OnPresetSlotBtnAct_PoseidonPreset(object sender, PoseidonPreset.OnPresetSlotBtnActEventArgs e)
    {
        isRigging = false;
        ChangeRiggingBtnText();
    }

    

    private void OnRiggingBtnAct()
    {
        if(selectedSkillId % 10000 != 1)
        {
            this.isRigging = !this.isRigging;
            ChangeRiggingBtnText();
            OnRiggingSkillAct?.Invoke(this, new OnRiggingSkillActEventArgs
            {
                riggingSkillId = selectedSkillId,
                isRigging = this.isRigging,
            });
        }
        
    }
    private void ChangeRiggingBtnText()
    {
        if(selectedSkillId % 10000 == 1)
        {
            riggingBtnText.text = "적용 중";
        }
        else
        {
            if(isRigging)
            {
                riggingBtnText.text = "장착 해제";
            }
            else
            {
                riggingBtnText.text = "장착";
            }
        }
        
    }

    private void Poseidon_PresetSlotBtnAct(object sender, EventArgs e)
    {
        this.isRigging = false;
        ChangeRiggingBtnText();
    }

}
