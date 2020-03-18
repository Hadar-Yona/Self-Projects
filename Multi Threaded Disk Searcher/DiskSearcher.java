import java.io.File;

public class DiskSearcher extends java.lang.Object {
    static int DIRECTORY_QUEUE_CAPACITY = 50;     // Capacity of the queue that holds the directories to be searched
    static int RESULTS_QUEUE_CAPACITY = 50;       // Capacity of the queue that holds the files found

    public static void main(String[] args) {
        SynchronizedQueue<File> directoryQueue = new SynchronizedQueue<File>(DIRECTORY_QUEUE_CAPACITY);
        SynchronizedQueue<File> resultQueue = new SynchronizedQueue<File>(RESULTS_QUEUE_CAPACITY);
        File root = new File(args[1]);
        Scouter scouter = new Scouter(directoryQueue, root);
        Thread t = new Thread(scouter);
        t.start();
        try {
            t.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        Searcher searcher = new Searcher(args[0], directoryQueue, resultQueue);
        int i = 0;
        while (i < (Integer.parseInt(args[3]))) {
            Thread s = new Thread(searcher);
            s.start();
            try {
                s.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            i++;
        }
        File dest = new File(args[2]);
        Copier copier = new Copier(dest, resultQueue);
        int j = 0;
        while (j < (Integer.parseInt(args[4]))) {
            Thread r = new Thread(copier);
            r.start();
            try {
                r.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            j++;
        }
        }
}