using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		public GameObject rope;
		int shakeCounter;
		Vector3 originalPos;
        Vector3 shakePos = new Vector3(0,0.25f,0);

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			originalPos = rope.transform.position;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			shakeCounter = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (shakeCounter % 20 == 0)
            {
                Debug.Log("up");
                rope.transform.position += shakePos;
            }
            if (shakeCounter % 20 == 10)
            {
                Debug.Log("down");
                rope.transform.position -= shakePos;
            }
            shakeCounter++;
            if (shakeCounter >= 100)
            {
                rope.transform.position = originalPos;
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