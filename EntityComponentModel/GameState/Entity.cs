using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using EntityComponentModel.ComponentDefinitions;

namespace EntityComponentModel {
	class Entity {
		public Entity() {
			this.id = new Guid();
			this.componentList = new List<Component>();
		}

		public Entity(List<Component> components) {
			this.id = new Guid();
			this.componentList = components;
		}

		public Guid id;
		public List<Component> componentList { get; private set; }
		
	}
}
