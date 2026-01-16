using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float timer;

    void Start()
    {
        
    }

    /*bool Tick()
    {
        timer += Time.deltaTime;

        if (timer < 1f) return true;

        Debug.Log("TICK! " + Time.time);

        timer = 0f;
        return false;
    }

    private void FixedUpdate()
    {

    }

    protected void Update()
    {


        if(Tick()) return;

        print("Test call");
        
    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("POINTER ENTER");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("POINTER EXIT");
    }
}
