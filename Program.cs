using System.Diagnostics;

public class Program {
    static void Main(string[] args) {
        new Benchmarker(1000000000);
    }
}

public class Benchmarker {
    private int[] collection = new int[0];

    public Benchmarker(int operations) {
        collection = new int[operations];

        Benchmark(For);
        Benchmark(ForWithCache);
        Benchmark(Foreach);
        Benchmark(While);
        Benchmark(WhileWithCache);
        Benchmark(DoWhile);
        Benchmark(DoWhileWithCache);
    }

    private void Benchmark(Action action) {
        Stopwatch sw = new();
        sw.Start();
        action.Invoke();
        sw.Stop();
        Console.WriteLine($"Benchmarking: {sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}s -> {action.Method.Name}");
    }

    private void For() {
        for(int i = 0; i < collection.Length; i++) {
            _ = i;
        }
    }

    private void ForWithCache() {
        for(int i = 0, n = collection.Length; i < n; i++) {
            _ = i;
        }
    }

    private void Foreach() {
        foreach(int i in collection) {
            _ = collection[i];
        }
    }

    private void While() {
        int i = 0;
        while(i < collection.Length){
            _ = collection[i];
            i++;
        }
    }

    private void WhileWithCache() {
        int i = 0;
        int length = collection.Length;
        while(i < length){
            _ = collection[i];
            i++;
        }
    }

    private void DoWhile() {
        int i = 0;
        do {
            _ = collection[i];
            i++;
        }
        while(i < collection.Length);
    }

    private void DoWhileWithCache() {
        int i = 0;
        int length = collection.Length;
        do {
            _ = collection[i];
            i++;
        }
        while(i < length);
    }
}