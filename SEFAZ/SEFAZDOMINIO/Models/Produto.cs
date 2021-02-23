using System;
using System.Collections.Generic;
using System.Text;

namespace SEFAZDOMINIO.Models
{
   public class Produto
    {
        public long Produto_Id { get; set; }
        public long Cod_GTIN { get; set; }
        public DateTime Dat_Emissao { get; set; }
        public string Cod_Tipo_Pagamento { get; set; }
        public long Cod_Produto { get; set; }
        public long Cod_Ncm { get; set; }
        public string Cod_Unidade { get; set; }
        public string Dsc_Produto { get; set; }
        public decimal Vlr_Unitario { get; set; }
        public int Id_Estabelecimento { get; set; }
        public string Nme_Estabelecimento { get; set; }
        public string Nme_Logradouro { get; set; }
        public int Cod_Numero_Logradouro { get; set; }
        public string Nme_Complemento { get; set; }
        public string Nme_Bairro { get; set; }
        public int Cod_Municipio_Ibge { get; set; }
        public string Nme_Municipio { get; set; }
        public string Nme_Sigla_Uf { get; set; }
        public long Cod_Cep { get; set; }
        public string Num_Latitude { get; set; }
        public string Num_Longitude { get; set; }
        public string Url_Maps { get; set; }
    }
}
