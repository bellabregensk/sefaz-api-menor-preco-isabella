using Dapper;
using SEFAZDOMINIO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SEFAZDOMINIO
{
    public class SqliteDataAcess
    {
        private static string CarregarConnectionString()
        {
            return @"Data Source=..\..\DB\SEFAZ.db;Version=3;";
        }
        public List<Produto> ConsultarProdutos()
        {
            try
            {
                using (IDbConnection conexao = new SQLiteConnection(CarregarConnectionString()))
                {
                    var saida = conexao.Query<Produto>("SELECT * FROM PRODUTO", new DynamicParameters());
                    return saida.ToList();
                }
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        public List<Produto> ConsultarProdutoPorCodigoGTIN(long codigoGTIN)
        {
            try
            {
                using (IDbConnection conexao = new SQLiteConnection(CarregarConnectionString()))
                {
                    var saida = conexao.Query<Produto>
                   ("SELECT *, MAX(DAT_EMISSAO) FROM(SELECT * FROM PRODUTO WHERE COD_GTIN = " + codigoGTIN + " AND VLR_UNITARIO <> '' AND NUM_LATITUDE <> '' AND NUM_LONGITUDE <> '') GROUP BY ID_ESTABELECIMENTO ORDER BY VLR_UNITARIO", new DynamicParameters());
                    return saida.ToList();
                }
            }
            catch (Exception erro)
            {
                return null;
            }
        }
    }
}
