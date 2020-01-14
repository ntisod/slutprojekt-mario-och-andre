﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace space1.Sprites
{
    // hanterar fienderna, hur snabbt de skjuter och hur ofta de ska spawna
  public class Enemy : Ship
  {
    private float _timer;

    public float ShootingTimer = 1.75f;

    public Enemy(Texture2D texture)
      : base(texture)
    {
      Speed = 2f;
    }

    public override void Update(GameTime gameTime)
    {
      _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

      if (_timer >= ShootingTimer)
      {
        Shoot(-5f);
        _timer = 0;
      }

      Position += new Vector2(-Speed, 0);

      // if the enemy is off the left side of the screen
      if (Position.X < -_texture.Width)
        IsRemoved = true;
    }

    public override void OnCollide(Sprite sprite)
    {
      // If we crash into a player that is still alive
      if (sprite is Player && !((Player)sprite).IsDead)
      {
        ((Player)sprite).Score.Value++;

        // We want to remove the ship completely
        IsRemoved = true;
      }

      // If we hit a bullet that belongs to a player      
      if (sprite is Bullet && ((Bullet)sprite).Parent is Player)
      {
        Health--;

        if (Health <= 0)
        {
          IsRemoved = true;
          ((Player)sprite.Parent).Score.Value++;
        }
      }
    }
  }
}
