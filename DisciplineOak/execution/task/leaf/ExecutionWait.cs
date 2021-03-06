﻿/**
 * ExecutionWait is the ExecutionTask that knows how to run a ModelWait task.
 * 
 
 * 
 */

using System;
using DisciplineOak.Execution.Core;
using DisciplineOak.Model.Core;
using DisciplineOak.Model.Task.Leaf;

namespace DisciplineOak.Execution.Task.Leaf
{
	public class ExecutionWait : ExecutionLeaf
	{
		/** Duration of the wait task. */
		private long duration;
		/**
	 * Starting time, measured in nanoseconds. Note that this value is obtained
	 * by {@link System#nanoTime()}, so it is not related to any notion of
	 * system or wall-clock time. Therefore, it can only be used to measure time
	 * intervals.
	 */
		private long _startTime;

		/**
	 * Creates an ExecutionWait that is able to run a ModelWait task and that is
	 * managed by a BTExecutor.
	 * 
	 * @param modelTask
	 *            the ModelWait that this ExecutionWait is going to run.
	 * @param executor
	 *            the BTExecutor in charge of running this ExecutionWait.
	 * @param parent
	 *            the parent ExecutionTask of this task.
	 */

		public ExecutionWait(ModelTask modelTask, BTExecutor executor, ExecutionTask parent)
			: base(modelTask, executor, parent)
		{
			if (!(modelTask is ModelWait))
			{
				throw new ArgumentException("The ModelTask must subclass ModelWait but it inherits from " + modelTask.GetType().Name);
			}
			
			Initialize(modelTask);
		}

		private void Initialize(ModelTask modelTask)
		{
			duration = ((ModelWait) modelTask).Duration;
		}

		/**
	 * Starts measuring the time interval.
	 * 
	 * @see jbt.execution.core.ExecutionTask#internalSpawn()
	 */

		protected override void InternalSpawn()
		{
			Executor.RequestInsertionIntoList(BTExecutor.BTExecutorList.Tickable, this);
			_startTime = DateTime.Now.Ticks;
		}

		/**
	 * Does nothing.
	 * 
	 * @see jbt.execution.core.ExecutionTask#internalTerminate()
	 */

		protected override void InternalTerminate()
		{
		}

		/**
	 * Returns Status.SUCCESS or Status.RUNNING depending on whether the task
	 * has waited long enough or not.
	 * 
	 * @see jbt.execution.core.ExecutionTask#internalTick()
	 */

		protected override Status InternalTick()
		{
			long estimatedTime = DateTime.Now.Ticks - _startTime;

			if ((TimeSpan.FromTicks(estimatedTime)).TotalMilliseconds >= duration)
			{
				return Status.Success;
			}
			return Status.Running;
		}

		/**
	 * Does nothing.
	 * 
	 * @see jbt.execution.core.ExecutionTask#restoreState(ITaskState)
	 */

		protected override void RestoreState(ITaskState state)
		{
		}
	
		protected override ITaskState StoreState()
		{
			return null;
		}

	
		protected override ITaskState StoreTerminationState()
		{
			return null;
		}
	}
}