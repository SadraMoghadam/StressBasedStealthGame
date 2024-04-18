using System.Collections.Generic;

namespace UnityEngine.AI {
	[ExecuteInEditMode]
	[AddComponentMenu("Navigation/NavMeshModifierVolume", 31)]
	[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
	public class NavMeshModifierVolume : MonoBehaviour {
		[SerializeField]
		Vector3 m_Size = new(4.0f, 3.0f, 4.0f);

		public Vector3 size {
			get => m_Size;
			set => m_Size = value;
		}

		[SerializeField]
		Vector3 m_Center = new(0, 1.0f, 0);

		public Vector3 center {
			get => m_Center;
			set => m_Center = value;
		}

		[SerializeField]
		int m_Area;

		public int area {
			get => m_Area;
			set => m_Area = value;
		}

		// List of agent types the modifier is applied for.
		// Special values: empty == None, m_AffectedAgents[0] =-1 == All.
		[SerializeField]
		List<int> m_AffectedAgents = new(new int[] {-1}); // Default value is All

		static readonly List<NavMeshModifierVolume> s_NavMeshModifiers = new();

		public static List<NavMeshModifierVolume> activeModifiers => s_NavMeshModifiers;

		void OnEnable() {
			if (!s_NavMeshModifiers.Contains(this))
				s_NavMeshModifiers.Add(this);
		}

		void OnDisable() {
			s_NavMeshModifiers.Remove(this);
		}

		public bool AffectsAgentType(int agentTypeID) {
			if (m_AffectedAgents.Count == 0)
				return false;
			if (m_AffectedAgents[0] == -1)
				return true;
			return m_AffectedAgents.IndexOf(agentTypeID) != -1;
		}
	}
}
