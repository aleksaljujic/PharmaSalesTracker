using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class StavkaRacuna : IEntity
    {
        // PODACI IZ BAZE - Composite Primary Key (rb, idRacun, idLek)
        public int Rb { get; set; }  // Redni broj (deo PK)
        public int IdRacun { get; set; }  // FK + deo PK
        public int IdLek { get; set; }  // FK + deo PK

        public float Cena { get; set; }
        public int Kolicina { get; set; }
        public float Iznos { get; set; }
        public float? PopustProcenat { get; set; }  // Nullable
        public float? KonacnaCena { get; set; }  // Nullable

        // JOIN PODACI - Lek
        public string NazivLeka { get; set; }
        public float? CenaLeka { get; set; }
        public string Pakovanje { get; set; }
        public string JacinaLeka { get; set; }
        public string ProizvodjacLeka { get; set; }
        public string LekDisplayValue => $"{NazivLeka} ({JacinaLeka ?? ""}) - {ProizvodjacLeka ?? ""} - {CenaLeka:F2} RSD";

        // FILTERI
        public int? FilterIdRacun { get; set; }
        public int? FilterIdLek { get; set; }
        public bool UseJoin { get; set; } = false;

        // IEntity IMPLEMENTACIJA
        public string TableName => "StavkaRacuna";

        public string Columns => "rb, idRacun, idLek, cena, kolicina, iznos, popustProcenat, konacnaCena";

        public string ValuesClause => "@Rb, @IdRacun, @IdLek, @Cena, @Kolicina, @Iznos, @PopustProcenat, @KonacnaCena";

        public string SetClause => "cena=@Cena, kolicina=@Kolicina, iznos=@Iznos, popustProcenat=@PopustProcenat, konacnaCena=@KonacnaCena";

        public string PrimaryKey => "rb, idRacun, idLek";

        public string PrimaryKeyCondition => "rb=@Rb AND idRacun=@IdRacun AND idLek=@IdLek";

        public string? JoinTableName => UseJoin
            ? "StavkaRacuna sr " +
              "LEFT JOIN Lek l ON sr.idLek = l.idLek"
            : null;

        public string? SelectClaues => UseJoin
            ? "sr.rb, sr.idRacun, sr.idLek, sr.cena, sr.kolicina, sr.iznos, " +
              "sr.popustProcenat, sr.konacnaCena, " +
              "l.nazivINN AS nazivLeka, l.cena AS cenaLeka, l.pakovanje, " +
              "l.jacina AS jacinaLeka, l.proizvodjac AS proizvodjacLeka"
            : null;

        public string DisplayValue => $"Stavka {Rb}: {NazivLeka ?? "Lek"} x {Kolicina} = {Iznos:F2} RSD";

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Rb", Rb),
                new SqlParameter("@IdRacun", IdRacun),
                new SqlParameter("@IdLek", IdLek)
            };
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Rb", Rb),
                new SqlParameter("@IdRacun", IdRacun),
                new SqlParameter("@IdLek", IdLek),
                new SqlParameter("@Cena", Cena),
                new SqlParameter("@Kolicina", Kolicina),
                new SqlParameter("@Iznos", Iznos),
                new SqlParameter("@PopustProcenat", PopustProcenat),
                new SqlParameter("@KonacnaCena", KonacnaCena)
            };
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            string prefix = UseJoin ? "sr." : "";

            if (FilterIdRacun.HasValue)
            {
                c.Add($"{prefix}idRacun=@FilterIdRacun");
                p.Add(new SqlParameter("@FilterIdRacun", FilterIdRacun.Value));
            }

            if (FilterIdLek.HasValue)
            {
                c.Add($"{prefix}idLek=@FilterIdLek");
                p.Add(new SqlParameter("@FilterIdLek", FilterIdLek.Value));
            }

            return (c.Count > 0 ? string.Join(" AND ", c) : "", p);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();

            while (reader.Read())
            {
                StavkaRacuna stavka = new StavkaRacuna
                {
                    Rb = (int)reader["rb"],
                    IdRacun = (int)reader["idRacun"],
                    IdLek = (int)reader["idLek"],
                    Cena = (float)(double)reader["cena"],
                    Kolicina = (int)reader["kolicina"],
                    Iznos = (float)(double)reader["iznos"]
                };

                // Nullable polja
                if (reader.HasColumn("popustProcenat"))
                    stavka.PopustProcenat = (float)(double)reader["popustProcenat"];

                if (reader.HasColumn("konacnaCena"))
                    stavka.KonacnaCena = (float)(double)reader["konacnaCena"];

                // JOIN podaci - Lek
                try
                {
                    // JOIN podaci - Lek
                    if (reader.HasColumn("nazivLeka"))
                    {
                        stavka.NazivLeka = reader["nazivLeka"].ToString();
                    }

                    if (reader.HasColumn("cenaLeka"))
                    {
                        stavka.CenaLeka = (float)(double)reader["cenaLeka"];
                    }

                    if (reader.HasColumn("pakovanje"))
                    {
                        stavka.Pakovanje = reader["pakovanje"].ToString();
                    }

                    if (reader.HasColumn("jacinaLeka"))
                    {
                        stavka.JacinaLeka = reader["jacinaLeka"].ToString();
                    }

                    if (reader.HasColumn("proizvodjacLeka"))
                    {
                        stavka.ProizvodjacLeka = reader["proizvodjacLeka"].ToString();
                    }
                }
                catch { }

                list.Add(stavka);
            }

            return list;
        }
    }
}
