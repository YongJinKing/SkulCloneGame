using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Poseidon_SkillList : MonoBehaviour
{
    [SerializeField] private Transform skillSlot;
    
    private Button[] slotsBtn;
    private PoseidonSkillStaticDataManager poseidonInstance;
    
    public class OnSkillListBtnActEventArgs : EventArgs
    {
        public int index;
    }
    public event EventHandler<OnSkillListBtnActEventArgs> OnSkillListBtnAct;

    // Start is called before the first frame update
    private void Start()
    {
        poseidonInstance  = PoseidonSkillStaticDataManager.GetInstance();  
        Init();
    }
    private void Init()
    {
        
        poseidonInstance.LoadSkillDatas();

        foreach(var data in poseidonInstance.dicSkill_dataTable)
        {
            var skillInstance = Instantiate(skillSlot,transform);
            
            skillInstance.GetComponent<Poseidon_SkillSlot>().Init(data.Key, Poseidon_SpriteList.instance.GetSprite(data.Key));
        }
        slotsBtn = GetComponentsInChildren<Button>();
        for(int i = 0; i < slotsBtn.Length; i++)
        {
            int index = i;
            slotsBtn[index].onClick.AddListener(() => OnSkillListBtnAct?.Invoke(this, new OnSkillListBtnActEventArgs
            {
                index = index
            }));
        }
    }


    
}
