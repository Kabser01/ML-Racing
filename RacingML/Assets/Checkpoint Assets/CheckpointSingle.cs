using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {

    private TrackCheckpoints trackCheckpoints; 
    [SerializeField] GameObject Player;


    private void OnTriggerEnter(Collider other) {
       if (other.gameObject == Player) {
        //if (other.TryGetComponent<Mesg>(out Player player)) {
        trackCheckpoints.CarThroughCheckpoint(this, other.transform);

        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }

}
