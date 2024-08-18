namespace MultithreadingPart6AsynchronousProgramming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting tasks...");

            var task1 = Task.Run(() => DoWorkAsync(1, 3000)); // Task that takes 3 seconds
            var task2 = Task.Run(() => DoWorkAsync(2, 2000)); // Task that takes 2 seconds
            var task3 = Task.Run(() => DoWorkAsync(3, 1000)); // Task that takes 1 second

            // Main thread doing work while waiting for tasks to complete
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("main thread is working");
            }

            // Now wait for all tasks to complete
            var results = await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("All tasks completed:");

            foreach (var result in results)
            {
                Console.WriteLine($"Task result: {result}");
            }
        }

        static async Task<int> DoWorkAsync(int taskId, int delay)
        {
            Console.WriteLine($"Task {taskId} starting...");

            await Task.Delay(delay); // Simulate asynchronous work with a delay

            Console.WriteLine($"Task {taskId} completed.");
            return taskId; // Return the task ID as the result
        }
    }
}
