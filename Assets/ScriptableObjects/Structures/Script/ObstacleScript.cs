using UnityEngine;

public class ObstacleScript : StructureScript
{
    [SerializeField] private ObstacleData data;

    private void Start()
    {
        currHp = data.maxHp;
        direction = 1;
    }


}
