﻿/**
 * This class represents a task with one or more children, which are run
 * sequentially.
 * <p>
 * A selector tries to run all its children sequentially. Therefore, there is an
 * active child task. However, when the current active task fails, the selector
 * does not fail, but goes on to the next child task, which is evaluated. A
 * selector succeeds if one of the tasks succeeds, and fails if all the child
 * tasks fail.
 * 
 
 * 
 */

using System;
using DisciplineOak.Execution.Core;
using DisciplineOak.Execution.Task.Composite;
using DisciplineOak.Model.Core;

namespace DisciplineOak.Model.Task.Composite
{
	[Serializable]
	public class ModelSelector : ModelComposite
	{
		/**
	 * Constructor.
	 * <p>
	 * Constructs a ModelSelector with some children. A ModelSelector must have
	 * at least one child.
	 * 
	 * @param guard
	 *            the guard of the ModelSelector, which may be null.
	 * @param children
	 *            the list of children. Must have at least one element.
	 */

		public ModelSelector(ModelTask guard, params ModelTask[] children) 
			: this(guard, null, children)
		{
		}

		public ModelSelector(ModelTask guard, string name, params ModelTask[] children)
			: base(guard, name, children)
		{
		}

		/**
	 * Returns an ExecutionSelector that is able to run this ModelSelector.
	 * 
	 * @see jbt.model.core.ModelTask#createExecutor(jbt.execution.core.BTExecutor,
	 *      ExecutionTask)
	 */

		public override ExecutionTask CreateExecutor(BTExecutor executor, ExecutionTask parent)
		{
			return new ExecutionSelector(this, executor, parent);
		}
	}
}