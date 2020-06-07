using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public GameObject myTextgameObject; // gameObject in Hierarchy
    public Text ourComponent;           // Our refference to text component
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeText()
    {
        ourComponent.GetComponent<Text>().text = "Player" + myTextgameObject.GetComponent<GameManager>().turn;
    }
}
