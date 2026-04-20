using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class ChuckleAT : ActionTask {

		Vector3 originalPos;
        Vector3 laughPos = new Vector3(0, 0.5f, 0);
		int laughCounter;
        float timer;
        bool laughUp;

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
            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                timer = 0f;
                Debug.Log("up");
                if (!laughUp)
                {
                    agent.transform.position += laughPos;
                }
                else
                {
                    agent.transform.position -= laughPos;
                }
                laughUp = !laughUp;
                laughCounter++;
            }
            if (laughCounter >= 6)
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