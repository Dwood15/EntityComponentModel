using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EntityComponentModel {
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D textureBall;
		static WorldState world;

		public Game1() {
			world = new WorldState(new Microsoft.Xna.Framework.Content.ContentManager(null));
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			textureBall = Content.Load<Texture2D>("ball");
		}

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();

			var spritePosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
			spriteBatch.Draw(textureBall, spritePosition, null, Color.White, 0f, 
				new Vector2(textureBall.Width / 2, textureBall.Height / 2), Vector2.One, SpriteEffects.None, 0f);

			spriteBatch.End();

			base.Draw(gameTime);
			base.Update(gameTime);
		}

		private void Draw(GameTime gameTime) { }
	}
}
