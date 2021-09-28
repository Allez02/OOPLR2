using System;
using System.Collections.Generic;

namespace Laba2
{
    class Program
    {
       
        public class Rabota : IComparable
        {
            private int oplata;
            private int rabotnik;
            public void setOplata(int val)
            {
                this.oplata = val;
            }
            public int getOplata()
            {
                return this.oplata;
            }
            public void setRabjtnik(int val)
            {
                this.rabotnik = val;
            }
            public int getRabotnik()
            {
                return this.rabotnik;
            }
            public Rabota(int n, int m)
            {
                this.oplata = n;
                this.rabotnik = m;
            }
            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Rabota srobj = obj as Rabota;
                if (srobj != null)
                    return this.rabotnik.CompareTo(srobj.rabotnik);
                else
                    throw new Exception();
            }

        };
        public class Zarp : IComparable
        {
            private int rabotnik;
            private int zp;
            public void setZp(int val)
            {
                this.zp = val;
            }
            public int getZp()
            {
                return this.zp;
            }
            public void setRabjtnik(int val)
            {
                this.rabotnik = val;
            }
            public int getRabotnik()
            {
                return this.rabotnik;
            }
            public Zarp(int n)
            {
                this.rabotnik = n;
                this.zp = 0;
            }
            public void getInfo()
            {
                Console.WriteLine("Зп " + this.rabotnik + ": " + this.zp);
            }
            public void lowZp()
            {
                Console.WriteLine("Самый низкооплачаваемый работник " + this.rabotnik);
            }
            public void highZp()
            {
                Console.WriteLine("Самый высокооплачаваемый работник " + this.rabotnik);
            }
            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Zarp srobj = obj as Zarp;
                if (srobj != null)
                    return this.zp.CompareTo(srobj.zp);
                else
                    throw new Exception();
            }
        };
        static void Main(string[] args)
        {
            int[] mas1 = { 1000, 5000, 3000, 10000, 10000, 20000, 100, 10000, 100};
            int[] mas2 = { 0, 1, 2, 3, 0, 100, 50, 100, 50 };
            float srop = 0;
            List<Rabota> op = new List<Rabota>();
            List<Zarp> trat = new List<Zarp>();
            for (int i = 0; i < mas1.Length; i++)
            {
                srop += mas1[i];
                Rabota x = new Rabota(mas1[i], mas2[i]);
                op.Add(x);
            }
            srop /= mas1.Length;
            Console.WriteLine("Средняя оплата: " + srop);
            int j = -1;
            op.Sort();
            for (int i = 0; i < op.Count; i++)
            {
                if (i == 0 || op[i].getRabotnik() != op[i-1].getRabotnik())
                {
                    if (i != 0)
                        trat[j].getInfo();
                    Zarp x = new Zarp(op[i].getRabotnik());
                    trat.Add(x);
                    j++;
                }
                trat[j].setZp(trat[j].getZp()+op[i].getOplata());
            }
            trat[j].getInfo();
            trat.Sort();
            trat[0].lowZp();
            trat[j].highZp();
        }
    }
}
