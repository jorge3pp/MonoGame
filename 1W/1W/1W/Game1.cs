using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _1W
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Camera
        Matrix view;
        Matrix projection;

        //Color Vertices
        VertexPositionColor[] colorVertices;

        //Effect (World)
        BasicEffect effect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            IsMouseVisible = true;
<<<<<<< HEAD
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0,16);
=======
            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 16);
>>>>>>> parent of b05807a... Haciendo ej2

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
<<<<<<< HEAD
            view = Matrix.CreateLookAt(new Vector3(0, 0, 5), new Vector3(0, 0, -1), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.DisplayMode.AspectRatio, 0.1f, 1000.0f);
=======

            //El primer vector acerca o nos aleja del objeto. El segundo no estoy muy seguro aun.
            view = Matrix.CreateLookAt(new Vector3(0, 0, 5), new Vector3(0, 0, -1), Vector3.Up);
            //El primer valor aleja o acerca el objeto.
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30), GraphicsDevice.DisplayMode.AspectRatio, 0.1f, 1000.0f);
>>>>>>> parent of b05807a... Haciendo ej2

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            /*// Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            */
            setUpColorVertices();
        }

        void setUpColorVertices()
        {
<<<<<<< HEAD
            colorVertices = new VertexPositionColor[6];
=======
            colorVertices = new VertexPositionColor[8];
>>>>>>> parent of b05807a... Haciendo ej2

            //BL- BOTTOM LEFT
            colorVertices[0] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Red);

            //TL- TOP LEFT
            colorVertices[1] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Green);

            //BR- BOTTOM RIGHT
            colorVertices[2] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Blue);

<<<<<<< HEAD

            colorVertices[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);


            colorVertices[4] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Yellow);


            colorVertices[5] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Purple);
=======
            //TR- TOP RIGHT
            colorVertices[7] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Orange);

            //CENTER
            colorVertices[3] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Pink);


            colorVertices[4] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);


            colorVertices[5] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Yellow);


            colorVertices[6] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Purple);
>>>>>>> parent of b05807a... Haciendo ej2

            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            effect.View = view;
            effect.Projection = projection;
<<<<<<< HEAD
            effect.World *= Matrix.CreateRotationY(MathHelper.ToRadians(0.5f));
=======
            
            //Si aumentamos el valor, aumenta la velocidad a la que rota el objeto.
            effect.World *= Matrix.CreateRotationY(MathHelper.ToRadians(1f));
>>>>>>> parent of b05807a... Haciendo ej2

            //RasterizerState state = new RasterizerState();
            //GraphicsDevice.RasterizerState = state;


            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, colorVertices, 0, colorVertices.Length / 3);
            }

            base.Draw(gameTime);
        }
    }
}
