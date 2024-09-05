using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableHP : AbstractPickableObject
{
    private PlayerStorageData _playerStorageData;

    protected override void Collect()
    {
        _playerStorageData.Set(PickableType.HP, 1);
        Destroy(gameObject);

        Debug.Log("+HP");
    }
}
