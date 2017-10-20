using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Movimiento_en_Equis
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D balon;
        Vector2 PosicionBalon;
        byte r, g, b;
        bool Direccion_Horizontal;
        bool Direccion_Vertical;
        bool Ida;
        int cont;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            r = 0;
            g = 0;
            b = 0;
            cont = 0;
            Direccion_Horizontal = true;
            Direccion_Vertical = true;
            Ida = true;
            PosicionBalon = new Vector2(0, 0);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            balon = Content.Load<Texture2D>("Baloncito");
            // TODO: use this.Content to load your game content here
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

            //Movemos Horizontal

            if (PosicionBalon.X >= 700)
            {
                Direccion_Horizontal = false;
            }
            else if (PosicionBalon.X <= 0)
            {
                Direccion_Horizontal = true;
            }
            if (PosicionBalon.Y >= 380)
            {
                Direccion_Vertical = false;
            }
            else if (PosicionBalon.Y <= 0)
            {
                Direccion_Vertical = true;
            }

            if (cont == 3)
            {
                Ida = false;
            }
            if(cont== 0)
            {
                Ida = true;
            }


            // ------------------------------------------------------//
            if (Ida == true)
            {

                if (Direccion_Vertical == true && Direccion_Horizontal == true)
                {
                    PosicionBalon.X += 18.5f;
                    PosicionBalon.Y += 10;
                }
                else if (Direccion_Vertical == false && Direccion_Horizontal == false)
                {
                    PosicionBalon.X += 0;
                    PosicionBalon.Y -= 10;
                }
                else if(Direccion_Vertical == true && Direccion_Horizontal== false)
                {
                    PosicionBalon.X -= 18.5f;
                    PosicionBalon.Y += 10f;
                }

                //Manejo de contadores
                if (PosicionBalon.Y == 380 && PosicionBalon.X == 700)
                {
                    cont += 1;
                }
                if (PosicionBalon.Y == 0 && PosicionBalon.X == 700)
                {
                    cont += 1;
                }
                if (PosicionBalon.Y == 380 && PosicionBalon.X == 0)
                {
                    cont += 1;
                }
            }
            
            if (Ida == false)
            {
                if(Direccion_Vertical == false && Direccion_Horizontal == true)
                {
                    PosicionBalon.X += 18.5f;
                    PosicionBalon.Y -= 10;
                }
                else if (Direccion_Vertical == true && Direccion_Horizontal == false)
                {
                    PosicionBalon.X += 0;
                    PosicionBalon.Y += 10;
                }
                else if (Direccion_Vertical == false && Direccion_Horizontal == false)
                {
                    PosicionBalon.X -= 18.5f;
                    PosicionBalon.Y -= 10f;
                }

                if (PosicionBalon.Y == 0 && PosicionBalon.X == 700)
                {
                    cont -= 1;
                }
                if (PosicionBalon.Y == 390 && PosicionBalon.X == 700)
                {
                    cont -= 1;
                }
                if (PosicionBalon.Y == 0 && PosicionBalon.X == 0)
                {
                    cont -= 1;
                }

            }


            

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color miColor = new Color(r, g, b);
            GraphicsDevice.Clear(miColor);
            spriteBatch.Begin();
            spriteBatch.Draw(balon, PosicionBalon, Color.White);
            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
