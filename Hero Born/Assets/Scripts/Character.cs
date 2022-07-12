using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character ()
    {
        name = "Not Assigned";
    }

    public Character(string name)
    {
        this.name = name;
    }
}
