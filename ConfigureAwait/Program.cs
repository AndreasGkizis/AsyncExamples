namespace ConfigureAwait;

internal class Program
{
	static async Task Main(string[] args)
	{

		await ConfigureAwaitFalse();

		await SimpleAwait();

		await ConfigureAwaitTrue();
		Console.WriteLine("Program Complete.");
	}

	private static async Task<(int Task1Result, int Task2Result, int Task3Result)> ConfigureAwaitFalse()
	{
		Console.WriteLine("{0}: [Before Await] Thread ID: {1}", nameof(ConfigureAwaitFalse),
			Thread.CurrentThread.ManagedThreadId);

		var task1 = SimulateSimpleAsyncTask(20);
		var task2 = SimulateSimpleAsyncTask(10);
		var task3 = SimulateSimpleAsyncTask(30);

		await Task.WhenAll(task1, task2, task3);
		
		Console.WriteLine("{0}: [After Await] Thread ID: {1}", nameof(ConfigureAwaitFalse),
			Thread.CurrentThread.ManagedThreadId);
		return (task1.Result, task2.Result, task3.Result);
	}

	private static async Task<(int Task1Result, int Task2Result, int Task3Result)> SimpleAwait()
	{
		Console.WriteLine("{0}: [Before Await] Thread ID: {1}", nameof(SimpleAwait),
			Thread.CurrentThread.ManagedThreadId);

		var task1 = SimulateSimpleAsyncTask(20);
		var task2 = SimulateSimpleAsyncTask(10);
		var task3 = SimulateSimpleAsyncTask(30);

		await Task.WhenAll(task1, task2, task3);
		
		Console.WriteLine("{0}: [After Await] Thread ID: {1}", nameof(SimpleAwait),
			Thread.CurrentThread.ManagedThreadId);
		return (task1.Result, task2.Result, task3.Result);
	}

	private static async Task<(int Task1Result, int Task2Result, int Task3Result)> ConfigureAwaitTrue()
	{
		Console.WriteLine("{0}: [Before Await] Thread ID: {1}", nameof(ConfigureAwaitTrue),
			Thread.CurrentThread.ManagedThreadId);

		var task1 = SimulateSimpleAsyncTask(20);
		var task2 = SimulateSimpleAsyncTask(10);
		var task3 = SimulateSimpleAsyncTask(30);

		await Task.WhenAll(task1, task2, task3).ConfigureAwait(true);
		
		Console.WriteLine("{0}: [After Await] Thread ID: {1}", nameof(ConfigureAwaitTrue),
			Thread.CurrentThread.ManagedThreadId);
		return (task1.Result, task2.Result, task3.Result);
	}

	static async Task<int> SimulateSimpleAsyncTask(int delay)
	{
		Console.WriteLine("{0}: [Before Await] Thread ID: {1}", nameof(SimulateSimpleAsyncTask),
			Thread.CurrentThread.ManagedThreadId);

		await Task.Delay(delay);
		
		Console.WriteLine("{0}: [After Await] Thread ID: {1}", nameof(SimulateSimpleAsyncTask),
			Thread.CurrentThread.ManagedThreadId);
		
		return delay;
	}
}