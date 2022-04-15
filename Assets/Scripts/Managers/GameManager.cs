using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameObject PlayerReference;

    public GameObject PlayerRef
    {
        get
        {
            return PlayerReference;
        }
        set
        {
            PlayerReference = value;
            Debug.Log("Player added to GameManager", value);
        }
    }
}
