using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;
using Image = UnityEngine.UI.Image;
using TMPro;

public class Inventory : MonoBehaviour
{
    List<Item> item;
    public GameObject cellcontanir;
    protected bool cat1 = true;
    [SerializeField]
    private GameObject g;
    void menu()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (g.activeSelf)
            {
                g.SetActive(true);
                cat1 = false;
            }
            else
            {
                g.SetActive(false);
                cat1 = true;
            }
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
            if (cat1 == true)
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
                txt.text = item[i].countItem.ToString();
                print(txt);
            }
            else
            {
                img.sprite = null;
                img.enabled = false;
            }
        }
    }
}
