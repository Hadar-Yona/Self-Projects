import java.io.Serializable;
import java.util.Comparator;

public class StringsOfNumsComparator implements Comparator<String>, Serializable
{

    /**
     *
     */
    private static final long serialVersionUID = 2L;

    @Override
    public int compare(String o1, String o2) {
       if(o1.length() < o2.length()) return 0;
       else if(o1.length() > o2.length()) return 1;
       else
       {
           for (int i = 0; i < o1.length(); i++) 
           {
                if(o1.charAt(i) < o2.charAt(i)) return 0;
                else if (o1.charAt(i) > o2.charAt(i)) return 1; 
           }
       }

        return 0;
    }

}