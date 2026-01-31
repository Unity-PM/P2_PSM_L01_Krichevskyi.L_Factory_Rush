using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] protected int currHp = 1;

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }

}

