using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Lokacija : IEntity
    {
        //PODACI IZ BAZE
        public int IdLokacija { get; set; }
        public string Naziv { get; set; }
        public string Region { get; set; }
        public string Drzava { get; set; }
        public string PostanskiBroj { get; set; }

        //FILTERI
        public int? FilterIdLokacija { get; set; }
        public string? FilterNaziv { get; set; }

        //IEntity implementation
        public string TableName => "Grad";

        public string Columns => "idLokacija, naziv, region, drzava, postanskiBroj";

        public string ValuesClause => "@IdLokacija, @Naziv, @Region, @Drzava, @PostanskiBroj";

        public string SetClause => "idLokacija=@IdLokacija, naziv=@Naziv, region=@Region, drzava=@Drzava, postanskiBroj=@PostanskiBroj";

        public string PrimaryKey => "idLokacija";

        public string PrimaryKeyCondition => "idLokacija=@IdLokacija";

        public string? JoinTableName => null;

        public string? SelectClaues => null;

        public string DisplayValue => $"{Naziv}, {Drzava}";

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdLokacija", IdLokacija)
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lokacije = new List<IEntity>();
            while (reader.Read())
            {
                Lokacija lokacija = new Lokacija
                {
                    IdLokacija = (int)reader["idLokacija"],
                    Naziv = (string)reader["naziv"],
                    Region = (string)reader["region"],
                    Drzava = (string)reader["drzava"],
                    PostanskiBroj = (string)reader["postanskiBroj"]
                };
                if(reader.HasColumn("Naziv"))
                {
                    lokacija.Naziv = (string)reader["Naziv"];
                }
                if (reader.HasColumn("Region"))
                {
                    lokacija.Region = (string)reader["Region"];
                }
                if (reader.HasColumn("Drzava"))
                {
                    lokacija.Drzava = (string)reader["Drzava"];
                }
                if(reader.HasColumn("PostanskiBroj"))
                {
                    lokacija.PostanskiBroj = (string)reader["PostanskiBroj"];
                }
                lokacije.Add(lokacija);
            }
            
            return lokacije;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Naziv", Naziv),
                new SqlParameter("@Region", Region),
                new SqlParameter("@Drzava", Drzava),
                new SqlParameter("@PostanskiBroj", PostanskiBroj)
            };
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            if(IdLokacija > 0)
            {
                c.Add("idLokacija=@IdLokacija");
                p.Add(new SqlParameter("@IdLokacija", IdLokacija));
            }
            if (FilterIdLokacija.HasValue)
            {
                c.Add("idLokacija=@IdLokacija");
                p.Add(new SqlParameter("@IdLokacija", FilterIdLokacija.Value));
            }
            if (!string.IsNullOrEmpty(FilterNaziv))
            {
                c.Add("naziv LIKE '%' + @Naziv + '%'");
                p.Add(new SqlParameter("@Naziv", FilterNaziv));
            }
            return (c.Count > 0 ? string.Join(" AND ", c) : string.Empty, p);
        }
    }
}
