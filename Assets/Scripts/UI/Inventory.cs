using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

class Inventory:ISingletonMonoBehaviour<Inventory> {
    public UnityAction onItemChanged;
}
