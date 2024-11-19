using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using DG.Tweening;
using nm_canvasPanel;

public class TextEffect : UIBehaviour, IMeshModifier {

//	float time = 0;
//	float radius = 1.5f;
	bool dsp_on = false;
	float off_time = 4;
	const int time_keta = 6;
	public float offset = 0.0f;
	Vector3 pos;
	public float startX = 0;
	public float delay;
//	float f_Speed = 40;
/*
	public new  void  OnValidate()
	{
		base.OnValidate ();

		var graphics = base.GetComponent<Graphic> ();
		if (graphics != null) {
			graphics.SetVerticesDirty ();
		}
	}
*/
	public void ModifyMesh (Mesh mesh){}

	public void ModifyMesh (VertexHelper verts)
	{
		if (!IsActive())
			return;

		List<UIVertex> vertices = new List<UIVertex>();
		verts.GetUIVertexStream(vertices);

		TextMove(ref vertices);

		verts.Clear();
		verts.AddUIVertexTriangleStream(vertices);
	}

	// text wave animation
	public void SetVerticesDirty() {

		dsp_on = true;
		var rectTransform = this.gameObject.GetComponent<RectTransform>();
		var seq = DOTween.Sequence();
		seq.Append(rectTransform.DOMoveY(rectTransform.position.y + 20.0f, 0.2f).SetDelay(delay));
		seq.Append(rectTransform.DOMoveY(rectTransform.position.y, 0.1f));
		//seq.Append(rectTransform.DOMoveY(rectTransform.position.y + 100.0f, 0.2f).SetDelay(delay));
		//seq.Append(rectTransform.DOMoveY(rectTransform.position.y + 80.0f, 0.1f));

		//		seq.Append(rectTransform.DOLocalMoveY(10.0f, 0.2f).SetDelay(delay));
		//		seq.Append(rectTransform.DOLocalMoveY(-40.0f, 0.1f));
	}

	//	public RectTransform rectTransform;
	void TextMove( ref List<UIVertex> vertices )
	{



		for (int c = 0; c < vertices.Count; c += 6)
		{
			
//			var rectTransform = vert.GetComponent<RectTransform>();
//			var seq = DOTween.Sequence();
//			seq.Append(vert.DOLocalMoveY(5f, 0.2f).SetDelay(0.1f * c));
//			seq.Append(vert.DOLocalMoveY(0f, 0.1f));

//			if (offset < 5.0f)
//				base.GetComponent<RectTransform>().Translate(new Vector3 (0,10,0) * f_Speed * Time.deltaTime);
//			else if (offset < 10.0f)
//				base.GetComponent<RectTransform>().Translate(new Vector3 (0,-10,0) * f_Speed * Time.deltaTime);
//			else
//				base.GetComponent<RectTransform>().Translate(new Vector3 (0,0,0) * f_Speed * Time.deltaTime);
//			
//			float rad = Random.Range(0,360) * Mathf.Deg2Rad;
//			Vector3 dir = new Vector3 (radius * Mathf.Cos (rad), radius * Mathf.Sin (rad), 0);

//			Vector3 pos = new Vector3 (0,0,0);
//			if (offset < 5.0f) {
//				pos = Vector3 (0,0.05f,0);
//				pos = pos * f_Speed * Time.deltaTime;
//			}
//			else if (offset < 10.0f) {
//				pos = Vector3 (0,-0.05f,0);
//				pos = pos * f_Speed * Time.deltaTime;
//			}
//			else {
//				Vector3 pos = new Vector3 (0,0,0);
//				pos = pos * f_Speed * Time.deltaTime;
//			}

			for(int i = 0; i < 6; i++)
			{

//				var vert       = vertices [c+i];
//				if (offset < 5.0f) 
//					vert.position  += new Vector3(0, 5.0f, 0) * f_Speed * Time.deltaTime;
//				else  if (offset < 10.0f)
//					vert.position  += new Vector3(0, -5.0f, 0) * f_Speed * Time.deltaTime;
////				else
////					vert.position  += new Vector3(0, 0.0f, 0) * f_Speed * Time.deltaTime;
//				
//				vertices [c+i] = vert;


//				var vert = vertices [c+i];
//				rectTransform = new RectTransform();
//				rectTransform.anchoredPosition = vert.position;
//				var seq = DOTween.Sequence();
//				seq.Append(rectTransform.DOLocalMoveY(5f, 0.2f).SetDelay(0.1f * c));
//				seq.Append(rectTransform.DOLocalMoveY(0f, 0.1f));

//				var vert       = vertices [c+i];
//				vert.position  = vert.position + dir;
//				vertices [c+i] = vert;
			}
		}
	}

	void Update()
	{
//		if (offset < 6.0f) {
//			time += Time.deltaTime;
//			if (time > 0.05f)
//			{
//				time = 0;
//				base.GetComponent<Graphic> ().SetVerticesDirty ();
//			}
//		}

/*		time += Time.deltaTime;
		if (time > delay)
		{
			if (time < 0.3f) {
				this.GetComponent<RectTransform>().Translate(new Vector3 (0,5.0f,0) * f_Speed * Time.deltaTime);
				offset++;
			}
			else if (time < 0.6f) {
				this.GetComponent<RectTransform>().Translate(new Vector3 (0,-5.0f,0) * f_Speed * Time.deltaTime);
				offset++;
			}
			else {
				this.GetComponent<RectTransform>().Translate(new Vector3 (0,0,0) * f_Speed * Time.deltaTime);
			}
			
		}
*/
		// テキストOFF
		if (dsp_on) {
			off_time -= Time.deltaTime;
			int k = time_keta;
			string st = @"D" + k.ToString();
			int val = (int)off_time;
			string str1 = val.ToString(st);
			if (int.Parse(str1) <= 0) {
				nm_sphere.sphere.pointDSPOff();
				dsp_on = false;
	//			off_time = 5;
			}
	//		else {
	//			base.GetComponent<Graphic> ().SetAllDirty ();
	//		}
		}
	}
		
}