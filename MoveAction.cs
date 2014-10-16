using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    /// <summary>
    /// This class make it easy the pre-routed movement of BaseObject.
    /// </summary>
    class MoveAction : GenericAction {
        protected BaseObject baseObject;
        protected GenericTimeout timeOut;
        protected Vector2 destiny;
        protected Vector2 increment;
        protected bool xSatisfied = false, ySatisfied = false;

        /// <summary>
        /// Set the destiny for the BaseObject.
        /// </summary>
        /// <param name="destiny">Destiny coordinates.</param>
        public void setDestiny(Vector2 destiny) {
            this.destiny = destiny;
        }

        /// <summary>
        /// Get the destiny for the BaseObject.
        /// </summary>
        /// <returns>Destiny Coordinates.</returns>
        public Vector2 getDestiny() {
            return destiny;
        }

        /// <summary>
        /// Set a relative Destiny for the BaseObject. The relative destiny just add the value of <c>destiny</c> like a increment.
        /// </summary>
        /// <param name="destiny">Increment based on X, Y.</param>
        public void setRelativeDestiny(Vector2 destiny) {
            this.destiny += destiny;
        }

        /// <summary>
        /// Set the increment for the movement.
        /// </summary>
        /// <param name="increment">Increment based on X, Y.</param>
        public void setIncrement(Vector2 increment) {
            this.increment = increment;
        }

        /// <summary>
        /// Get the increment of the MoveAction.
        /// </summary>
        /// <returns>Increment of the MoveAction.</returns>
        public Vector2 getIncrement() {
            return increment;
        }

        /// <summary>
        /// Set the interval for the TimeOut that do the timeloop for the MoveAction.
        /// </summary>
        /// <param name="interval">Interval speed for the TimeOut.</param>
        public void setInterval(double interval) {
            timeOut.setInterval(interval);
        }

        /// <summary>
        /// Basic Constructor.
        /// </summary>
        public MoveAction() {
        }

        /// <summary>
        /// Main Constructor.
        /// </summary>
        /// <param name="parent">BaseObject that will be moved.</param>
        /// <param name="destiny">Destiny of the movement.</param>
        /// <param name="increment">Increment based on X, Y.</param>
        /// <param name="interval">Interval used on TimeOut that do the timeloop for the MoveAction.</param>
        public MoveAction(BaseObject parent, Vector2 destiny, Vector2 increment, double interval) {
            initialize(parent, destiny, increment, interval);
        }

        /// <summary>
        /// Initialize function. Does the same thing of the main constructor.
        /// </summary>
        /// <param name="parent">BaseObject that will be moved.</param>
        /// <param name="destiny">Destiny of the movement.</param>
        /// <param name="increment">Increment based on X, Y.</param>
        /// <param name="interval">Interval used on TimeOut that do the timeloop for the MoveAction.</param>
        public void initialize(BaseObject parent, Vector2 destiny, Vector2 increment, double interval) {
            base.initialize(parent);
            baseObject = parent;
            timeOut = new GenericTimeout(interval);
            setDestiny(destiny);
            setIncrement(increment);
            start();
        }

        /// <summary>
        /// Start the MoveAction.
        /// </summary>
        public override void start() {
            base.start();
            xSatisfied = ySatisfied = false;
        }

        /// <summary>
        /// Updates the BaseObject by the data of the MoveAction.
        /// </summary>
        /// <param name="gameTime">Basic GameTime parameter.</param>
        public override void update(GameTime gameTime) {
            if (!isFinished() && isRunning()) {
                timeOut.update(gameTime);
                if (timeOut.isTimeOuted())
                    baseObject.incrementLocation(increment);

                if (increment.X == 0)
                    xSatisfied = true;
                if (increment.Y == 0)
                    ySatisfied = true;

                if (increment.X != 0)
                    if (increment.X > 0) {
                        if (baseObject.getX() >= destiny.X)
                            xSatisfied = true;
                    } else if (baseObject.getX() <= destiny.X)
                        xSatisfied = true;

                if (increment.Y != 0)
                    if (increment.Y > 0) {
                        if (baseObject.getY() >= destiny.Y)
                            ySatisfied = true;
                    } else if (baseObject.getY() <= destiny.Y)
                        ySatisfied = true;

                if (xSatisfied && ySatisfied)
                    finish();
            }
        }
    }
}
