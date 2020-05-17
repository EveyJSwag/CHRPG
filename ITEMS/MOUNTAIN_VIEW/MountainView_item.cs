using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainView_item : ITEM
{
    
    public void item_attr() {
        Name = "Mountain View";
        Description = "Knock off mountain dew... You can't even get Mello Yellow";
        HP_restore = 0;
        AP_restore = 10;
    }
    void Start()
    {
        item_attr();
    }
    
    void Update()
    {
        
    }
}
