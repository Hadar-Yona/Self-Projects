import java.io.*;

public class Copier implements java.lang.Runnable {
    private File dest;
    private SynchronizedQueue<File> resultsQueue;
    public static final int COPY_BUFFER_SIZE = 4096;

    public Copier(File destination, SynchronizedQueue resultsQueue) {
        this.dest = destination;
        this.resultsQueue = resultsQueue;
    }

    public void run() {
        InputStream in = null;
        OutputStream out = null;
        byte[] buffer = new byte[COPY_BUFFER_SIZE];
        int i = 1;
        while(resultsQueue.getSize() != 0)
        {
            File fileToCopyFromQueue = (resultsQueue.dequeue());
            System.out.println(i + ". " + fileToCopyFromQueue.getName());
            File newFileInDest = new File(this.dest, fileToCopyFromQueue.getName());    // copy the file into the specified destination directory
            int c;
            try
            {
                in = new FileInputStream(fileToCopyFromQueue);
                out = new FileOutputStream(newFileInDest);
                while((c = in.read(buffer)) != -1 )
                {
                    out.write(buffer,0, c);
                }
                out.flush();
            } catch (IOException e)
            {
                e.printStackTrace();
            }finally {
                try {
                    in.close();
                    out.close();
                }catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
            i++;
        }

    }
}