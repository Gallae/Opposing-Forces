using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		public GameObject rope;
		public GameObject player;
		int shakeCounter;
		float timer;
		bool ropeUp;
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
			timer += Time.deltaTime;
			player.GetComponent<testMover>().ropeShaking = true;
            if (timer >= 0.15f)
            {
				timer = 0f;
                Debug.Log("up");
				if (!ropeUp)
				{
					rope.transform.position += shakePos;
                }
				else
				{
					rope.transform.position -= shakePos;
                }
				ropeUp = !ropeUp;
				shakeCounter++;
            }
            if (shakeCounter >= 15)
            {
                rope.transform.position = originalPos;
				player.GetComponent<testMover>().ropeShaking = false;
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