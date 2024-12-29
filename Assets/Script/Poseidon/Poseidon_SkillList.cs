using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Poseidon_SkillList : MonoBehaviour
{
    [SerializeField] private Transform skillSlot;
    private Sprite[] sprites;
    private Button[] slotsBtn;
    private PoseidonSkillStaticDataManager poseidonInstance;
    public class OnBtnActEventArgs : EventArgs
    {
        public int num;
    }
    public event EventHandler<OnBtnActEventArgs> OnBtnAct;

    // Start is called before the first frame update
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Image/Poseidon");
        poseidonInstance  = PoseidonSkillStaticDataManager.GetInstance();
        Init();
    }
    private void Init()
    {
        
        poseidonInstance.LoadSkillDatas();

        foreach(var data in poseidonInstance.dicSkill_dataTable)
        {
            var skillInstance = Instantiate(skillSlot,transform);
            foreach(var sp in sprites)//스프라이트 찾기
            {
                if(sp.name == poseidonInstance.dicSkill_imageResourcesTable[data.Value.skill_imageNameIdx].skill_imageResources_imageName)
                {
                    skillInstance.GetComponent<Poseidon_SkillSlot>().Init(data.Key, sp);
                    
                    break;
                }
            }           
        }
        slotsBtn = GetComponentsInChildren<Button>();
        for(int i = 0; i < slotsBtn.Length; i++)
        {
            int index = i;
            slotsBtn[index].onClick.AddListener(() => OnBtnAct?.Invoke(this, new OnBtnActEventArgs
            {
                num = index
            }));
        }
    }


    
}
