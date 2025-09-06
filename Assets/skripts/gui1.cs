using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gui1 : MonoBehaviour
{
    public GameObject cat1;
    public GameObject cat2;
    private void Update()
    {
        Inventory inven = GetComponent<Inventory>(); bool cat = inven.cat1;
        if (cat == false)
        {
            cat1.SetActive(false);
            cat2.SetActive(false);
        }
        else
        {
            cat1.SetActive(true);
            cat2.SetActive(true);
        }
    }
}
