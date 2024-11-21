using UnityEngine;

namespace Plugins.Modern.UI.Api {
	public interface IModernUIService {
		void SetupInterfaceVariant<TArg> (GameObject interfaceVariant, Canvas canvas, TArg item = default);

		void RemoveInterfaceVariant (GameObject interfaceVariant, Canvas canvas);

		void RemoveAllExceptVariant (GameObject interfaceVariant, Canvas canvas);

		void RemoveInterfaceVariantFromId (string id);
	}
}
