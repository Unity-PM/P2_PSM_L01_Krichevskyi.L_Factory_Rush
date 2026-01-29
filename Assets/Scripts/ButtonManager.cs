using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject beltPref;
    [SerializeField] private GameObject factoryPref;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyPressed();
        }
    }


    private void KeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SelectionManager.Instance.GetSelectedCount() == 0)
                return;

            List<Vector2Int> copyXZ = SelectionManager.Instance.GetAllPosition();
            foreach (var xz in copyXZ)
            {
                BuildManager.Instance.RemoveObject(xz);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CardSystem.Instance.SpawnCard(beltPref);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CardSystem.Instance.SpawnCard(factoryPref);
        }
    }
}
