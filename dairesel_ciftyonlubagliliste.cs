using System.ComponentModel.Design.Serialization;
using System.Runtime.Versioning;
using static System.Net.Mime.MediaTypeNames;

public class Program
{

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

        for(int i = 1; i < 5; i++)
        {
            n yeni_eleman = new n(i);
            korli.next = yeni_eleman;
            yeni_eleman.prev = korli;
            korli = korli.next;
        }
        korli.next = root; root.prev = korli;

        root = ekle(root, korli, 100);
        root = arayaekle(root, root, 2, 9);
        root = basaekle(root, 11);
        root = basaekle(root, 13);
        root = basaekle(root, 15);

        root = aradansil(root, korli, 4);

        root = bastansil(root);

        root = bastansil(root);

        yazdir(root);
        Console.WriteLine("----------------------------------");
        tersyazdir(root);

    }

    static void yazdir(n root)
    {
        Console.WriteLine(root.x);
        n korli = root.next;
        while(korli.next != root)
        {
            Console.WriteLine(korli.x);
            korli = korli.next;
        }
        Console.WriteLine(korli.x);
    }

    static void tersyazdir(n root)
    {
        Console.WriteLine(root.prev.x);
        n korli = root.prev;
        while (korli.prev != root)
        {
            Console.WriteLine(korli.prev.x);
            korli = korli.prev;
        }
        Console.WriteLine(korli.prev.x);
    }

    static n ekle(n root, n korli, int x)
    {
        korli = korli.next;
        while (korli.next != root)
        {
            korli = korli.next;
        }
        n yenidugum = new n(x);
        korli.next = yenidugum;
        yenidugum.prev = korli;
        yenidugum.next = root;
        root.prev = yenidugum;
        return root;
    }

    static n arayaekle(n root, n korli, int sira, int x)
    {
        for(int i = 0; i < sira-1; i++)
        {
            korli = korli.next;
        }
        n yenidugum = new n(x);
        yenidugum.next = korli.next;
        korli.next = yenidugum;
        yenidugum.prev = korli;
        yenidugum.next.prev = yenidugum;
        return root;
    }

    static n basaekle(n root, int x)
    {
        n yenidugum = new n(x);
        yenidugum.prev = root.prev;
        root.prev.next= yenidugum;
        yenidugum.next = root;
        root.prev = yenidugum;
        return yenidugum;
    }

    static n aradansil(n root, n korli, int sira) //sondan da silebilir.
    {
        for(int i = 0; i < sira - 1; i++)
        {
            korli = korli.next;
        }
        korli.next= korli.next.next;
        korli.next.prev = korli;

        return root;
    }

    static n bastansil(n root)
    {
        n yenidugum = root.prev;
        root.next.prev = yenidugum;
        yenidugum.next = root.next;
        return yenidugum;
    }

}
