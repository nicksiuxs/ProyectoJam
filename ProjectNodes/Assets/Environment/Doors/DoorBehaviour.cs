using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public List<ReceiverNodeElectricBehaviour> receiverNodes;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!receiverNodes.Exists(e => !e.isOn))
        {
            isOpen = true;
        }
    }
}
