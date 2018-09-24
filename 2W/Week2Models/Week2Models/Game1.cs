using Microsoft.Xna.Framework;
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

        Model model;

        Matrix world;
        Matrix[] bonesTransforms;

        Matrix view;
        Matrix projection;


        //Indexed
        short[] indices;
        VertexBuffer vbuffer;
        IndexBuffer ibuffer;

        //Effect (World)
        BasicEffect effect;

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
                new Vector3(0, 0, 75),
                new Vector3(0, 0, -1),
                Vector3.Up);
            
        }


        protected override void LoadContent()
        {
            //Load Model with the CP
            model = Content.Load<Model>("Models\\earth");

            //Copy bone transforms
            bonesTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(bonesTransforms);

            world = Matrix.Identity;
        }
        

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach(ModelMesh mesh in model.Meshes)
            {
                foreach(BasicEffect effect in mesh.Effects)
                {
                    effect.View = view;
                    effect.Projection = projection;

                    effect.World = bonesTransforms[mesh.ParentBone.Index] * world;

                    //effect.PreferPerPixelLighting = true;
                    //effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
