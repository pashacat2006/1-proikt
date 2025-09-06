using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;

public class Inventory : MonoBehaviour
{
    public GameObject cellcontanir;
    public bool cat1 = true;

    private List<Item> item;

    [SerializeField] private GameObject g;
    void menu()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {           
            g.SetActive(cat1);
            cat1 = !cat1;                          
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        item = new List<Item>();

        cellcontanir.SetActive(false);
        g.SetActive(false);

        for (int i = 0; i < cellcontanir.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        menu();
        Open();

        TakeItem();
    }

    void TakeItem()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.GetComponent<Item>())
            {
                on3(hit.collider.GetComponent<Item>());
            }
        }
    }
    void on3(Item currentItem)
    {
        if (currentItem.isStak)
        {
            on2(currentItem);
        }
        else
        {
            on1(currentItem);
        }
        if (currentItem.one == true)
        {
            on4(currentItem);
        }
    }
    void on1(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == 0)
            {
                item[i] = currentItem;
                item[i].countItem = 1;
                displa();
                Destroy(currentItem.gameObject);
                break;
            }
        }
    }
    void on2(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id ==currentItem.id)
            {
                item[i].countItem++;
                displa();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        on1(currentItem);
    }
    void on4(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == currentItem.id)
            {
                print("one");
                return;
            }
        }
    }
    void Open()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (cat1 == false)
            {
                return;
            }

            cellcontanir.SetActive(!cellcontanir.activeSelf);
        }
    }
    void displa()
    {
        for (int i = 0; i < item.Count; ++i)
        {
            Transform cell = cellcontanir.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);
            TextMeshProUGUI txt = count.GetComponent<TextMeshProUGUI>();
            Image img = icon.GetComponent<Image>();

            if (item[i].id != 0)
            {
                img.sprite = Resources.Load<Sprite>(item[i].pachIcon);
                img.enabled = true;
                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();
                    print(txt);
                }
            }
            else
            {
                img.sprite = null;
                txt.text = null;
                img.enabled = false;
            }
        }
    }
}
