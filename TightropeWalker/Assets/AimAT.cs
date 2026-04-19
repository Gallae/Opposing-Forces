using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AimAT : ActionTask {

		public BBParameter<GameObject> player;
		public LineRenderer lr;
		Vector3 lineStart;
		Vector3 lineDirection;
		float growSpeed = 10f;
		float currentLength = 0f;
		Vector3 currentLineEnd = Vector3.zero;
		float aimDuration;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			aimDuration = 0.5f;
            lr.positionCount = 2;
			lineStart = agent.transform.position;
			currentLineEnd = lineStart;
			lr.SetPosition(0, lineStart);
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            lineDirection = (player.value.transform.position - (agent.transform.position - new Vector3(0, 1.5f, 0))).normalized;

			currentLength += growSpeed * Time.deltaTime;
			currentLineEnd = lineStart + (lineDirection * currentLength);

			if (Vector3.Distance(lineStart, currentLineEnd) > Vector3.Distance(lineStart, player.value.transform.position))
			{
				aimDuration -= Time.deltaTime;
				if (aimDuration <= 0f)
				{
					lr.positionCount = 0;
					currentLength = 0f;
					currentLineEnd = lineStart;
					EndAction(true);
				}
			}
            else
            {
                lr.SetPosition(0, lineStart);
                lr.SetPosition(1, currentLineEnd);
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