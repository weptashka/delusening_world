using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCoin : AbstractPickableObject
{
    private PlayerStorageData _playerStorageData;

    protected override void Collect()
    {
        _playerStorageData.Set(PickableType.Coin, 1);
        Destroy(gameObject);

        Debug.Log("+HP");
    }
}
