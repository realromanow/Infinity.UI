using UnityEngine;

namespace Plugins.Infinity.UI.Api {
	public interface IInfinityUIService {
		void SetupInterfaceVariant<TArg> (GameObject interfaceVariant, Canvas canvas, TArg item = default);

		void RemoveInterfaceVariant (GameObject interfaceVariant, Canvas canvas);

		void RemoveAllExceptVariant (GameObject interfaceVariant, Canvas canvas);

		void RemoveInterfaceVariantFromId (string id);
	}
}
