using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Need to know how to sort monsters, Implement a Comparer
public class DoorSorter : IComparer
{

    // Calls CaseInsensitiveComparer.Compare on the monster name string.
    int IComparer.Compare(System.Object x, System.Object y)
    {
        return ((new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name));
    }

}