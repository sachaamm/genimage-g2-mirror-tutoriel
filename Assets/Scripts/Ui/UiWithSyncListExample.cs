using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UiWithSyncListExample : MonoBehaviour
{
    public static UiWithSyncListExample Singleton;

    public GameObject itemPrefab;

    public Transform listContent;

    private void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        ClearContent();
    }

    void ClearContent()
    {
        foreach (Transform content in listContent)
        {
            Destroy(content.gameObject);
        }
    }

    public void CreateItemForPlayer(int idPlayer)
    {
        GameObject newItem = Instantiate(itemPrefab, listContent);
        newItem.transform.name = "Item_" + idPlayer;
    }

    public void UpdateItemForPlayer(int idPlayer, string itemContent)
    {
        GameObject item = GameObject.Find("Item_" + idPlayer);
        Text text = item.GetComponentInChildren<Text>();
        text.text = "Content for player " + idPlayer + ":" + itemContent;
    }


    void Update()
    {
    }
}