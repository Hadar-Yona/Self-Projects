import java.io.*;
import java.util.List;
import java.util.*;

public class Main {

    public static void main(String[] args) {

        List<String> lines = getLinesFromFile();
        System.out.println("Number of lines found: " + lines.size());
        System.out.println("Starting to process");

        long startTimeWithoutThreads = System.currentTimeMillis();
        workWithoutThreads(lines);
        long elapsedTimeWithoutThreads = (System.currentTimeMillis() - startTimeWithoutThreads);
        System.out.println("Execution time: " + elapsedTimeWithoutThreads);


        long startTimeWithThreads = System.currentTimeMillis();
        workWithThreads(lines);
        long elapsedTimeWithThreads = (System.currentTimeMillis() - startTimeWithThreads);
        System.out.println("Execution time: " + elapsedTimeWithThreads);

    }

    private static void workWithThreads(List<String> lines) {
        //Your code:
        //Get the number of available cores
        //Assuming X is the number of cores - Partition the data into x data sets
        //Create X threads that will execute the Worker class
        //Wait for all threads to finish
        int x = Runtime.getRuntime().availableProcessors();
        int p = lines.size()/x;
        for (int j = 0; j < x; j++){
            List<String> sublist;
            sublist = lines.subList(j*p,((j+1)*p)-1);
            Worker wj = new Worker(sublist);
            Thread tj = new Thread(wj);
            tj.start();
            try {
                tj.join();
                } catch (InterruptedException e) {
                e.printStackTrace();
             }
        }
    }

    private static void workWithoutThreads(List<String> lines) {
        Worker worker = new Worker(lines);
        worker.run();
    }

    private static List<String> getLinesFromFile() {
        String path = "C:\\Windows\\Temp\\Shakespeare.txt";
        ArrayList<String> lines = new ArrayList<>();
        try
        {
            BufferedReader reader = new BufferedReader((new FileReader(path)));
            String line = null;
            while ((line = reader.readLine()) != null)
            {
                lines.add(line);
            }
        } catch (IOException e) {
            System.err.println("Error " + e);
        }
        return lines;
    }
}
