using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using space1.Sprites;
using space1.States;

namespace space1
{
    // Mario och André's SpaceShooter Spel 2019-12-13

  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public static Random Random;

    public static int ScreenWidth = 1280;
    public static int ScreenHeight = 720;

    private State _currentState;
    private State _nextState;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

   // Initialize() gör så att man kan initiera olika objekts egenskaper som till exemepel spelarens och fienders positioner
    // och även andra egenskaper som liv 

    protected override void Initialize()
    {
      Random = new Random();

      graphics.PreferredBackBufferWidth = ScreenWidth;
      graphics.PreferredBackBufferHeight = ScreenHeight;
      graphics.ApplyChanges();

      IsMouseVisible = true;

      base.Initialize();
    }

        /// LoadContent kallas för att ladda in all grafik och sprites

    protected override void LoadContent()
    {
      // skapar ny spritebatch som skriver ut grafik

      spriteBatch = new SpriteBatch(GraphicsDevice);

      _currentState = new MenuState(this, Content);
      _currentState.LoadContent();
      _nextState = null;
    }

      // här så kallas alla objekt och laddas ur för de kan ta upp onödig plats i minnet

    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

     ///  gör så att spelet kör logiken som uppdaterar spelet, kollar för kollision, tangent tryck, och ljud spelning

    protected override void Update(GameTime gameTime)
    {
      if(_nextState != null)
      {
        _currentState = _nextState;
        _currentState.LoadContent();

        _nextState = null;
      }

      _currentState.Update(gameTime);

      _currentState.PostUpdate(gameTime);

      base.Update(gameTime);
    }

    public void ChangeState(State state)
    {
      _nextState = state;
    }

      // denna kallas när spelar ska ritas ut

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(new Color(55, 55, 55));

      _currentState.Draw(gameTime, spriteBatch);

      base.Draw(gameTime);
    }
  }
}
