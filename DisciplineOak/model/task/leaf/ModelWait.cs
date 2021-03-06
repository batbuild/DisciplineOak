﻿/**
 * A ModelWait task is a task that keeps running for a period of time, and then
 * succeeds. The user can specify for how long the ModelWait task should be
 * running. For that period of time, the task will be evaluated to
 * Status.RUNNING. Then, the task will return Status.SUCCESS.
 * 
 
 * 
 */

using System;
using DisciplineOak.Execution.Core;
using DisciplineOak.Execution.Task.Leaf;
using DisciplineOak.Model.Core;
using DisciplineOak.Model.Task.Leaf.Action;

namespace DisciplineOak.Model.Task.Leaf
{
	[Serializable]
	public class ModelWait : ModelAction
	{
		/**
		 * Duration, measured in milliseconds, of the period of time the task will
		 * be running.
		 */
		private readonly long _duration;

		/**
		 * Constructor. Constructs a ModelWait task that will keep running for
		 * <code>duration</code> milliseconds.
		 * 
		 * @param guard
		 *            the guard of the ModelWait task, which may be null.
		 * @param duration
		 *            the ModelWait of the Wait task, in milliseconds.
		 */

		public ModelWait(ModelTask guard, long duration)
			: base(guard)
		{
			_duration = duration;
		}

		public long Duration
		{
			get { return _duration; }
		}

		public override ExecutionTask CreateExecutor(BTExecutor executor, ExecutionTask parent)
		{
			return new ExecutionWait(this, executor, parent);
		}
	}
}