using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AimAT : ActionTask {

		public BBParameter<GameObject> player;
		public LineRenderer lr;
		Vector3 lineStart;
		Vector3 lineDirection;
		float lineLength = 10f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			lineStart = agent.transform.position;
			lineDirection = (player.value.transform.position - agent.transform.position).normalized;
			lr.SetPosition(0, lineStart);
			lr.SetPosition(1, lineStart + (lineDirection * lineLength));
            //EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            lr.SetPosition(1, lineStart + (lineDirection * lineLength));
            //Debug.DrawRay(agent.transform.position, (player.value.transform.position - agent.transform.position) * 10, Color.red, 1f);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}