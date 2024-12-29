using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poseidon_PresetSlot : MonoBehaviour
{
    public bool isChange{get; private set;}
    private Transform targetImage;

    private void Awake() 
    {
        targetImage = transform.GetChild(1);
    }
    public void ImageChange()
    {
        isChange = !isChange;
        targetImage.gameObject.SetActive(isChange);
    }
    public void ImageClear()
    {
        targetImage.gameObject.SetActive(false);
    }

    
}
