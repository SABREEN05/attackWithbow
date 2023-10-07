using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class bowStringControl : MonoBehaviour
{
    [SerializeField]
    private lineRenderer1 bowStingRenderer;

    private XRGrabInteractable interactable;

    [SerializeField]
    private Transform midPointGrabObject,midPointVisualObject,midPointParent;

    [SerializeField]
    private float bowStrengthLimit = 0.3f;

    private Transform interactor;
    // Start is called before the first frame update

    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }
    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStingRenderer.CreateString(null);
    }

   

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
    }

    // Update is called once per frame
    public void Update()
    {
        if (interactor != null)
        {
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);
            
            float midpointLocalZAbs = Mathf.Abs(midPointLocalSpace.x);
            HandStringPushedBackToStart(midPointLocalSpace);
            HandleStringPulledBackTolimit(midpointLocalZAbs, midPointLocalSpace);
            HandlePullingString(midpointLocalZAbs, midPointLocalSpace);
            bowStingRenderer.CreateString(midPointVisualObject.position);

        }
    }

    private void HandlePullingString(float midpointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x > 0 && midpointLocalZAbs < bowStrengthLimit)
        {
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.x);
        }
    }

    private void HandleStringPulledBackTolimit(float midpointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x > 0 && midpointLocalZAbs >= bowStrengthLimit)
        {
            midPointVisualObject.localPosition = new Vector3(0, 0, bowStrengthLimit);
        }
    }

    private void HandStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.x <= 0 )
        {
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
}
