using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcomponent : MonoBehaviour {


	public enum state{m_null=0,m_Grow,m_Waiting,m_Small};
	public state State;
	float m_fGrowTime;

	void Update ()
	{
		if (State == state.m_null) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				State = state.m_Grow;
			}
		}

		if (State==state.m_Grow) {
			this.transform.localScale += Vector3.one * Time.deltaTime;
			if (this.transform.localScale.x >= 2) {
				this.transform.localScale = Vector3.one * 2;
				m_fGrowTime = 2f;
				State = state.m_Waiting;
			}
		}
		if (0 < m_fGrowTime) {
			m_fGrowTime -= Time.deltaTime;
			if (0 >= m_fGrowTime) {
				State = state.m_Small;
			}
		}

		if (State==state.m_Small) {
			this.transform.localScale -= Vector3.one * Time.deltaTime;
			if (this.transform.localScale.x <= 1) {
				this.transform.localScale = Vector3.one;
				State = state.m_null;
			}
		}
	}
}