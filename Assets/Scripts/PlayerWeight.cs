using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeight : MonoBehaviour
{

    public int playerAge = 33;
    public float playerWeight = 68.0f;
    public string playerName = "Nick Lee Jerlung";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Her er {playerName} og han er {playerAge} år gammel og vejer {playerWeight} kg");
        LooseWeight(3.0f);
        Debug.Log($" {playerName} har tabt sig og vejer nu {playerWeight} kg");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LooseWeight(float weightToLoose)
    {
        playerWeight -= weightToLoose;

    }
}
