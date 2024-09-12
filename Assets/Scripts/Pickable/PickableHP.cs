using UnityEngine;

public class PickableHP : AbstractPickableObject
{
    protected override void Collect()
    {
        PlayerStorageData.SetPickableCount(PickableType.HP, 1);
        Destroy(gameObject);

        Debug.Log("+HP");
    }
}
