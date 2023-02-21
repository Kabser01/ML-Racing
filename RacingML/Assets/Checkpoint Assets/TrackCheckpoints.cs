using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints:MonoBehaviour {
    
    public Transform checkpointsTransform;

    private List<CheckpointSingle> checkpointSingleList;
    
    private int nextCheckpointSingleIndex;
    
    private void Awake() {
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) {          
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
            
        }

            nextCheckpointSingleIndex = 0; 
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle) {
        if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex) {
            Debug.Log("Correct!");
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
        } else { 
            Debug.Log("Wrong");
        }
    }
}