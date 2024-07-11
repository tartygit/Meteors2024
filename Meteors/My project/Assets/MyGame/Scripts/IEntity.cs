using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
    void MoveFromTo(Vector3 startPosition, Vector3 endPosition);
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
