using System.Runtime.Versioning;

public class Program{ 

internal class n
{
    public int x;
    public n next;
    public n prev;
    public n(int data)
    {
        x = data;
        next = null;
        prev = null;
    }
}

public static void Main(string[] args)
    {
        n root = new n(0);
        n korli = root;

        for (int i = 1; i < 5; i++)
        {
            n yeni_eleman = new n(i);
            korli.next = yeni_eleman;
            yeni_eleman.prev = korli;
            korli = korli.next;
        }

        korli = root;
        ekle(korli, 15);
        ekle(korli, 16);
        ekle(korli, 17);
        ekle(korli, 18);
        korli = root;
        //arayaekle(korli, 5, 78);
        //root = basaekle(root, 11);
        aradansil(korli, 3);
        root = bastansil(root);
        sondansil(korli);
        
        yazdir(root); 
        Console.WriteLine("---------------------");
        tersyazdir(korli);


    }

    static void yazdir(n korli)
    {
        while (korli.next != null)
        {
            Console.WriteLine(korli.x);
            korli = korli.next;
        }
        Console.WriteLine(korli.x);
    }

    static void tersyazdir(n korli)
    {
        while (korli.next != null)
        {
            korli = korli.next;
        }
        while (korli.prev != null)
        {
            Console.WriteLine(korli.x);
            korli = korli.prev;
        }
        Console.WriteLine(korli.x);
    }

    static void ekle(n korli, int x)
    {
        while (korli.next != null)
        {
            korli = korli.next;
        }
        n yenidugum = new n(x);
        korli.next = yenidugum;
        yenidugum.prev = korli;
        
    }

    static void arayaekle(n korli, int sira, int x)
    {
        for(int i = 0; i<sira-1; i++)
        {
            korli = korli.next;
        }
        n yenidugum = new n(x);

        korli.next.prev = yenidugum;
        yenidugum.next = korli.next;
        korli.next = yenidugum;
        yenidugum.prev = korli;
    }

    static n basaekle(n root, int x)
    {
        n yenidugum = new n(x);
        yenidugum.next = root;
        root.prev = yenidugum;
        return yenidugum;
    }

    static n bastansil(n root)
    {
        root = root.next;
        root.prev = null;
        return root;
    }

    static void aradansil(n korli, int sira)
    {
        for(int i = 0; i < sira - 1; i++)
        {
            korli = korli.next;
        }
        korli.next = korli.next.next;
        korli.next.prev = korli;
    }

    static void sondansil(n korli)
    {
        while (korli.next.next != null)
        {
            korli = korli.next;
        }
        korli.next = korli.next.next;
    }

}
