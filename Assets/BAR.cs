using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAR : MonoBehaviour
{
    public Item[] items;
    const int max = 5;
    public int[] counts;


    private void Start()
    {
        for (int i = max - 1; i >= 0; i--)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < items.Length; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = items[i].itemImage;
            counts[i] = 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled == true)
            {
                counts[0]--;
                //items[0] 아이템 사용
                items[0] = null;
            }

            if (counts[0] == 0)
                transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled == true)
            {
                counts[1]--;
            }

            if (counts[1] == 0)
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled == true)
            {
                counts[2]--;
            }

            if (counts[2] == 0)
                transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (transform.GetChild(3).GetChild(0).GetComponent<Image>().enabled == true)
            {
                counts[3]--;
            }

            if (counts[3] == 0)
                transform.GetChild(3).GetChild(0).GetComponent<Image>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (transform.GetChild(4).GetChild(0).GetComponent<Image>().enabled == true)
            {
                counts[4]--;
            }

            if (counts[4] == 0)
                transform.GetChild(4).GetChild(0).GetComponent<Image>().enabled = false;
        }

    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < max; i++)
        {
            if (transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled == false)
            {
                items[i] = item;
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = item.itemImage;
                transform.GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;
            }
            
        }
    }
}
