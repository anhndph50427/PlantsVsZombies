using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildPos : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image ImagePos;
    [SerializeField] private GameObject CurrentObject;
    void Start()
    {
        ImagePos = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(CurrentObject != null)
        {
            Debug.Log("Vị trí này đang có Plant");
        }
        else
        {
            if(eventData.pointerDrag != null) // PointerDrag sẽ tham chiếu đến object đang được kéo
            {
                CurrentObject = Instantiate(DropObjectCurrent.objectCurrent , transform.position , Quaternion.identity);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImagePos.color = new Color(0, 0, 0, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImagePos.color = new Color(0 , 0 , 0 , 0);
    }
}
