using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Apotekar : IEntity
    {
        //KOLONE (podaci iz baze)
        public int IdApotekar { get; set; }
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string KorisnickoIme { get; set; } = "";
        public string Sifra { get; set; } = "";
        public string TableName => "Apotekar";

        //FILTERI
        public string? FilterKorisnickoIme { get; set; }
        public string? FilterSifra { get; set; }
        public int? FilterSmenaId { get; set; }

        //IEntity IMPLEMENTACIJA
        public string Columns => "ime, prezime, korisnickoIme, sifra";

        public string ValuesClause => "@Ime, @Prezime, @KorisnickoIme, @Sifra";

        public string SetClause => "ime=@Ime, prezime=@Prezime, korisnickoIme=@KorisnickoIme, sifra=@Sifra";

        public string PrimaryKey => "idApotekar";

        public string PrimaryKeyCondition => "idApotekar=@IdApotekar ";

        //JOIN LOGIKA
        public string? JoinTableName => FilterSmenaId.HasValue
            ? "Apotekar a LEFT JOIN ApotekarSmena asm ON asm.idApotekar = a.idApotekar"
            : null;
        public string DisplayValue => $"{Ime} {Prezime} ({KorisnickoIme})";

        public string? SelectClaues => FilterSmenaId.HasValue
            ? "a.idApotekar, a.ime, a.prezime, a.korisnickoIme, a.sifra"
            : null;

        //WHERE KLAUZULA LOGIKA
        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            string prefix = FilterSmenaId.HasValue ? "a." : "";

            if (IdApotekar > 0)
            {  
                c.Add($"{prefix}idApotekar=@IdApotekar ");
                p.Add(new SqlParameter("@IdApotekar ", IdApotekar));
            }
            if (!string.IsNullOrEmpty(FilterKorisnickoIme))
            {
                c.Add($"{prefix}korisnickoIme=@KorisnickoIme");
                p.Add(new SqlParameter("@KorisnickoIme", FilterKorisnickoIme));
            }
            if (!string.IsNullOrEmpty(FilterSifra))
            {
                c.Add($"{prefix}sifra=@Sifra");
                p.Add(new SqlParameter("@Sifra", FilterSifra));
            }
            if (FilterSmenaId.HasValue)
            {
                c.Add("asm.idSmena=@SmenaId");
                p.Add(new SqlParameter("@SmenaId", FilterSmenaId.Value));
            }

            return (c.Count > 0 ? string.Join(" AND ", c) : "1=1", p);
        }

        //LISTE PARAMETARA
        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Ime", Ime ?? ""),
                new SqlParameter("@Prezime", Prezime ?? ""),
                new SqlParameter("@KorisnickoIme", KorisnickoIme ?? ""),
                new SqlParameter("@Sifra", Sifra ?? "")
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();

            while (reader.Read())
            {
                Apotekar apotekar = new Apotekar
                {
                    IdApotekar = (int)reader["idApotekar"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"]
                };
                list.Add(apotekar);
            }
            return list;
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdApotekar", IdApotekar ),
            };
        }
    }
    
}
