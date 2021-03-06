﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDLIB
{
    public class LED3DEphemeralDot : LED3DObject
    {
        double x;
        double y;
        double z;
        private TimeSpan lastUpdateAt;

        public LED3DEphemeralDot(double x, double y, double z, RGB color)
            : this(x, y, z, color, TimeSpan.Zero)
        {

        }

        public LED3DEphemeralDot(double x, double y, double z, RGB color, TimeSpan lifeTime)
            :base(color, lifeTime)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.lastUpdateAt = this.GetElapsedAt();
        }

        public override bool IsExpired()
        {
            return this.Color.isBlack();
        }

        public override void Draw(ILED3DCanvas canvas)
        {
            var isNeedUpdate = false;
            if (this.GetElapsedAt().Subtract(this.lastUpdateAt).Milliseconds > 100)
            {
                this.lastUpdateAt = this.GetElapsedAt();
                isNeedUpdate = true;
            }

            canvas.SetLed(this.x, this.y, this.z, this.Color);
            this.Color -= 10;
        }
    }
}

