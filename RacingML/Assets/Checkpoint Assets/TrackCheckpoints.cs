using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints:MonoBehaviour {
    
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    public Transform checkpointsTransform;

    private List<CheckpointSingle> checkpointSingleList;


    [SerializeField] private List<Transform> carTransformList; 
    private List<int> nextCheckpointSingleIndexList; 

    private int nextCheckpointSingleIndex;
    
    private void Awake() {
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) {          
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
            
        }

            nextCheckpointSingleIndexList = new List<int>();
            foreach (Transform carTransform in carTransformList){ 
                nextCheckpointSingleIndexList.Add(0); 
            } 

            nextCheckpointSingleIndex = 0; 
    }

    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform) {
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex) {
            Debug.Log("Correct!");
            nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)] = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        } else { 
            Debug.Log("Wrong");
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
        }
    }
}