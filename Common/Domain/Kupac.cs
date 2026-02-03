using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Kupac : IEntity
    {
        //PODACI IZ BAZE
        public int IdKupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public int IdLokacija { get; set; }

        //JOIN PODACI
        public string NazivLokacije { get; set; }

        //FILTERI
        public int? FilterIdKupac { get; set; }
        public string? FilterIme { get; set; }
        public string? FilterPrezime { get; set; }
        public int? FilterIdLokacija { get; set; }
        public bool UseJoin { get; set; } = false;

        //IEntity IMPLEMENTACIJA
        public string TableName => "Kupac";

        public string Columns => "ime, prezime, email, adresa, brojTelefona, idLokacija";

        public string ValuesClause => "@Ime, @Prezime, @Email, @Adresa, @BrojTelefona, @IdLokacija";

        public string SetClause => "ime=@Ime, prezime=@Prezime, email=@Email, adresa=@Adresa, brojTelefona=@BrojTelefona, idLokacija=@IdLokacija";

        public string PrimaryKey => "idKupac";

        public string PrimaryKeyCondition => "idKupac=@IdKupac";

        public string? JoinTableName => UseJoin
            ? "Kupac k LEFT JOIN Grad g ON k.idLokacija = g.idLokacija"
            : null;

        public string? SelectClaues => UseJoin
            ? "k.idKupac, k.ime, k.prezime, k.email, k.adresa, k.brojTelefona, g.naziv"
            : null;

        public string DisplayValue => $"{Ime} {Prezime} ({BrojTelefona}) {NazivLokacije}";

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdKupac", IdKupac)
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();

            while(reader.Read())
            {
                Kupac kupac = new Kupac
                {
                    IdKupac = (int)reader["idKupac"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Email = (string)reader["email"],
                    Adresa = (string)reader["adresa"],
                    BrojTelefona = (string)reader["brojTelefona"]
                };

                if(reader.HasColumn("Ime"))
                {
                    kupac.Ime = (string)reader["Ime"];
                }
                if (reader.HasColumn("Prezime"))
                {
                    kupac.Prezime = (string)reader["Prezime"];
                }
                if (reader.HasColumn("email"))
                {
                    kupac.Email = (string)reader["email"];
                }
                if (reader.HasColumn("adresa"))
                {
                    kupac.Adresa = (string)reader["adresa"];
                }
                if (reader.HasColumn("brojTelefona"))
                {
                    kupac.BrojTelefona = (string)reader["brojTelefona"];
                }
                if(reader.HasColumn("naziv"))
                {
                    kupac.NazivLokacije = (string)reader["naziv"];
                }
                list.Add(kupac);
            }
            return list;    
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Ime", Ime ?? ""),
                new SqlParameter("@Prezime", Prezime ?? ""),
                new SqlParameter("@Email", Email ?? ""),
                new SqlParameter("@Adresa", Adresa ?? ""),
                new SqlParameter("@BrojTelefona", BrojTelefona ?? ""),
                new SqlParameter("@IdLokacija", IdLokacija)
            };
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            string prefix = FilterIdLokacija.HasValue ? "k." : "";

            if(IdKupac > 0)
            {
                c.Add($"{prefix}idKupac=@IdKupac");
                p.Add(new SqlParameter("@IdKupac", IdKupac));
            }
            if (!string.IsNullOrEmpty(FilterIme))
            {
                c.Add($"{prefix}ime LIKE @Ime");
                p.Add(new SqlParameter("@Ime", $"%{FilterIme}%"));
            }
            if (!string.IsNullOrEmpty(FilterPrezime))
            {
                c.Add($"{prefix}prezime LIKE @Prezime");
                p.Add(new SqlParameter("@Prezime", $"%{FilterPrezime}%"));
            }
            if (FilterIdLokacija.HasValue)
            {
                c.Add($"g.idLokacija = @IdLokacija");
                p.Add(new SqlParameter("@IdLokacija", FilterIdLokacija.Value));
            }

            return (c.Count > 0 ? string.Join(" AND ", c) : "1=1", p);
        }
    }
}
