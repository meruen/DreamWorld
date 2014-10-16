using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    /// <summary>
    /// Abstract class that will be use for any kind of action.
    /// </summary>
    abstract class GenericAction {
        protected bool running, finished, repeatAtEnd = false;
        protected Object parent;

        /// <summary>
        /// Basic constructor.
        /// </summary>
        public GenericAction() {
        }

        /// <summary>
        /// Get the 'parent' Object that will be used with the Action.
        /// </summary>
        /// <returns>parent object.</returns>
        public virtual Object getParent() {
            return parent;
        }

        /// <summary>
        /// Verify if the Action is still running.
        /// </summary>
        /// <returns>running attribute value.</returns>
        public bool isRunning() {
            return running;
        }

        /// <summary>
        /// Set the running attribute of the Action.
        /// </summary>
        /// <param name="running">Say that the Action is running.</param>
        public void setRunning(bool running) {
            this.running = running;
        }

        /// <summary>
        /// Set the finished attribute of the Action.
        /// </summary>
        /// <param name="finished">Say that if the Action is finished.</param>
        public void setFininshed(bool finished) {
            this.finished = true;
        }

        /// <summary>
        /// Get the finished attribute of the Action.
        /// </summary>
        /// <returns>Finished attribute of the Action.</returns>
        public bool isFinished() {
            return finished;
        }

        /// <summary>
        /// Finish the execution of the Action.
        /// </summary>
        public void finish() {
            this.finished = true;
            this.running = false;
        }

        /// <summary>
        /// Set the option if you want to repeat the Action when it's finished.
        /// </summary>
        /// <param name="repeatAtEnd">repeatAtEnd attribute of the Action.</param>
        public void setRepeatAtEnd(bool repeatAtEnd) {
            this.repeatAtEnd = repeatAtEnd;
        }

        /// <summary>
        /// Get the repeatAtEnd of the action, that say if the Action must repeat when it's finished.
        /// </summary>
        /// <returns>repeatAtEnd attribute</returns>
        public bool isRepeatAtEnd() {
            return repeatAtEnd;
        }

        /// <summary>
        /// Start the Action.
        /// </summary>
        public virtual void start() {
            finished = false;
            running = true;
        }

        /// <summary>
        /// Initialize the action.
        /// </summary>
        /// <param name="parent">Pass by parameter the parent object that will be used by the action.</param>
        public virtual void initialize(Object parent) {
            this.parent = parent;
        }

        /// <summary>
        /// Abstract <c>update(GameTime)</c> function that will be overrided in implementations of the <c>GenericAction</c> class.
        /// </summary>
        /// <param name="gameTime">Basic <c>GameTime</c> parameter.</param>
        public abstract void update(GameTime gameTime);
    }
}
