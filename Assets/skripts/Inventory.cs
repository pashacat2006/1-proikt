using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Inventory : MonoBehaviour
{
    List<Item> item;
    public GameObject cellcontanir;
    // Start is called before the first frame update
    void Start()
    {
        item = new List<Item>();
        cellcontanir.SetActive(false);
        for (int i = 0; i < cellcontanir.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Open();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                   for (int i = 0; i < item.Count; i++)
                    {
                        if (item[i].id==0)
                        {
                            item[i] = hit.collider.GetComponent<Item>();
                            displa();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }
    void Open()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (cellcontanir.activeSelf)
            {
                cellcontanir.SetActive(false);

            }
            else
            {
                cellcontanir.SetActive(true);
            }
        }
    }
    void displa()
    {
        for (int i = 0; i < item.Count; ++i)
        {
            Transform cell = cellcontanir.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                img.sprite = Resources.Load<Sprite>(item[i].pachIcon);
                img.enabled = true;
            }
            else
            {
                img.sprite = null;
                img.enabled = false;
            }
        }
    }
}
