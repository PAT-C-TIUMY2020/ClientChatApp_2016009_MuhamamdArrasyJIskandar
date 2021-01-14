using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatApp_2016009_MuhamamdArrasyJIskandar
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new ClientCallBack());
            ServiceReference1.ServiceCallbackClient server = new ServiceReference1.ServiceCallbackClient(context);
            Console.WriteLine("Enter Username");
            string nama = Console.ReadLine();
            server.gabung(nama);

            Console.WriteLine("Kirim Pesan");
            string pesan = Console.ReadLine();

            while (true)
            {
                if (!string.IsNullOrEmpty(pesan))
                    server.kirimPesan(pesan);
                Console.WriteLine("Kirim Pesan");
                pesan = Console.ReadLine();
            }
        }
    }
    public class ClientCallBack : ServiceReference1.IServiceCallbackCallback
    {
        public void pesanKirim(string user, string pesan)
        {
            Console.WriteLine("{0}: {1}", user, pesan);
        }
    }

}