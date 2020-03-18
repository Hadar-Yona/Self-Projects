import java.io.File;

public class Scouter implements java.lang.Runnable {
    private SynchronizedQueue<File> Q;
    private File root;

    public Scouter(SynchronizedQueue directoryQueue, File root) {
        this.Q = directoryQueue;
        this.root = root;
    }

    @Override
    public void run() {
        synchronized(this) {
            Q.registerProducer();                                // should create a new producer before it starts to enqueue
            listDirs(root);
            Q.unregisterProducer();                              // producer finishes to enqueue items
        }
    }

    public void listDirs (File currentDir) {                      // checks recursively all directories and subdirectories from the root
        if (currentDir.isDirectory()) {
            Q.enqueue(currentDir);
            File[] files = currentDir.listFiles();
            for (int i = 0; i < files.length; i++) {
                if (currentDir.listFiles()[i].isDirectory()) {
                    listDirs(currentDir.listFiles()[i]);
                }
            }
        }
        }
    }