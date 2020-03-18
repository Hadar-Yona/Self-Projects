import java.io.File;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Searcher implements java.lang.Runnable {
    private String pattern;
    private SynchronizedQueue<File> directoryQueue;
    private SynchronizedQueue<File> resultsQueue;

    public Searcher (String pattern, SynchronizedQueue directoryQueue, SynchronizedQueue resultsQueue) {
        this.pattern = pattern;
        this.directoryQueue = directoryQueue;
        this.resultsQueue = resultsQueue;
    }

    public void run() {
    while ((directoryQueue.getSize()) != 0)
    {
        File file = (directoryQueue.dequeue());
        File[] files = file.listFiles();
        for (int i = 0; i < files.length; i++) {
           if (file.listFiles()[i].isFile())
           {
               Pattern p = Pattern.compile(pattern);
               Matcher m = p.matcher(file.listFiles()[i].getName());
               if (m.find())
               {
                   File matchFile = file.listFiles()[i];
                   resultsQueue.enqueue(matchFile);
               }
            }
           }
    }
    }
}