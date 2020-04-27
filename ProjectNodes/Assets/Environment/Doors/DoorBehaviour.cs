using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public List<ReceiverNodeElectricBehaviour> receiverNodes;
    public bool isOpen = false;
    public string sceneName;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!receiverNodes.Exists(e => !e.isOn))
        {
            isOpen = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == player.tag && isOpen)
        {
            GameController.changeScene(sceneName);
        }
    }
}
