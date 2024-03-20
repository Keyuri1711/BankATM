using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace bankATMFinalprj
{
    public static class ReadWriteTextFile
    {
        public struct bkdetails
        {
            public string number1;
            public string name;
            public string Nip;
            public Int64 Sol;
        }
        public static void Main()
        {
            ProjectATM();
        }
        public static void OpenFileForWriting()
        {
            StreamWriter myfile = new StreamWriter("ProjectATM.txt", true);

            myfile.WriteLine("CP001");
            myfile.WriteLine("Bill Gates");
            myfile.WriteLine("Windows");
            myfile.WriteLine("4000600");

            myfile.WriteLine("CP002");
            myfile.WriteLine("Alexander Cama");
            myfile.WriteLine("Flipkart");
            myfile.WriteLine("8877000");

            myfile.WriteLine("CP003");
            myfile.WriteLine("Luiza Maria");
            myfile.WriteLine("Oracle");
            myfile.WriteLine("992211");
            myfile.Close();
        }
        public static void ProjectATM()
        {
            Int16 ch;
            bkdetails[] tabbkdetails = new bkdetails[200];

            Int16 CLnumber;
            {
                Int16 i = 0;
                StreamReader myfile = new StreamReader("ProjectATM.txt");
                while (myfile.EndOfStream == false)
                {
                    tabbkdetails[i].number1 = myfile.ReadLine();
                    tabbkdetails[i].name = myfile.ReadLine();
                    tabbkdetails[i].Nip = (myfile.ReadLine());
                    tabbkdetails[i].Sol = Convert.ToInt64(myfile.ReadLine());
                    i++;
                }
                CLnumber = i;
                myfile.Close();
            }
            Boolean Ch = false;
            Int16 num_b = 0;
            do
            {
                Console.WriteLine("\n\n\t\tBANQUE ROYAL");
                Console.WriteLine("\t\t------------");
                Console.WriteLine("\tGuichet Automatique Bancaire");
                Console.WriteLine("\t----------------------------\n");

                String Account;
                Int16 NB1 = 0;
                Boolean ava = false;

                do
                {
                    Console.Write("Entrez votre numero de compte : ");
                    Account = Console.ReadLine();
                    for (Int16 i = 0; i < CLnumber; i++)
                    {
                        if (tabbkdetails[i].number1 == Account)
                        {
                            NB1 = i;
                            ava = true;
                        }
                    }
                    if (ava == false)
                    {
                        Console.WriteLine("Le compte est invalide ");
                    }
                } while (ava == false);
                Console.WriteLine("\n\n\tBienvenue " + tabbkdetails[NB1].name);

                string nip;
                Boolean a_le = false;
                do
                {
                    Console.Write("Entrez votre nip : ");
                    nip = Console.ReadLine();
                    for (Int16 i = 0; i < CLnumber; i++)
                    {
                        if (tabbkdetails[i].Nip == nip)
                        {
                            num_b = i;
                            a_le = true;
                        }
                    }
                    if (a_le == false)
                    {
                        Console.WriteLine("Le nip est invalide ");
                    }
                } while (a_le == false);

                Console.WriteLine("\nChoisir votre Transaction");
                Console.WriteLine("\t1 - Pour Deposer");
                Console.WriteLine("\t2 - Pour Retirer");
                Console.WriteLine("\t3 - Pour Consulter");
                do
                {
                    Console.Write("Entrez votre choix <1-3> : ");
                    ch = Convert.ToInt16(Console.ReadLine());
                } while (ch < 1 || ch > 3);

                switch (ch)
                {
                    case 1:
                        UInt32 acc_bal;
                        Boolean acc = false;
                        Ch = true;
                        do
                        {
                            Console.Write("\nEntrez le montant a deposer $ : ");
                            acc_bal = Convert.ToUInt32(Console.ReadLine());
                            if (acc_bal <= 20000 && acc_bal >= 2)
                            {
                                tabbkdetails[num_b].Sol = tabbkdetails[num_b].Sol + acc_bal;
                                acc = true;
                            }
                        } while (acc == false);
                        break;
                    case 2:
                        Int64 wi_drawal;
                        Int64 balance = tabbkdetails[num_b].Sol;
                        Boolean a_ret = false;
                        Ch = true;
                        do
                        {
                            Console.Write("\nEntrez le montant a retirer $ : ");
                            wi_drawal = Convert.ToInt64(Console.ReadLine());
                            if (wi_drawal <= 500)
                            {
                                if (wi_drawal <= balance)
                                {
                                    if (wi_drawal >= 20 && wi_drawal % 20 == 0)
                                    {
                                        tabbkdetails[num_b].Sol = tabbkdetails[num_b].Sol - wi_drawal;
                                        a_ret = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLe montant minimum est de 20 $ et un multiple de 20");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nLe montant depasse votre solde");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nLe retrait maximum est de $ 500");
                            }
                                    ;
                        } while (a_ret == false);
                        break;
                    case 3:
                        Ch = true;
                        break;
                }
            } while (Ch == false);

            Console.WriteLine("\n--- la transaction a reussi ---\n");
            Console.WriteLine("Les infos du compte");
            Console.WriteLine("\tNumero : " + tabbkdetails[num_b].number1);
            Console.WriteLine("\tClient : " + tabbkdetails[num_b].name);
            Console.WriteLine("\tNip : " + tabbkdetails[num_b].Nip);
            Console.WriteLine("\tSolde $ : " + tabbkdetails[num_b].Sol);

            StreamWriter myfiles = new StreamWriter("ProjectATM.txt");

            for (Int16 i = 0; i < CLnumber; i++)
            {
                myfiles.WriteLine(tabbkdetails[i].number1);
                myfiles.WriteLine(tabbkdetails[i].name);
                myfiles.WriteLine(tabbkdetails[i].Nip);
                if (i == num_b)
                {
                    myfiles.WriteLine(tabbkdetails[i].Sol);
                }
                else
                {
                    myfiles.WriteLine(tabbkdetails[i].Sol);
                }
            }
            myfiles.Close();
            Console.WriteLine("\nMerci d'avoir utiliser nos services ");
        }
    }


}
