using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FreddyBehaviour : interactableBehaviour
{
    public override void Interact()
    {
        Info.Done = true ;
    }
}
