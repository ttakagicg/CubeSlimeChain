using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


namespace Utage
{

	/// <summary>
	/// アウトラインコンポーネントをリッチに
	/// </summary>
	[AddComponentMenu("Utage/Lib/UI/RichOutline")]
	public class UguiRichOutline : Outline
	{
		public int copyCount = 16;
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!IsActive())
				return;

			var verts = new List<UIVertex>();
			vh.GetUIVertexStream(verts);

			ModifyVerticesSub(verts);

			vh.Clear();
			vh.AddUIVertexTriangleStream(verts);
		}

		void ModifyVerticesSub(List<UIVertex> verts)
		{
			var start = 0;
			var end = verts.Count;

			for (int i = 0; i < copyCount; ++i)
			{
				float x = Mathf.Sin(Mathf.PI * 2 * i / copyCount) * effectDistance.x;
				float y = Mathf.Cos(Mathf.PI * 2 * i / copyCount) * effectDistance.y;
				ApplyShadow(verts, effectColor, start, verts.Count, x, y);
				start = end;
				end = verts.Count;
			}
		}
	}
}