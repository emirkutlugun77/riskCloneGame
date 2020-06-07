using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiAppear : MonoBehaviour
{
    [SerializeField] private Image customImage;
    public GameObject gameManager;
     void Update()
    {
        if(gameManager.GetComponent<GameManager>().panelOpener)
        {
            customImage.enabled = true;
            StartCoroutine(MyCoroutine());
            customImage.enabled = false;
        }
    }
    IEnumerator MyCoroutine()
    {
        //This is a coroutine

        
        yield return 2;    //Wait one frame
       

    }

}
