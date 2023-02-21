using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {

    private TrackCheckpoints trackCheckpoints; 
    [SerializeField] GameObject Player;


    private void OnTriggerEnter(Collider other) {
       if (other.gameObject == Player) {
         trackCheckpoints.PlayerThroughCheckpoint(this);
     
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }

}
