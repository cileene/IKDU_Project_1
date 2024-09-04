using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NixWeight : MonoBehaviour
{

    private int nickAge;
    private float nickWeight;
    private string nickName;
    // Start is called before the first frame update
    void Start()
    {
        nickWeight = 67.0f;
        nickAge = 33;
        nickName = "Nick Lee Jerlung";
        Debug.Log($"Her er {nickName} og han er {nickAge} år gammel og vejer {nickWeight} kg");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
