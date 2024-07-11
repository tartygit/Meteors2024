//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

public abstract class Command 
{
    protected IEntity _entity;

    public Command (IEntity entity)
    {
       _entity = entity; 
    }

    public abstract void Execute ();
    public abstract void Undo();
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
