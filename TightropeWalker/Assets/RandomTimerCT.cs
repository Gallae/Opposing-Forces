using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RandomTimerCT : ConditionTask {

		public float randomTimer;
		bool timerEnded;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
            randomTimer = Random.Range(1.3f, 4.2f);
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            timerEnded = false;
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            randomTimer -= Time.deltaTime;
            if (randomTimer <= 0.5f) {
                timerEnded = true;
            }
            if (randomTimer <= 0)
            {
                randomTimer = Random.Range(2.3f, 4.8f);
            }
            Debug.Log("timer reset");
            return timerEnded;
        }
	}
}