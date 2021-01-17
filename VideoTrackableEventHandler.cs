public class VideoTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS
    protected override void OnTrackingLost()
    {
        mTrackableBehaviour.GetComponentInChildren<VideoController>().Pause();

        base.OnTrackingLost();
    }

    #endregion // PROTECTED_METHODS
}
