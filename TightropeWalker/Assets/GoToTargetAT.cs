using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using static Unity.Burst.Intrinsics.X86;


namespace NodeCanvas.Tasks.Actions {

	public class GoToTargetAT : ActionTask {

		public BBParameter<GameObject> target;
		public BBParameter<NavMeshAgent> nma;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            nma.value.SetDestination(target.value.transform.position);
            EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}