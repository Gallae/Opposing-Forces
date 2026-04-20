using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class ChuckleAT : ActionTask {

		Vector3 originalPos;
        Vector3 laughPos = new Vector3(0, 0.5f, 0);
		int laughCounter;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			originalPos = agent.transform.position;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			laughCounter = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (laughCounter % 2 == 0)
            {
                Debug.Log("up");
                agent.transform.position += laughPos;
            }
            else
            {
                Debug.Log("down");
                agent.transform.position -= laughPos;
            }
            laughCounter++;
            if (laughCounter >= 100)
            {
                agent.transform.position = originalPos;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}