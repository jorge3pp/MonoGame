﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week2Models
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        BasicModel earthModel;
        BasicModel shipModel;

        Matrix view;
        Matrix projection;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 16);

            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            UpdateView();

            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(90),
                GraphicsDevice.DisplayMode.AspectRatio,
                0.1f,
                100f);


            base.Initialize();
        }

        void UpdateView()
        {
            view = Matrix.CreateLookAt(
                new Vector3(0, 0, 50),
                new Vector3(0, 0, -1),
                Vector3.Up);
            
        }


        protected override void LoadContent()
        {
            shipModel = new BasicModel("ship", new Vector3(40, 0, 0), Vector3.Zero, new Vector3(0.4f, 0.4f, 0.4f));
            earthModel = new BasicModel("earth", Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.6f));
            earthModel.LoadContent(Content);
            shipModel.LoadContent(Content);
        }
        

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdateView();
            shipModel.world *= Matrix.CreateRotationZ(MathHelper.ToRadians(0.2f));
            shipModel.world *= Matrix.CreateRotationY(MathHelper.ToRadians(1f));

            earthModel.world *= Matrix.CreateRotationY(MathHelper.ToRadians(-0.2f));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            earthModel.Draw(view, projection);
            shipModel.Draw(view, projection);

            base.Draw(gameTime);
        }
    }
}
