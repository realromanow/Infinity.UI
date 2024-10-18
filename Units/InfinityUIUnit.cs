using Plugins.Infinity.DI.App;
using Plugins.Infinity.DI.Units;
using Plugins.Infinity.UI.App;
using UnityEngine;

namespace Plugins.Infinity.UI.Units {
	[CreateAssetMenu(menuName = "Infinity/Units/UIUnit", fileName = "UIUnit")]
	public class InfinityUIUnit : AppUnit {
		public override void SetupUnit (AppComponentsRegistry componentsRegistry) {
			componentsRegistry.Instantiate<InfinityUIService>();
		}
	}
}
