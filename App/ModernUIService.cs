using Plugins.Modern.DI.Binding;
using Plugins.Modern.UI.Api;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Plugins.Modern.UI.App {
	public class ModernUIService : IModernUIService {
		private readonly Dictionary<Canvas, List<GameObject>> _interfaceVariants = new();

		public void SetupInterfaceVariant<TArg> (GameObject interfaceVariant, Canvas canvas, TArg item = default) {
			if (!_interfaceVariants.ContainsKey(canvas)) _interfaceVariants.Add(canvas, new List<GameObject>());

			if (_interfaceVariants[canvas].Contains(interfaceVariant)) {
				Debug.LogError($"Instance of {interfaceVariant.name} already exists on {canvas.name}");
				return;
			}

			var instance = Object.Instantiate(interfaceVariant, canvas.transform);
			_interfaceVariants[canvas].Add(instance);

			if (item != null) instance.GetComponentInChildren<ItemBinding<TArg>>().SetItem(item, interfaceVariant.name + "(Clone)");
		}

		public void RemoveInterfaceVariant (GameObject interfaceVariant, Canvas canvas) {
			if (!TryGetInterfaceList(canvas, out var variantsList)) return;

			if (variantsList.All(x => x.name != interfaceVariant.name + "(Clone)")) {
				Debug.Log($"Instance of {interfaceVariant.name} not found on {canvas.name}");
				return;
			}

			var instance = _interfaceVariants[canvas].Single(x => x.name == interfaceVariant.name + "(Clone)");
			_interfaceVariants[canvas].Remove(instance);

			Object.Destroy(instance);
		}

		public void RemoveAllExceptVariant (GameObject interfaceVariant, Canvas canvas) {
			if (!TryGetInterfaceList(canvas, out var variantsList)) return;

			if (variantsList.All(x => x.name != interfaceVariant.name + "(Clone)")) {
				Debug.Log($"Instance of {interfaceVariant.name} not found on {canvas.name}");
				return;
			}

			variantsList.RemoveAll(x => {
				if (interfaceVariant.name + "(Clone)" == x.name) return false;

				Object.Destroy(x);
				return true;
			});
		}

		public void RemoveInterfaceVariantFromId (string id) {
			var targetVariables = _interfaceVariants.Where(keyValuePair => {
				return keyValuePair.Value.Any(x => x.name == id);
			}).Select(keyValuePair => keyValuePair.Value);

			foreach (var variable in targetVariables) {
				var targetVariant = variable.Single(x => x.name == id);
				Object.Destroy(targetVariant);
				
				variable.Remove(targetVariant);
			}
		}

		private bool TryGetInterfaceList (Canvas canvas, out List<GameObject> variantsList) {
			return _interfaceVariants.TryGetValue(canvas, out variantsList);
		}
	}
}
