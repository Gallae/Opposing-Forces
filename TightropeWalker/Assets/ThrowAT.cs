using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThrowAT : ActionTask {

		public GameObject player;
		public GameObject peanut;
		public float throwForce = 100f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if (player.GetComponent<testMover>().playerFling == false)
            {
                Object.Instantiate(peanut, agent.transform.position + new Vector3(0,5.5f,0), Quaternion.identity).GetComponent<Rigidbody>().AddForce((player.transform.position - (agent.transform.position + new Vector3(0,2.7f,0))).normalized * throwForce, ForceMode.Impulse);
            }
            EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}