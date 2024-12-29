using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Navigator : MonoBehaviour
{
    public EventSystem ev;
    public GameObject target;

    private bool isSelected = false;

    // Start is called before the first frame update
    void Update()
    {
        if( Input.GetAxisRaw("Horizontal") != 0f && !isSelected ){
            ev.SetSelectedGameObject(target);
            isSelected = true;
        }
    }
    private void OnDisable(){
            isSelected = false;
        }
    public void Selectbefore() {
        ev.SetSelectedGameObject(target);
        isSelected = true;
    }
}
