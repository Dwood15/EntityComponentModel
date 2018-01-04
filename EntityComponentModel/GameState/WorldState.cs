using System;
using System.Collections.Generic;
using EntityComponentModel.ComponentDefinitions;
using Microsoft.Xna.Framework.Content;
namespace EntityComponentModel {
	class WorldState {
		protected static ContentManager Content;
		protected List<Component> allComponents;
		protected SortedSet<Type> recognizedComponentTypes;
		protected List<Entity> entities;

		public WorldState(ContentManager content) {
			this.allComponents = new List<Component>();
			this.recognizedComponentTypes = new SortedSet<Type>();
			Content = content;
		}

		public void RegisterComponentType(Component typeToAdd) {
			recognizedComponentTypes.Add(typeToAdd.GetType());
		}

		public void CreateEntity(List<Component> components) {
			allComponents.AddRange(components.ToArray());
			entities.Add(new Entity(components));
		}

		public void AddComponentToEntity(Component toAdd, Guid entityId) {
			this.RegisterComponentType(toAdd);
			Entity entity = this.entities.Find(x => x.id == entityId);
			entity.componentList.Add(toAdd);
			this.allComponents.Add(toAdd);
		}
	}
}
