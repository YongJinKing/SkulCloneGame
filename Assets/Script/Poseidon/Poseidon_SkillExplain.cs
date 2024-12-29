using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon_SkillExplain : MonoBehaviour
{
    [SerializeField] private Transform poseidon_SkillList_data;
    private Image image;
    private TMP_Text skillName;
    private TMP_Text skillDesc;
    private Button riggingBtn;
    private TMP_Text riggingBtnText;
    private int selectedSkillId;
    private bool isRigging;

    private Poseidon_SkillList poseidon_skillList;
    private PoseidonSkillStaticDataManager poseidonInstance;

    public class OnRiggingSkillActEventArgs : EventArgs
    {
        public bool isRigging;
    }
    public event EventHandler<OnRiggingSkillActEventArgs> OnRiggingSkillAct;

    private void Start() 
    {
        poseidon_skillList = poseidon_SkillList_data.transform.GetComponent<Poseidon_SkillList>();
        poseidon_skillList.OnBtnAct += SkillList_OnChanged;

        image = transform.GetChild(0).GetComponent<Image>();
        skillName = transform.GetChild(1).GetComponent<TMP_Text>();
        skillDesc = transform.GetChild(2).GetComponent<TMP_Text>();

        riggingBtn = transform.GetChild(3).GetComponent<Button>();
        riggingBtnText = transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>();

        riggingBtn.onClick.AddListener(OnBtnAct);
        poseidonInstance = PoseidonSkillStaticDataManager.GetInstance();
    }


    private void SkillList_OnChanged(object sender, Poseidon_SkillList.OnBtnActEventArgs e)
    {
        var instance = poseidon_SkillList_data.GetChild(e.num).GetComponent<Poseidon_SkillSlot>();
        image.sprite = instance.sprite;
        selectedSkillId = instance.id;
        isRigging = false;
        ChangeRiggingBtnText();
        OnRiggingSkillAct?.Invoke(this, new OnRiggingSkillActEventArgs
        {
            isRigging = false,
        });

        poseidonInstance.LoadSkillDatas();
        skillName.text = poseidonInstance.dicSkill_stringTable[instance.id].skill_name;
        skillDesc.text = poseidonInstance.dicSkill_stringTable[instance.id].skill_desc;
    }


    private void OnBtnAct()
    {
        if(selectedSkillId % 10000 != 1)
        {
            this.isRigging = !this.isRigging;
            ChangeRiggingBtnText();
            OnRiggingSkillAct?.Invoke(this, new OnRiggingSkillActEventArgs
            {
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

}
