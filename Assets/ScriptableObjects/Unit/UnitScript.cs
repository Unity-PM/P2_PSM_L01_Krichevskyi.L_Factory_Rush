using UnityEngine;

public class UnitScript : MonoBehaviour
{
    protected int currHp = 1;

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual string GetDisplayName()
    {
        return gameObject.name;
    }

}

