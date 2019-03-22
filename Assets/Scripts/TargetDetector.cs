using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetDetector : MonoBehaviour, ITrackableEventHandler
{
    #region Private_Variables
    private TrackableBehaviour mTrackableBehaviour;
    #endregion

    #region Private_Functions
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    #endregion

    #region Public_Functions
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            GameManager.Detected = true;
        }
        else
        {
            GameManager.Detected = true;
        }
    }

    #endregion
}
