using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    
    public int physicalAtk;
    
    public int magicAtk;
  
    public int physicalDef;
   
    public int magicDef;
    
    public string characterName;

    protected enum statAbnomal
    {
        Poision,
        Paralysis,
        Confusion,
        Sleep
    }

    protected void HitStatAbnomal()
    {

    }

}
