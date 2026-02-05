using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Lek : IEntity
    {
        // PODACI IZ BAZE
        public int IdLek { get; set; }
        public string NazivINN { get; set; }
        public float Cena { get; set; }
        public string Pakovanje { get; set; }  // Nullable
        public int? KolPoPakovanju { get; set; }  // Nullable
        public string Jacina { get; set; }  // Nullable
        public string Proizvodjac { get; set; }  // Nullable
        public string RezimIzdavanja { get; set; }  // Nullable
        public string Indikacija { get; set; }  // Nullable
        public int StanjeMagacin { get; set; }
        public bool AktivanLek { get; set; }
        public string SifraLeka { get; set; }  // Nullable
        public int? MinimalnoStanje { get; set; }  // Nullable
        public DateTime? DatumIsteka { get; set; }  // Nullable

        // FILTERI
        public int? FilterIdLek { get; set; }
        public string FilterNazivINN { get; set; }
        public string FilterProizvodjac { get; set; }
        public bool? FilterAktivanLek { get; set; }
        public int? FilterMinimalnoStanje { get; set; }  // Za upozorenja o niskom stanju
        public bool UseJoin { get; set; } = false;

        // IEntity IMPLEMENTACIJA
        public string TableName => "Lek";

        public string Columns => "nazivINN, cena, pakovanje, kolPoPakovanju, jacina, proizvodjac, rezimIzdavanja, indikacija, stanjeMagacin, aktivanLek, sifraLeka, minimalnoStanje, datumIsteka";

        public string ValuesClause => "@NazivINN, @Cena, @Pakovanje, @KolPoPakovanju, @Jacina, @Proizvodjac, @RezimIzdavanja, @Indikacija, @StanjeMagacin, @AktivanLek, @SifraLeka, @MinimalnoStanje, @DatumIsteka";

        public string SetClause => "nazivINN=@NazivINN, cena=@Cena, pakovanje=@Pakovanje, kolPoPakovanju=@KolPoPakovanju, jacina=@Jacina, proizvodjac=@Proizvodjac, rezimIzdavanja=@RezimIzdavanja, indikacija=@Indikacija, stanjeMagacin=@StanjeMagacin, aktivanLek=@AktivanLek, sifraLeka=@SifraLeka, minimalnoStanje=@MinimalnoStanje, datumIsteka=@DatumIsteka";

        public string PrimaryKey => "idLek";

        public string PrimaryKeyCondition => "idLek=@IdLek";

        public string? JoinTableName => null;  // Nema JOIN-a

        public string? SelectClaues => null;  // Nema JOIN-a

        public string DisplayValue => $"{NazivINN} ({Jacina ?? ""}) - {Proizvodjac ?? ""} - {Cena:F2} RSD";

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdLek", IdLek)
            };
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@NazivINN", NazivINN ?? ""),
                new SqlParameter("@Cena", Cena),
                new SqlParameter("@Pakovanje", Pakovanje ?? (object)DBNull.Value),
                new SqlParameter("@KolPoPakovanju", KolPoPakovanju ?? (object)DBNull.Value),
                new SqlParameter("@Jacina", Jacina ?? (object)DBNull.Value),
                new SqlParameter("@Proizvodjac", Proizvodjac ?? (object)DBNull.Value),
                new SqlParameter("@RezimIzdavanja", RezimIzdavanja ?? (object)DBNull.Value),
                new SqlParameter("@Indikacija", Indikacija ?? (object)DBNull.Value),
                new SqlParameter("@StanjeMagacin", StanjeMagacin),
                new SqlParameter("@AktivanLek", AktivanLek),
                new SqlParameter("@SifraLeka", SifraLeka ?? (object)DBNull.Value),
                new SqlParameter("@MinimalnoStanje", MinimalnoStanje ?? (object)DBNull.Value),
                new SqlParameter("@DatumIsteka", DatumIsteka ?? (object)DBNull.Value)
            };
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            if (FilterIdLek.HasValue)
            {
                c.Add("idLek=@FilterIdLek");
                p.Add(new SqlParameter("@FilterIdLek", FilterIdLek.Value));
            }

            if (!string.IsNullOrEmpty(FilterNazivINN))
            {
                c.Add("nazivINN LIKE @FilterNaziv");
                p.Add(new SqlParameter("@FilterNaziv", $"%{FilterNazivINN}%"));
            }

            if (!string.IsNullOrEmpty(FilterProizvodjac))
            {
                c.Add("proizvodjac LIKE @FilterProizvodjac");
                p.Add(new SqlParameter("@FilterProizvodjac", $"%{FilterProizvodjac}%"));
            }

            if (FilterAktivanLek.HasValue)
            {
                c.Add("aktivanLek=@FilterAktivanLek");
                p.Add(new SqlParameter("@FilterAktivanLek", FilterAktivanLek.Value));
            }

            // Filter za nisko stanje (upozorenje)
            if (FilterMinimalnoStanje.HasValue)
            {
                c.Add("stanjeMagacin <= minimalnoStanje");
            }

            return (c.Count > 0 ? string.Join(" AND ", c) : "", p);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();

            while (reader.Read())
            {
                Lek lek = new Lek
                {
                    IdLek = (int)reader["idLek"],
                    NazivINN = reader["nazivINN"].ToString(),
                    Cena = (float)(double)reader["cena"],
                    StanjeMagacin = (int)reader["stanjeMagacin"],
                    AktivanLek = (bool)reader["aktivanLek"]
                };

                // Nullable polja
                if (reader.HasColumn("pakovanje"))
                    lek.Pakovanje = reader["pakovanje"].ToString();

                if (reader.HasColumn("kolPoPakovanju"))
                    lek.KolPoPakovanju = (int)reader["kolPoPakovanju"];

                if (reader.HasColumn("jacina"))
                    lek.Jacina = reader["jacina"].ToString();

                if (reader.HasColumn("proizvodjac"))
                    lek.Proizvodjac = reader["proizvodjac"].ToString();

                if (reader.HasColumn("rezimIzdavanja"))
                    lek.RezimIzdavanja = reader["rezimIzdavanja"].ToString();

                if (reader.HasColumn("indikacija"))
                    lek.Indikacija = reader["indikacija"].ToString();

                if (reader.HasColumn("sifraLeka"))
                    lek.SifraLeka = reader["sifraLeka"].ToString();

                if (reader.HasColumn("minimalnoStanje"))
                    lek.MinimalnoStanje = (int)reader["minimalnoStanje"];

                if (reader.HasColumn("datumIsteka"))
                    lek.DatumIsteka = (DateTime)reader["datumIsteka"];

                list.Add(lek);
            }

            return list;
        }
    }
}
