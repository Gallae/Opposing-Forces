using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveBackAT : ActionTask {

		public BBParameter<UnityEngine.Vector3> position1;
		public BBParameter<UnityEngine.Vector3> position2;

		bool atRope;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			atRope = true;
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (atRope == true)
            {
                agent.transform.position = UnityEngine.Vector3.MoveTowards(agent.transform.position, position1.value, 2f * Time.deltaTime);
            }
            if (Vector3.Distance(agent.transform.position, position1.value) < 0.2f)
            {
                atRope = false;
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