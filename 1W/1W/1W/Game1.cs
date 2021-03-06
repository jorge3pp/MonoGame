﻿using Microsoft.Xna.Framework;
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

        //Texture Vertices
        VertexPositionTexture[] textureVertices;
        Texture2D uvTexture;

        //Normal Vertices
        VertexPositionNormalTexture[] normalVertices;

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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //El primer vector acerca o nos aleja del objeto. El segundo no estoy muy seguro aun.
            view = Matrix.CreateLookAt(new Vector3(0, 0, 5), new Vector3(0, 0, -1), Vector3.Up);
            //El primer valor aleja o acerca el objeto.
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30), GraphicsDevice.DisplayMode.AspectRatio, 0.1f, 1000.0f);

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
            //setUpColorVertices();
            //setUpTexturedVertices();
            //setUpNormalVertices();
            //setUpIndexedColorVertices();
            //setUpPyramid();
            setUpCube();
        }

        void setUpNormalVertices()
        {
            normalVertices = new VertexPositionNormalTexture[6];

            //BL- BOTTOM LEFT
            normalVertices[0] = new VertexPositionNormalTexture(new Vector3(-1,-1,0), Vector3.Forward, new Vector2(0, 1));
            //TL- TOP LEFT
            normalVertices[1] = new VertexPositionNormalTexture(new Vector3(-1, 1, 0), Vector3.Forward, new Vector2(0, 0));
            //BR- BOTTOM RIGHT
            normalVertices[2] = new VertexPositionNormalTexture(new Vector3(1, -1, 0), Vector3.Forward, new Vector2(1, 1));

            //TR
            normalVertices[3] = new VertexPositionNormalTexture(new Vector3(1, 1, 0), Vector3.Forward, new Vector2(1, 0));
            //BR
            normalVertices[4] = new VertexPositionNormalTexture(new Vector3(1, -1, 0), Vector3.Forward, new Vector2(1, 1));
            //TL
            normalVertices[5] = new VertexPositionNormalTexture(new Vector3(-1, 1, 0), Vector3.Forward, new Vector2(0, 0));

            effect = new BasicEffect(GraphicsDevice);
            effect.TextureEnabled = true;
            effect.Texture = Content.Load<Texture2D>("uv_texture");
            effect.EnableDefaultLighting();
            effect.PreferPerPixelLighting = true;

            effect.DirectionalLight0.Enabled = true;
            effect.DirectionalLight1.Enabled = true;
            effect.DirectionalLight2.Enabled = false;

            effect.DirectionalLight0.Direction = Vector3.Backward;
            //effect.DirectionalLight0.DiffuseColor = Color.Blue.ToVector3();
            effect.DirectionalLight1.Direction = Vector3.Left;
            effect.DirectionalLight1.DiffuseColor = Color.Green.ToVector3();
        }

        void setUpTexturedVertices()
        {
            textureVertices = new VertexPositionTexture[6];

            //BL- BOTTOM LEFT
            textureVertices[0] = new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(0, 1));
            //TL- TOP LEFT
            textureVertices[1] = new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0));
            //BR- BOTTOM RIGHT
            textureVertices[2] = new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, 1));

            //TR
            textureVertices[3] = new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 0));         
            //BR
            textureVertices[4] = new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, 1));
            //TL
            textureVertices[5] = new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0));

            effect = new BasicEffect(GraphicsDevice);
            effect.TextureEnabled = true;
            effect.Texture = Content.Load<Texture2D>("uv_texture");
        }

        void setUpColorVertices()
        {
            colorVertices = new VertexPositionColor[6];

            //BL- BOTTOM LEFT
            colorVertices[0] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Red);

            //TL- TOP LEFT
            colorVertices[1] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Green);

            //BR- BOTTOM RIGHT
            colorVertices[2] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Blue);


            colorVertices[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);


            colorVertices[4] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Yellow);


            colorVertices[5] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Purple);

            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;
        }

        void setUpIndexedColorVertices()
        {
            colorVertices = new VertexPositionColor[4];

            //BL- BOTTOM LEFT
            colorVertices[0] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Red);

            //TL- TOP LEFT
            colorVertices[1] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Green);

            //BR- BOTTOM RIGHT
            colorVertices[2] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Blue);

            //TR
            colorVertices[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);

            indices = new short[6];

            //Triangle One
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;

            //Triangle Two
            indices[3] = 2;
            indices[4] = 1;
            indices[5] = 3;


            vbuffer = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, colorVertices.Length, BufferUsage.WriteOnly);
            vbuffer.SetData<VertexPositionColor>(colorVertices);

            ibuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indices.Length, BufferUsage.WriteOnly);
            ibuffer.SetData<short>(indices);


            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;
        }

        void setUpPyramid()
        {
            colorVertices = new VertexPositionColor[4];

            //Centre
            colorVertices[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);

            //Base1
            colorVertices[1] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Green);

            //B2
            colorVertices[2] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);

            //B3
            colorVertices[3] = new VertexPositionColor(new Vector3(0, -1, 1), Color.Black);

            indices = new short[9];

            //Triangle One
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;

            //Triangle Two
            indices[3] = 0;
            indices[4] = 2;
            indices[5] = 3;

            //Triangle Three
            indices[6] = 0;
            indices[7] = 3;
            indices[8] = 1;


            vbuffer = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, colorVertices.Length, BufferUsage.WriteOnly);
            vbuffer.SetData<VertexPositionColor>(colorVertices);

            ibuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indices.Length, BufferUsage.WriteOnly);
            ibuffer.SetData<short>(indices);

            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;

            effect.World *= Matrix.CreateRotationX(MathHelper.ToRadians(90));

            /*See trough the model and show all vertices
            RasterizerState state = new RasterizerState();
            state.FillMode = FillMode.WireFrame;
            state.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = state;
        */}

        void setUpCube()
        {
            colorVertices = new VertexPositionColor[8];

            //1Top antihorario
            colorVertices[0] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);

            //2T AH
            colorVertices[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);

            //3T AH
            colorVertices[2] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);

            //4T AH
            colorVertices[3] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Black);


            //1Bottom antihorario
            colorVertices[4] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Pink);

            //2B AH
            colorVertices[5] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);

            //3B AH
            colorVertices[6] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);

            //4B AH
            colorVertices[7] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Black);

            indices = new short[36];

            //Triangle OneF1
            indices[0] = 0;
            indices[1] = 5;
            indices[2] = 1;

            //Triangle TwoF1
            indices[3] = 0;
            indices[4] = 4;
            indices[5] = 5;

            //Triangle ThreeF2
            indices[6] = 1;
            indices[7] = 5;
            indices[8] = 2;


            //Triangle FourF2
            indices[9] = 2;
            indices[10] = 5;
            indices[11] = 6;

            //Triangle FiveF3
            indices[12] = 2;
            indices[13] = 7;
            indices[14] = 3;
            
            //Triangle SixF3
            indices[15] = 2;
            indices[16] = 6;
            indices[17] = 7;

            //Triangle SevenF4
            indices[18] = 3;
            indices[19] = 7;
            indices[20] = 0;

            //Triangle EightF4
            indices[21] = 0;
            indices[22] = 7;
            indices[23] = 4;

            //Triangle NineF5
            indices[24] = 0;
            indices[25] = 1;
            indices[26] = 2;

            //Triangle TenF5
            indices[27] = 0;
            indices[28] = 2;
            indices[29] = 3;

            //Triangle ElevenF6
            indices[30] = 5;
            indices[31] = 7;
            indices[32] = 6;

            //Triangle TwelveF6
            indices[33] = 4;
            indices[34] = 7;
            indices[35] = 5;

            vbuffer = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, colorVertices.Length, BufferUsage.WriteOnly);
            vbuffer.SetData<VertexPositionColor>(colorVertices);

            ibuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, indices.Length, BufferUsage.WriteOnly);
            ibuffer.SetData<short>(indices);

            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = false;


            /*
            //See trough the model and show all vertices
            RasterizerState state = new RasterizerState();
            state.FillMode = FillMode.WireFrame;
            state.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = state;
            */
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
            

            //world *= Matrix.CreateRotationZ(MathHelper.ToRadians(1f));
            //world *= Matrix.CreateRotationY(MathHelper.ToRadians(0.5f));
            //world *= Matrix.CreateRotationX(MathHelper.ToRadians(0.1f));

            base.Update(gameTime);
        }
        /*
        //ISRT - Identity, Scaled, Rotation, Translation
        Matrix world = 
            Matrix.Identity *
            Matrix.CreateScale(2) *
            Matrix.CreateRotationX(MathHelper.ToRadians(45)) *
            Matrix.CreateRotationY(MathHelper.ToRadians(45)) *
            Matrix.CreateRotationZ(MathHelper.ToRadians(30)) *
            Matrix.CreateTranslation(new Vector3(0, 0, -10));*/
        Matrix world = Matrix.Identity;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            effect.View = view;
            effect.Projection = projection;
            effect.World = world;


            //Si aumentamos el valor, aumenta la velocidad a la que rota el objeto.
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(1f));
            world *= Matrix.CreateRotationX(MathHelper.ToRadians(2f));
            world *= Matrix.CreateRotationZ(MathHelper.ToRadians(0.5f));
            


            //drawColorVertices();
            //drawTexturedVertices();
            //drawNormalVertices();
            //drawIndexedColorVertices();
            drawPyramid();

            base.Draw(gameTime);
        }

        private void drawColorVertices(){


            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, colorVertices, 0, colorVertices.Length / 3);
            }
        }

        private void drawTexturedVertices()
        {

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, textureVertices, 0, textureVertices.Length / 3);
            }
        }

        private void drawNormalVertices()
        {

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, normalVertices, 0, normalVertices.Length / 3);
            }
        }

        private void drawIndexedColorVertices()
        {
            GraphicsDevice.SetVertexBuffer(vbuffer);
            GraphicsDevice.Indices = ibuffer;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList, colorVertices, 0, colorVertices.Length,
                    indices, 0, indices.Length / 3);
            }
        }
        private void drawPyramid()
        {
            GraphicsDevice.SetVertexBuffer(vbuffer);
            GraphicsDevice.Indices = ibuffer;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList, colorVertices, 0, colorVertices.Length,
                    indices, 0, indices.Length / 3);
            }
        }
        
    }
}
