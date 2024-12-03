using Plugins.Modern.DI.App;
using Plugins.Modern.DI.Units;
using Plugins.Modern.UI.App;
using UnityEngine;

namespace Plugins.Modern.UI.Units {
	[CreateAssetMenu(menuName = "Infinity/Units/UIUnit", fileName = "UIUnit")]
	public class InfinityUIUnit : ModernAppUnit {
		public override void SetupUnit (ModernComponentsRegistry componentsRegistry) {
			componentsRegistry.Instantiate<ModernUIService>();
		}
	}
}
