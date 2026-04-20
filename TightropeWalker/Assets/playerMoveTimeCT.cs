using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class playerMoveTimeCT : ConditionTask {

		public float playerMoveTimer;
		bool playerTimerEnded = false;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            playerMoveTimer = Random.Range(3.3f, 5f);

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            if (playerTimerEnded == true)
			{
				playerMoveTimer = Random.Range(3.3f, 5f);
            }	
            playerTimerEnded = false;
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (Input.GetKey(KeyCode.W))
			{
				playerMoveTimer -= Time.deltaTime;
			}
			if (playerMoveTimer <= 0)
			{
				playerTimerEnded = true;
            }
			if (Input.GetKeyUp(KeyCode.W))
			{
				playerMoveTimer = Random.Range(3.3f, 5f);
				playerTimerEnded = false;
            }
            return playerTimerEnded;
		}
	}
}