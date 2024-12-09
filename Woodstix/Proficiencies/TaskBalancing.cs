namespace Woodstix.Proficiencies;

public class TaskBalancing
{
    public static (Queue<string> q1, Queue<string> q2) HandleJobs(Stack<(int value, string name)> jobs)
    {
        // Initialize worker state and output queues
        var worker1Job = (value: 0, name: "Empty");
        var worker2Job = (value: 0, name: "Empty");

        Queue<string> worker1Queue = new Queue<string>();
        Queue<string> worker2Queue = new Queue<string>();

        worker1Queue.Enqueue("Empty");
        worker2Queue.Enqueue("Empty");

        if (jobs.Count > 0)
        {
            worker1Job = jobs.Pop();
            worker2Job = jobs.Count > 0 ? jobs.Pop() : (0, "Done");
        }

        while (worker1Job.name != "Done" || worker2Job.name != "Done")
        {
            if (worker1Job.value > 0)
            {
                worker1Job.value--;
            }
            if (worker2Job.value > 0)
            {
                worker2Job.value--;
            }

            worker1Queue.Enqueue(worker1Job.name);
            worker2Queue.Enqueue(worker2Job.name);

            if (worker1Job.value == 0)
            {
                worker1Job = jobs.Count > 0 ? jobs.Pop() : (0, "Done");
            }

            if (worker2Job.value == 0)
            {
                worker2Job = jobs.Count > 0 ? jobs.Pop() : (0, "Done");
            }
        }

        return (worker1Queue, worker2Queue);
    }

    public static List<Queue<string>> HandleJobs(Stack<(int value, string name)> jobs, int numberOfWorkers)
    {
            var workerJobs = new List<(int value, string name)>();
            var workerQueues = new List<Queue<string>>();
            
            for (int i = 0; i < numberOfWorkers; i++)
            {
                workerJobs.Add((0, "Empty"));
                var queue = new Queue<string>();
                queue.Enqueue("Empty");
                workerQueues.Add(queue);
            }
            
            for (int i = 0; i < numberOfWorkers && jobs.Count > 0; i++)
            {
                workerJobs[i] = jobs.Pop();
            }
        
            bool allDone = false;
            while (!allDone)
            {
                allDone = true;
                for (int i = 0; i < numberOfWorkers; i++)
                {
                    if (workerJobs[i].name != "Done")
                    {
                        allDone = false;
                        break;
                    }
                }
                
                for (int i = 0; i < numberOfWorkers; i++)
                {
                    if (workerJobs[i].name == "Done" && 
                        (workerQueues[i].Count == 2 || workerQueues[i].ToArray()[workerQueues[i].Count - 1] == "Done"))
                    {
                        continue;
                    }
                    
                    workerQueues[i].Enqueue(workerJobs[i].name);
                    
                    if (workerJobs[i].name == "Done")
                    {
                        continue;
                    }
                    int newValue = workerJobs[i].value > 0 ? workerJobs[i].value - 1 : 0;
                    
                    if (newValue == 0)
                    {
                        workerJobs[i] = jobs.Count > 0 
                            ? jobs.Pop() 
                            : (0, "Done");
                    }
                    else
                    {
                        workerJobs[i] = (newValue, workerJobs[i].name);
                    }
                }
            }

            return workerQueues;
        
    }
}