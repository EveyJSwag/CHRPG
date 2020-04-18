using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExpManager : MonoBehaviour
{
    private int total_experience;
 
    public void gainExp(int expGained) {
        total_experience += expGained;
    }
    public int calculateLevel() {
        return (int)Math.Round( Math.Sqrt(total_experience) *0.01, 2);
    }

}
