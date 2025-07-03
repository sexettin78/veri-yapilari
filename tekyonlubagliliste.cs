class Program
{
    internal class n
    {
        public int x;
        public n next;
        public n(int data)
        {
            x = data;
            next = null;
        }
    }

    public static void Main(String[] args)
    {
        n root = new n(0);
        n korli = root;

        for(int i = 1; i < 3; i++)
        {
            korli.next = new n(i);
            korli = korli.next;
        }
        root = basaekle(root, 21);
        root = basaekle(root, 211);
        root = bastansil(root);
        arayaekle(1, 110, root);
        ekle(15, korli);
        korli = root;
        // örnek aradan silmek aradansil(3, root);
        // örnek aradan silmek aradansil(1, root);

        // örnek baştan silmek root = bastansil(root);
        // örnek baştan silmek root = bastansil(root);
        
        korli = root;
        yazdir(root);
    }

    public static void yazdir(n korli)
    {
        int say = 0;
        while (korli.next != null)
        {
            Console.WriteLine("-" + korli.x);
            korli = korli.next;
            say++;

        }
        Console.WriteLine("Eleman sayısı: '" + say + "'");
    }

    public static void ekle(int x, n korli)
    {
        while (korli.next != null)
        {
            korli = korli.next;
        }
        korli.next = new n(x);
    }

    public static n basaekle(n root, int x)
    {
        n yeni_bas = new n(x);
        yeni_bas.next = root;
        return yeni_bas;
    }

    public static void arayaekle(int sira, int x, n korli)
    {
        int ic = 0;
        while (ic != sira)
        {
            korli = korli.next;
            ic++;
        }
        n temp = new n(x);
        temp.next = korli.next;
        korli.next = temp;
    }

    public static void aradansil(int sira, n korli)
    {
        int ic = 0;
        n once = korli;
        n sonra = korli.next;

        while (ic != sira)
        {
            once = sonra;
            sonra = sonra.next;
            ic++;
        }
        once.next = sonra.next;
    }

    public static n bastansil(n root)
    {
        root = root.next;
        return root;
    }


}
