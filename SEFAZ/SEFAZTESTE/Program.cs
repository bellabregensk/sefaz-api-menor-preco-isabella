using System;
using SEFAZDOMINIO;

namespace SEFAZTESTE
{
    public  class Program
    {
        static void Main(string[] args)
        {
            SqliteDataAcess dataAcess = new SqliteDataAcess();
            dataAcess.ConsultarProdutos();
        }
    }
}
