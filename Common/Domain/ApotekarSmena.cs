using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class ApotekarSmena : IEntity
    {
        //PODACI IZ BAZE
        public int IdApotekar { get; set; }
        public int IdSmena { get; set; }
        public DateTime Datum { get; set; }

        public string TableName => "ApotekarSmena";

        //JOIN PODACI

        public string ApotekarIme { get; set; }
        public string ApotekarPrezime { get; set; }
        public string NazivSmene { get; set; }
        public TimeSpan? PocetakSmene { get; set; }
        public TimeSpan? KrajSmene { get; set; }

        //FILTERI

        public int? FilterIdApotekar { get; set; }
        public int? FilterIdSmena { get; set; }
        public DateTime? FilterDatum { get; set; }
        public bool UseJoin { get; set; } = false;

        //IEntity IMPLEMENTACIJA
        public string Columns => "idApotekar, idSmena, datumSmene";
        public string ValuesClause => "@IdApotekar, @IdSmena, @Datum";
        public string SetClause => "idApotekar=@IdApotekar, idSmena=@IdSmena, datumSmene=@Datum";

        public string PrimaryKey => "idApotekar, idSmena, datumSmene";

        public string PrimaryKeyCondition => "idApotekar=@IdApotekar AND idSmena=@IdSmena AND datumSmene=@Datum";

        public string? JoinTableName => UseJoin
            ? "ApotekarSmena asm " +
              "JOIN Apotekar a ON asm.idApotekar = a.idApotekar " +
              "JOIN Smena s ON asm.idSmena = s.idSmena"
            : null;

        public string? SelectClaues => UseJoin
            ? "asm.datumSmene AS datumSmene, " +
              "asm.idApotekar AS idApotekar, " +
              "asm.idSmena AS idSmena, " +
              "a.ime AS Ime, " +
              "a.prezime AS Prezime, " +
              "s.nazivSmene AS nazivSmene, " +
              "s.pocetakSmene AS pocetakSmene, " +
              "s.krajSmene AS krajSmene"
            : null;

        public string DisplayValue => $"{IdApotekar} - {IdSmena} - {Datum.ToShortDateString()}";
        public List<SqlParameter> GetSqlParameters()
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdApotekar", IdApotekar),
                new SqlParameter("@IdSmena", IdSmena),
                new SqlParameter("@Datum", Datum)
            };
            return parameters;
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdApotekar", IdApotekar),
                new SqlParameter("@IdSmena", IdSmena),
                new SqlParameter("@Datum", Datum)
            };
            return parameters;
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            string prefix = UseJoin ? "asm." : "";

            if (FilterIdApotekar.HasValue)
            {
                conditions.Add(prefix + "idApotekar = @FilterIdApotekar");
                parameters.Add(new SqlParameter("@FilterIdApotekar", FilterIdApotekar.Value));
            }
            if (FilterIdSmena.HasValue)
            {
                conditions.Add(prefix + "idSmena = @FilterIdSmena");
                parameters.Add(new SqlParameter("@FilterIdSmena", FilterIdSmena.Value));
            }
            if (FilterDatum.HasValue)
            {
                conditions.Add(prefix + "datumSmene = @FilterDatum");
                parameters.Add(new SqlParameter("@FilterDatum", FilterDatum.Value));
            }

            string whereClause = conditions.Count > 0 ? string.Join(" AND ", conditions) : string.Empty;
            return (whereClause, parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();
            while (reader.Read())
            {
                ApotekarSmena smena = new ApotekarSmena
                {
                    Datum = (DateTime)reader["datumSmene"],
                    IdApotekar = (int)reader["idApotekar"],
                    IdSmena = (int)reader["idSmena"]
                };

                if (reader.HasColumn("Ime"))
                {
                    smena.ApotekarIme = reader["Ime"]?.ToString();
                }
                if (reader.HasColumn("Prezime"))
                {
                    smena.ApotekarPrezime = reader["Prezime"]?.ToString();
                }
                if (reader.HasColumn("nazivSmene"))
                {
                    smena.NazivSmene = reader["nazivSmene"]?.ToString();
                }
                if (reader.HasColumn("pocetakSmene") && reader["pocetakSmene"] != DBNull.Value)
                {
                    smena.PocetakSmene = (TimeSpan)reader["pocetakSmene"];
                }
                if (reader.HasColumn("krajSmene") && reader["krajSmene"] != DBNull.Value)
                {
                    smena.KrajSmene = (TimeSpan)reader["krajSmene"];
                }

                list.Add(smena);
            }
            return list;
        }

    }
}
