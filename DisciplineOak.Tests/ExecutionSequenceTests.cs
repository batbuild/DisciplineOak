﻿using DisciplineOak.Execution.Core;
using DisciplineOak.Model.Task.Composite;
using DisciplineOak.Model.Task.Leaf.Action;
using NUnit.Framework;

namespace DisciplineOak.Tests
{
	[TestFixture]
	public class ExecutionSequenceTests
	{
		[Test]
		public void When_running_then_one_tickable()
		{
			var modelSequence = new ModelSequence(null,
				new ModelOf<MyAction>(null),
				new ModelOf<MyAction>(null));
			var executor = BTExecutorFactory.CreateBTExecutor(modelSequence);

			executor.Tick();
			executor.Tick();

			Assert.AreEqual(1, executor.TickableTasks.Count);
		}

		[Test]
		public void When_failed_then_return()
		{
			var myfailingAction = new ModelOf<MyAction>(null);

			var modelSequence = new ModelSequence(null,
				myfailingAction,
				new ModelOf<MyAction>(null));
			var executor = BTExecutorFactory.CreateBTExecutor(modelSequence);
			
			executor.Tick();
			myfailingAction.Action.ReturnStatusForInternalTick = Status.Failure;
			executor.Tick();
			executor.Tick();

			Assert.AreEqual(Status.Failure, executor.GetStatus());
		}

	}
}