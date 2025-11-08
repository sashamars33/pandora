using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, Torches
{

    public void illuminate()
    {
        Destroy(gameObject);
    }

}
