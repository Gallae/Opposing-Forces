using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class ChuckleAT : ActionTask {

		Vector3 laughPos;
		
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			laughPos = new Vector3(0, 0.5f, 0);
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			for (int i = 0; i < 20; i++)
			{
				if (i < 10)
				{
					Debug.Log("up");
                    //agent.transform.position += laughPos;
                    agent.transform.position = UnityEngine.Vector3.MoveTowards(agent.transform.position, (agent.transform.position + laughPos), 1f);
                }
                else
                {
                    Debug.Log("down");
                    agent.transform.position = UnityEngine.Vector3.MoveTowards(agent.transform.position, (agent.transform.position - laughPos), 1f);
                }
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