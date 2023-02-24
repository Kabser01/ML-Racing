using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents; 
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors; 
using VehiclePhysics;
using EVP;


public class CarAgent : Agent {

    [SerializeField] private TrackCheckpoints trackCheckpoints; 
    [SerializeField] private Transform spawnPosition; 
    public EVP.VehicleController VehicleController;
    public override void OnActionReceived(ActionBuffers actions) { 
        

    }
    public override void CollectObservations(VectorSensor sensor) { 
        sensor.AddObservation(transform.position); // When taking a position vector, this is comprised of 3 floats, so make sure to adjust the space size for Vector Observations by 3 instead of 1 each time a new position vector is added. 
        sensor.AddObservation(VehicleController.speed);
    }
    
    private void Start() { 
        
    }
} 
