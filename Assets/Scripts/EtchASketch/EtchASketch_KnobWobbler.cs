using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtchASketch_KnobWobbler : MonoBehaviour
{
    [SerializeField] private Transform leftKnob;
    [SerializeField] private Transform rightKnob;
    
    // Update is called once per frame
    void Update() {
        if (GameController.Instance.timerOn) {
            // Player Input to rotate knobs
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                leftKnob.Rotate(new Vector3(0, 0, 45));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                leftKnob.Rotate(new Vector3(0, 0, -45));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                rightKnob.Rotate(new Vector3(0, 0, 45));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                rightKnob.Rotate(new Vector3(0, 0, -45));
            }
            if (Input.GetKeyDown("space")) {
                //idk do something cool here

            }
        }
    }
}
