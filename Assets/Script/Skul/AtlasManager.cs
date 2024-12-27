using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class AtlasManager : MonoBehaviour
{
    private SpriteAtlas[] spriteAtlasArr;
    private Sprite[] sprites;

    private void Start() 
    {
        spriteAtlasArr = Resources.LoadAll<SpriteAtlas>("Image/Posaidon");
        sprites = Resources.LoadAll<Sprite>("Image/Posaidon/Skill1");
        Debug.Log(spriteAtlasArr.Length);
        Debug.Log(sprites[0].name);
    }
}
