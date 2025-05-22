using UnityEngine;

namespace Plugins.Modern.UI.Api {
	public interface IModernUIService {
		void SetupForm<TArg> (GameObject form, Canvas canvas, TArg item = default);

		void RemoveForm (GameObject form, Canvas canvas);
	}
}
