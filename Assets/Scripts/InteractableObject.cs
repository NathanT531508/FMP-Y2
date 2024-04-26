using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;

    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && selectionmanager.Instance.OnTarget && selectionmanager.Instance.selectedObject == gameObject)
        {

            //if the inventory is NOT full
            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);
                Debug.Log("item worked");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("inventory full");
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            playerInRange= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
