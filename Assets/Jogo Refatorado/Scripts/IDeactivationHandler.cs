using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDeactivationHandler {

    public void DeactivationStarted();

    public void DisableObject();

    public void OnTriggerEnter2D(Collider2D collider);

}