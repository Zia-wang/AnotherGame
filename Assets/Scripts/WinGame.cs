using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        GameController.instance.Win();
    }
}
