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
    private Transform midpointGrabObject,midPointVisualObject,midPointParent;

    [SerializeField]
    private float bowStrengthLimit = 0.3f;

    private Transform interactor;
    // Start is called before the first frame update

    private void Awake()
    {
        interactable = midpointGrabObject.GetComponent<XRGrabInteractable>();
    }
    void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        interactor = null;
        midpointGrabObject.localPosition = Vector3.zero;
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
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midpointGrabObject.position);
            
            float midpointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);
            HandStringPushedBackToStart(midPointLocalSpace);
            HandleStringPulledBackTolimit(midpointLocalZAbs, midPointLocalSpace);
            HandlePullingString(midpointLocalZAbs, midPointLocalSpace);
            bowStingRenderer.CreateString(midpointGrabObject.transform.position);

        }
    }

    private void HandlePullingString(float midpointLocalZAbs, Vector3 midPointLocalSpace)
    {
        throw new NotImplementedException();
    }

    private void HandleStringPulledBackTolimit(float midpointLocalZAbs, Vector3 midPointLocalSpace)
    {
        throw new NotImplementedException();
    }

    private void HandStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        throw new NotImplementedException();
    }
}
