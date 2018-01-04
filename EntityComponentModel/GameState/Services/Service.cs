using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityComponentModel.ComponentDefinitions;
namespace EntityComponentModel.Services {
	public abstract class Service {
		/// <summary>
		/// The primary Type this Service cares about. 
		/// </summary>
		public Type interestedType { get; private set; }
		/// <summary>
		/// The components which this service cares about.
		/// </summary>
		private ArraySegment<Component> interestedComponents { get; set; }
		public ArraySegment<Component> GetArraySegment(Component[] components) {

			if (components == null)
				throw new Exception("Unable to get a segment - No components!");

			bool first = false;
			int offset = 0;
			int count = 0;
			foreach (var comp in components) {
				if (comp.GetType() != interestedType && first)
					break;
				else if (comp.GetType() == interestedType) {
					if (!first)
						first = true;

					count++;
				} else if (!first)
					offset++;
			}
			if (first && (offset + count) < components.Length) {
				interestedComponents = new ArraySegment<Component>(components, offset, count);
				return interestedComponents;
			}

			return new ArraySegment<Component>();
		}
		/// <summary>
		/// Enumersates interestedComponents and operates on each one which this service cares about.
		/// </summary>
		public abstract void Run();
	}
}
