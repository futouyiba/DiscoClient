using DG.Tweening;
using DG.Tweening.Core;

namespace ET.Module
{
    public static class DotweenHelper
    {
        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed or complete.
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.WaitForCompletion();</code>
        /// </summary>
        public static async System.Threading.Tasks.Task AsyncWaitForCompletion(this Tween t)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active && !t.IsComplete()) await System.Threading.Tasks.Task.Yield();
        }

        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed or rewinded.
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.AsyncWaitForRewind();</code>
        /// </summary>
        public static async System.Threading.Tasks.Task AsyncWaitForRewind(this Tween t)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active && (!t.playedOnce || t.position * (t.CompletedLoops() + 1) > 0)) await System.Threading.Tasks.Task.Yield();
        }

        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed.
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.AsyncWaitForKill();</code>
        /// </summary>
        public static async System.Threading.Tasks.Task AsyncWaitForKill(this Tween t)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active) await System.Threading.Tasks.Task.Yield();
        }

        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed or has gone through the given amount of loops.
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.AsyncWaitForElapsedLoops();</code>
        /// </summary>
        /// <param name="elapsedLoops">Elapsed loops to wait for</param>
        public static async System.Threading.Tasks.Task AsyncWaitForElapsedLoops(this Tween t, int elapsedLoops)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active && t.CompletedLoops() < elapsedLoops) await System.Threading.Tasks.Task.Yield();
        }

        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed or started
        /// (meaning when the tween is set in a playing state the first time, after any eventual delay).
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.AsyncWaitForPosition();</code>
        /// </summary>
        /// <param name="position">Position (loops included, delays excluded) to wait for</param>
        public static async System.Threading.Tasks.Task AsyncWaitForPosition(this Tween t, float position)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active && t.position * (t.CompletedLoops() + 1) < position) await System.Threading.Tasks.Task.Yield();
        }

        /// <summary>
        /// Returns an async <see cref="System.Threading.Tasks.Task"/> that waits until the tween is killed.
        /// It can be used inside an async operation.
        /// <para>Example usage:</para><code>await myTween.AsyncWaitForKill();</code>
        /// </summary>
        public static async System.Threading.Tasks.Task AsyncWaitForStart(this Tween t)
        {
            if (!t.active) {
                if (Debugger.logPriority > 0) Debugger.LogInvalidTween(t);
                return;
            }
            while (t.active && !t.playedOnce) await System.Threading.Tasks.Task.Yield();
        }
    }
}