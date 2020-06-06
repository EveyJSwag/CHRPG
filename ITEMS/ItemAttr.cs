using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttr : MonoBehaviour
{

   // Manager game_manager_properties = new Manager();
    InventoryController inv_controller_properties;
    public GameObject manager;

    public string Name = "Burnt Burger";
    public string Description = "Gross over cooked burger... But your crack head ass doesn't really care...";
    public int HP_restore = 20;
    public int AP_restore = 0;
    public void item_attr()
    {
        
    }
    void Start()
    {
        inv_controller_properties = GetComponentInParent<InventoryController>();
        //game_manager_properties = GetComponentInParent<Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //game_manager_properties.add_to_inventory(this.gameObject.name);
        inv_controller_properties.add_to_inventory(this.gameObject.name);
        Destroy(this.gameObject);
    }
    void Update()
    {
        
    }
}
