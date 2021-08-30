using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtchASketchKnobWobbler : MonoBehaviour
{
    [SerializeField] private Transform leftKnob;
    [SerializeField] private Transform rightKnob;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (GameController.Instance.timerOn) {
            // Player Input
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                //rotate knob
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                //rotate knob
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                //rotate knob
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                //rotate knob
            }
            if (Input.GetKeyDown("space")) {
                //idk do something cool here

            }
        }
    }
}
