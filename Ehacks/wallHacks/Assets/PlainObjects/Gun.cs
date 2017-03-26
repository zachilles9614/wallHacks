using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.PlainObjects
{
    /// <summary>
    /// A plain old object encapsulate all the data related to a gun
    /// </summary>
    public class Gun
    {
        /// <summary>
        /// The different types of bubbles that have different radii 
        /// </summary>
        public enum BubbleType
        {
            Green,
            Yellow,
            Red,
            Maroon,
            Explode
        }

        private int _counter = 0;
        private const int DamageInterval = 5;
        private const int BubbleInterval = 10;
        private const int PlayerPenalty = -50;
        public BubbleType Bubble { get; set; }

        /// <summary>
        /// the amount of dmanage per hit of the gun
        /// </summary>
        public int DamagePerHit { get; set; }

        /// <summary>
        /// The interval between bullets for the gun
        /// </summary>
        public TimeSpan RateOfFire { get; set; }

        /// <summary>
        /// The amount of bullets that leave the gun per each shot
        /// </summary>
        public readonly int bulletSpray;

        /// <summary>
        /// the tag for the image
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The game object that corresponds to a UI image for the gun 
        /// preview 
        /// </summary>
        public GameObject GunImage { get; set; }

        /// <summary>
        /// The sprite for the bullet that exits the gun 
        /// </summary>
        public GameObject BulletType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Ammo { get; set; }

        public Gun( bool isShotgun = false )
        {
            if ( isShotgun )
            {
                this.bulletSpray = 6;
            }
        }

        /// <summary>
        /// Return the finish spread of the shot just took 
        /// </summary>
        /// <returns></returns>
        public int[] Spread(int initx, int inity)
        {
            int[] finishPoints = new int[6];
            int final = 5;
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    finishPoints[i] = final;
                } else if (i < 3)
                {
                    finishPoints[i] = final -= 1;
                } else if (i == 3)
                {
                    finishPoints[i] = final;
                }
                else
                {
                    finishPoints[i] = final += 1;
                }

            }
            return finishPoints;
        }


        public int BubbleDamage()
        {
            int damage = 0;
            int i;
            if ( _counter < BubbleInterval )
            {
                this.Bubble = BubbleType.Green;
            }
            else if (_counter <= BubbleInterval * 2)
            {
                this.Bubble = BubbleType.Yellow;
            }
            else if ( _counter <= BubbleInterval * 3 )
            {
                this.Bubble = BubbleType.Red;
            }
            else if (_counter <= BubbleInterval * 4)
            {
                this.Bubble = BubbleType.Maroon;
            }
            else
            {
                this.Bubble = BubbleType.Explode;
                return PlayerPenalty;
            }
            i = _counter / BubbleInterval;
            damage = (i + 1) * DamageInterval;
            _counter++;
            return damage;
        }
    }
}
