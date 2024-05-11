using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpeeBehaviour : MeleeBehaviour
{
    EpeeController gc;
    protected override void Start()
    {
        base.Start();
        gc = FindObjectOfType<EpeeController>();
    }
}