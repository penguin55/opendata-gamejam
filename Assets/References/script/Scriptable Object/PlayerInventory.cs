using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInventory : ScriptableObject, ISerializationCallbackReceiver
{
    public int coin;

    public void OnAfterDeserialize()
    {
        coin = 0;
    }

    public void OnBeforeSerialize()
    {

    }
}
