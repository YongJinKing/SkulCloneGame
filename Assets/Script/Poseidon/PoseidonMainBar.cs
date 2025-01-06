using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonMainBar : MonoBehaviour
{
    #region prefab
    #endregion
    #region variable
    private Transform mainBarDetail;
    private Transform skillExplain;
    private Transform skillInfo;
    private Transform skillArousal;
    private Transform skillIdentity1;
    private Transform skillIdentity2;
    private Transform skillPreset;
    

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
        
    }

    
}
