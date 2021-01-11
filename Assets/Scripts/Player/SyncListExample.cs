using System;
using System.Linq;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class SyncListExample : NetworkBehaviour
    {
        // readonly SyncList<string> _syncListString = new SyncList<string>();
        readonly SyncList<Item> _syncListItem = new SyncList<Item>();

        private string[] items = new[] {"Epée", "Marteau", "Arc", "Gatling"};

        private NetworkIdentity _networkIdentity;

        public class Item
        {
            public string NomItem;
            public int CoutItem;
        }
        
        private void Start()
        {
            NetworkIdentity identity = GetComponent<NetworkIdentity>();
            UiWithSyncListExample.Singleton.CreateItemForPlayer((int) identity.netId);

            _networkIdentity = GetComponent<NetworkIdentity>();
            // _syncListString.Callback += OnListUpdated;
            _syncListItem.Callback += OnItemListUpdated;
        }

        void OnListUpdated(SyncList<string>.Operation op, int index, string oldItem, string newItem)
        {
            switch (op)
            {
                case SyncList<string>.Operation.OP_ADD:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<string>.Operation.OP_CLEAR:
                    // list got cleared
                    break;
                case SyncList<string>.Operation.OP_INSERT:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<string>.Operation.OP_REMOVEAT:
                    // index is where it got removed in the list
                    // item is the item that was removed
                    break;
                case SyncList<string>.Operation.OP_SET:
                    // index is the index of the item that was updated
                    // item is the previous item
                    break;
            }

            UpdateUiSection((int)_networkIdentity.netId);
        }

        void OnItemListUpdated(SyncList<Item>.Operation op, int index, Item oldItem, Item newItem)
        {
            switch (op)
            {
                case SyncList<Item>.Operation.OP_ADD:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<Item>.Operation.OP_CLEAR:
                    // list got cleared
                    break;
                case SyncList<Item>.Operation.OP_INSERT:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<Item>.Operation.OP_REMOVEAT:
                    // index is where it got removed in the list
                    // item is the item that was removed
                    break;
                case SyncList<Item>.Operation.OP_SET:
                    // index is the index of the item that was updated
                    // item is the previous item
                    break;
            }

            UpdateUiSection((int)_networkIdentity.netId);
            
        }
        
        private void Update()
        {
            if (hasAuthority && Input.GetKeyDown(KeyCode.Space))
            {
                CmdAddNewItem(RandomItem());
            }
        }

        Item RandomItem()
        {
            Item newItem = new Item();
            newItem.NomItem = items[(int) UnityEngine.Random.Range(0, items.Length)];
            newItem.CoutItem = (int) Random.Range(0, 200);
            return newItem;
        }

        [Command]
        private void CmdAddNewItem(Item item)
        {
            // _syncListString.Add(s);
            _syncListItem.Add(item);
        }
        
        void UpdateUiSection(int idPlayer)
        {
            string content = "";

            foreach (var item in _syncListItem)
            {
                content += "Nom:" + item.NomItem + " Coût:" + item.CoutItem + "_";
            }
            
            UiWithSyncListExample.Singleton.UpdateItemForPlayer(idPlayer, content);
        }
        
    }
}