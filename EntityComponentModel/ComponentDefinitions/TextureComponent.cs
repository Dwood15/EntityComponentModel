using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntityComponentModel.ComponentDefinitions {
	class TextureComponent : Component{
		public string textureName;
		public Texture2D texture;
	}
}
