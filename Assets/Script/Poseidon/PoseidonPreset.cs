using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PoseidonPreset : MonoBehaviour
{
    [SerializeField] private PoseidonSkillExplain poseidonSkillExplain;
    private Transform presetSkillList;
    public static PoseidonPreset instance;
    private PoseidonPresetSlot[] PoseidonPresetSlot;
    private Button[] presetsBtn;
    private int selectedSkillId;
    private bool riggingCheck;
    private List<int> riggingSkillList;

    public class OnPresetSlotBtnActEventArgs : EventArgs
    {
        public List<int> riggingSkillList;
    }
    public event EventHandler<OnPresetSlotBtnActEventArgs> OnPresetSlotBtnAct;
    
    Coroutine onRiggingSkillCoroutine;
    
    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        presetSkillList = transform.GetChild(1);
        PoseidonPresetSlot = presetSkillList.GetComponentsInChildren<PoseidonPresetSlot>();//장착 스킬 클래스 참조
        


        presetsBtn = GetComponentsInChildren<Button>();//장착 스킬 버튼 할당
        for(int i = 0; i < presetsBtn.Length; i++)
        {
            int index = i;
            presetsBtn[index].onClick.AddListener(() => PresetsBtnAct(index));
        }
        poseidonSkillExplain.OnRiggingSkillAct += OnRiggingSkill_SkillExplain;
    }


    

    private void OnRiggingSkill_SkillExplain(object sender, PoseidonSkillExplain.OnRiggingSkillActEventArgs e)
    {
        selectedSkillId = e.riggingSkillId;
        riggingCheck = e.isRigging;
        RiggingSkillCheck();
        
    }
    private void RiggingSkillCheck()
    {
        if(riggingCheck)
        {
            if(onRiggingSkillCoroutine == null)
            {
                onRiggingSkillCoroutine = StartCoroutine(CorRiggingSkill());
            }
        }
        else
        {
            PresetTargetImageInit();
        }
    }
    
    private IEnumerator CorRiggingSkill()
    {
        while(riggingCheck)
        {
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                PoseidonPresetSlot[i].ImageChange();
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        
    }
    private void PresetsBtnAct(int index)//
    {
        if(riggingCheck)
        {
            SamePresetSlotInit(selectedSkillId);
            PresetTargetImageInit();
            presetSkillList.GetChild(index).GetComponent<PoseidonPresetSlot>().RiggngSkillInPresetSlot(selectedSkillId);
            GetRiggingSkillList();
            riggingCheck = false;

            OnPresetSlotBtnAct?.Invoke(this, new OnPresetSlotBtnActEventArgs
            {
                riggingSkillList = riggingSkillList,
                
            });
        }
    }
    private void SamePresetSlotInit(int id)//프리셋 슬롯에 똑같은 아이디 있으면 초기화 시키는 공정
    {
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(presetSkillList.GetChild(i).GetComponent<PoseidonPresetSlot>().id == id)
            {
                presetSkillList.GetChild(i).GetComponent<PoseidonPresetSlot>().RiggngSkillInPresetSlot(0);
                PresetTargetImageInit();
                break;
            }
        }
        
    }

    private void PresetTargetImageInit()
    {
        if(onRiggingSkillCoroutine != null)
        {
            StopCoroutine(CorRiggingSkill());
            onRiggingSkillCoroutine = null;
            
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                PoseidonPresetSlot[i].TargetImageClear();
            }
        }      
    }
    private void GetRiggingSkillList()
    {
        riggingSkillList = new List<int>();
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(presetSkillList.GetChild(i).GetComponent<PoseidonPresetSlot>().id > 0)
            {
                riggingSkillList.Add(presetSkillList.GetChild(i).GetComponent<PoseidonPresetSlot>().id);
            }
        }
    }
}
