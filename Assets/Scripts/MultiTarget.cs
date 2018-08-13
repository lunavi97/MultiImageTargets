using UnityEngine;
using Vuforia;

using UnityEngine.UI;

public class MultiTarget : MonoBehaviour, ITrackableEventHandler
{
    #region PUBLIC_MEMBER_VARIABLES

    public int targetValue;
    public Text textBox;

    #endregion // PUBLIC_MEMBER_VARIABLES

    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    private enum Form
    {
        Cube,
        Sphere,
        Cylinder,
        Capsule
    };

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        textBox.text = "...";
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            targetDetection(targetValue);
        }
        else
        {
            textBox.text = "...";
        }
    }

    void targetDetection(int num)
    {
        switch (num)
        {
            case (int)Form.Cube:
                textBox.text = "Cube";
                break;

            case (int)Form.Sphere:
                textBox.text = "Sphere";
                break;

            case (int)Form.Cylinder:
                textBox.text = "Cylinder";
                break;

            case (int)Form.Capsule:
                textBox.text = "Capsule";
                break;

            default:
                break;
        }
    }

    #endregion // PUBLIC_METHODS
}
