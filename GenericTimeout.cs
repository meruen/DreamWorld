using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamWorld {
    class GenericTimeout {
        protected double timer = .0f, interval;
        protected bool timeOuted = false;
        public static double DEFAULT_INTERVAL_VALUE = 20.0f;

        public GenericTimeout() {
            interval = GenericTimeout.DEFAULT_INTERVAL_VALUE;
        }

        public GenericTimeout(double interval) {
            setInterval(interval);
        }

        public void setInterval(double interval) {
            this.interval = interval;
        }

        public double getInterval() {
            return interval;
        }

        public void update(GameTime gameTime) {
            if (!timeOuted) {
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer >= interval) {
                    timer = .0f;
                    timeOuted = true;
                }
            }
        }

        public bool isTimeOuted() {
            if (timeOuted) {
                timeOuted = false;
                timer = .0f;
                return true;
            }

            return false;
        }
    }
}
