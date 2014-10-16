using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    abstract class DynamicTimeout {
        protected double timer = .0f, interval;
        protected bool repeat = false, ended = false;

        public DynamicTimeout(double interval) {
            setInterval(interval);
        }

        public void setInterval(double interval) {
            this.interval = interval;
        }

        public double getInterval() {
            return interval;
        }

        public void update(GameTime gameTime) {
            if (!repeat && ended)
                return;
            ended = false;

            timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer >= interval) {
                timer = .0f;
                timeOut();
                ended = true;
            }
        }

        public void run() {
            timer = .0f;
            ended = false;
        }

        public abstract void timeOut();
    }
}