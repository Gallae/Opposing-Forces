using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FlashRedAT : ActionTask {

		public Color defaultColour;
		public float flashDuration = 1.6f;
		public Material childMatDefault;
		public Material childMatHyper;
		public GameObject body;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            flashDuration = 1.6f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			flashDuration -= Time.deltaTime;
			if(flashDuration <= 0.8f)
			{
				FlashRed();
            }
			//else
			//{
			//	EndAction(true);
   //         }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		void FlashRed()
		{
			Debug.Log("flashing red");
            body.GetComponent<Renderer>().material = childMatHyper;
            if (flashDuration <= 0f)
			{
                body.GetComponent<Renderer>().material = childMatDefault;
				Debug.Log("flash reset");
				EndAction(true);
            }
        }
	}
}