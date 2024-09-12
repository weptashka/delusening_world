using UnityEngine;

public class PickableCoin : AbstractPickableObject
{
    protected override void Collect()
    {
        PlayerStorageData.SetPickableCount(PickableType.Coin, 1);
        Destroy(gameObject);

        Debug.Log("+Coin");
    }
}
