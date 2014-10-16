using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    /// <summary>
    /// This class is amazing. This class just Enqueue a lot of Actions and execute one after one. The incredible is that this class can receive another ActionManager like an action.
    /// </summary>
    class ActionManager : GenericAction {
        protected Queue<GenericAction> action;
        protected GenericAction currentAction;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ActionManager() {
            action = new Queue<GenericAction>();
            finished = running = false;
        }

        /// <summary>
        /// This function Enqueue an Action on the Queue.
        /// </summary>
        /// <param name="action">Action that will be Enqueued.</param>
        public void addAction(GenericAction action) {
            this.action.Enqueue(action);
        }

        /// <summary>
        /// This function finish the <c>currentAction</c>.
        /// </summary>
        public void nextAction() {
            currentAction.setFininshed(true);
        }

        /// <summary>
        /// Start the action queue.
        /// </summary>
        public override void start() {
            if (action.Count != 0) {
                running = true;
                finished = false;
                currentAction = action.Dequeue();
                currentAction.start();
            }
        }

        /// <summary>
        /// Update the current Action and verify if has been finished.
        /// </summary>
        /// <param name="gameTime">Basic GameTime parameter.</param>
        public override void update(GameTime gameTime) {
            if (running) {
                currentAction.update(gameTime);
                if (currentAction.isFinished())
                    if (action.Count > 0) {
                        currentAction = action.Dequeue();
                        currentAction.start();
                    } else
                        finish();
            }
        }
    }
}
