using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonMainBar : MonoBehaviour
{
    
    #region variable
    public static PoseidonMainBar instance;
    public Transform mainBarDetail{get; private set;}
    public Transform skillExplain{get; private set;}
    public Transform skillInfo{get; private set;}
    public Transform skillArousal{get; private set;}
    public Transform skillIdentity{get; private set;}
    public Transform skillPreset{get; private set;}
    public Transform skillList{get; private set;}
    

    #endregion
    private void Awake() 
    {
        instance = this;
        mainBarDetail = transform.GetChild(0);
        skillExplain = mainBarDetail.GetChild(0);
        skillInfo = mainBarDetail.GetChild(1);
        skillArousal = mainBarDetail.GetChild(2);
        skillIdentity = mainBarDetail.GetChild(3);
        skillPreset = mainBarDetail.GetChild(4);
        skillList = mainBarDetail.GetChild(6).GetChild(0).GetChild(0);
    }
    private void Start() 
    {
        
        
    }

    
}
