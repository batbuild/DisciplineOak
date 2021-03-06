﻿/**
 * ExecutionAction is the base class of all of the class that are able to run
 * actions in the game (that is, subclasses of ModelAction).
 * 
 
 * 
 */

using System;
using DisciplineOak.Execution.Core;

using DisciplineOak.Model.Task.Leaf.Action;

namespace DisciplineOak.Execution.Task.Leaf.Action
{
	public abstract class ExecutionAction : ExecutionLeaf
	{
		/**
	 * Constructs an ExecutionAction that knows how to run a ModelAction.
	 * 
	 * @param modelTask
	 *            the ModelAction to run.
	 * @param executor
	 *            the BTExecutor that will manage this ExecutionAction.
	 * @param parent
	 *            the parent ExecutionTask of this task.
	 */

		protected ExecutionAction(ModelAction modelTask, BTExecutor executor, ExecutionTask parent)
			: base(modelTask, executor, parent)
		{
			if (modelTask == null )
			{
				throw new ArgumentException("The ModelTask must not be null" );
			}
		}

	}
}