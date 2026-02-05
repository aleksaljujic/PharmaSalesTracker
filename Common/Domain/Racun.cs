using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Racun : IEntity
    {
        // PODACI IZ BAZE
        public int IdRacun { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime? RokPlacanja { get; set; }  // Nullable
        public float? Pdv { get; set; }  // Nullable
        public float UkupanIznos { get; set; }
        public int? IdApotekar { get; set; }  // Nullable
        public int? IdKupac { get; set; }  // Nullable
        public string NacinPlacanja { get; set; }  // Nullable
        public string StatusRacuna { get; set; }  // Nullable
        public string Napomena { get; set; }  // Nullable
        public string BrojRacuna { get; set; }  // Nullable

        // JOIN PODACI - Apotekar
        public string ApotekarIme { get; set; }
        public string ApotekarPrezime { get; set; }

        // JOIN PODACI - Kupac
        public string KupacIme { get; set; }
        public string KupacPrezime { get; set; }

        // JOIN PODACI - Stavke računa (lista)
        public List<StavkaRacuna> Stavke { get; set; }

        // FILTERI
        public int? FilterIdRacun { get; set; }
        public DateTime? FilterDatumIzdavanjaOd { get; set; }
        public DateTime? FilterDatumIzdavanjaDo { get; set; }
        public int? FilterIdApotekar { get; set; }
        public int? FilterIdKupac { get; set; }
        public string FilterStatusRacuna { get; set; }
        public bool UseJoin { get; set; } = false;

        // IEntity IMPLEMENTACIJA
        public string TableName => "Racun";

        public string Columns => "datumIzdavanja, rokPlacanja, pdv, ukupanIznos, idApotekar, idKupac, nacinPlacanja, statusRacuna, napomena, brojRacuna";

        public string ValuesClause => "@DatumIzdavanja, @RokPlacanja, @Pdv, @UkupanIznos, @IdApotekar, @IdKupac, @NacinPlacanja, @StatusRacuna, @Napomena, @BrojRacuna";

        public string SetClause => "datumIzdavanja=@DatumIzdavanja, rokPlacanja=@RokPlacanja, pdv=@Pdv, ukupanIznos=@UkupanIznos, idApotekar=@IdApotekar, idKupac=@IdKupac, nacinPlacanja=@NacinPlacanja, statusRacuna=@StatusRacuna, napomena=@Napomena, brojRacuna=@BrojRacuna";

        public string PrimaryKey => "idRacun";

        public string PrimaryKeyCondition => "idRacun=@IdRacun";

        public string? JoinTableName => UseJoin
            ? "Racun r " +
              "LEFT JOIN Apotekar a ON r.idApotekar = a.idApotekar " +
              "LEFT JOIN Kupac k ON r.idKupac = k.idKupac"
            : null;

        public string? SelectClaues => UseJoin
            ? "r.idRacun, r.datumIzdavanja, r.rokPlacanja, r.pdv, r.ukupanIznos, " +
              "r.idApotekar, r.idKupac, r.nacinPlacanja, r.statusRacuna, " +
              "r.napomena, r.brojRacuna, " +
              "a.ime AS apotekarIme, a.prezime AS apotekarPrezime, " +
              "k.ime AS kupacIme, k.prezime AS kupacPrezime"
            : null;

        public string DisplayValue => $"Račun #{BrojRacuna ?? IdRacun.ToString()} - {DatumIzdavanja:dd.MM.yyyy} - {UkupanIznos:F2} RSD";

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdRacun", IdRacun)
            };
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@DatumIzdavanja", DatumIzdavanja),
                new SqlParameter("@RokPlacanja", RokPlacanja),
                new SqlParameter("@Pdv", Pdv),
                new SqlParameter("@UkupanIznos", UkupanIznos),
                new SqlParameter("@IdApotekar", IdApotekar),
                new SqlParameter("@IdKupac", IdKupac),
                new SqlParameter("@NacinPlacanja", NacinPlacanja),
                new SqlParameter("@StatusRacuna", StatusRacuna),
                new SqlParameter("@Napomena", Napomena ?? (object)DBNull.Value),
                new SqlParameter("@BrojRacuna", BrojRacuna)
            };
        }

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var c = new List<string>();
            var p = new List<SqlParameter>();

            string prefix = UseJoin ? "r." : "";

            if (FilterIdRacun.HasValue)
            {
                c.Add($"{prefix}idRacun=@FilterIdRacun");
                p.Add(new SqlParameter("@FilterIdRacun", FilterIdRacun.Value));
            }

            if (FilterDatumIzdavanjaOd.HasValue)
            {
                c.Add($"{prefix}datumIzdavanja >= @FilterDatumOd");
                p.Add(new SqlParameter("@FilterDatumOd", FilterDatumIzdavanjaOd.Value));
            }

            if (FilterDatumIzdavanjaDo.HasValue)
            {
                c.Add($"{prefix}datumIzdavanja <= @FilterDatumDo");
                p.Add(new SqlParameter("@FilterDatumDo", FilterDatumIzdavanjaDo.Value));
            }

            if (FilterIdApotekar.HasValue)
            {
                c.Add($"{prefix}idApotekar=@FilterIdApotekar");
                p.Add(new SqlParameter("@FilterIdApotekar", FilterIdApotekar.Value));
            }

            if (FilterIdKupac.HasValue)
            {
                c.Add($"{prefix}idKupac=@FilterIdKupac");
                p.Add(new SqlParameter("@FilterIdKupac", FilterIdKupac.Value));
            }

            if (!string.IsNullOrEmpty(FilterStatusRacuna))
            {
                c.Add($"{prefix}statusRacuna LIKE @FilterStatus");
                p.Add(new SqlParameter("@FilterStatus", $"%{FilterStatusRacuna}%"));
            }

            return (c.Count > 0 ? string.Join(" AND ", c) : "", p);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> list = new List<IEntity>();

            while (reader.Read())
            {
                Racun racun = new Racun
                {
                    IdRacun = (int)reader["idRacun"],
                    DatumIzdavanja = (DateTime)reader["datumIzdavanja"],
                    UkupanIznos = (float)(double)reader["ukupanIznos"]
                };

                // Nullable polja
                if (reader.HasColumn("rokPlacanja"))
                    racun.RokPlacanja = (DateTime)reader["rokPlacanja"];

                if (reader.HasColumn("pdv"))
                    racun.Pdv = (float)(double)reader["pdv"];

                if (reader.HasColumn("idApotekar"))
                    racun.IdApotekar = (int)reader["idApotekar"];

                if (reader.HasColumn("idKupac"))
                    racun.IdKupac = (int)reader["idKupac"];

                if (reader.HasColumn("nacinPlacanja"))
                    racun.NacinPlacanja = reader["nacinPlacanja"].ToString();

                if (reader.HasColumn("statusRacuna"))
                    racun.StatusRacuna = reader["statusRacuna"].ToString();


                if (reader.HasColumn("napomena"))
                    racun.Napomena = reader["napomena"].ToString();

                if (reader.HasColumn("brojRacuna"))
                    racun.BrojRacuna = reader["brojRacuna"].ToString();

                // JOIN podaci
                try
                {
                    if (reader.GetOrdinal("apotekarIme") >= 0 && reader["apotekarIme"] != DBNull.Value)
                    {
                        racun.ApotekarIme = reader["apotekarIme"].ToString();
                        racun.ApotekarPrezime = reader["apotekarPrezime"]?.ToString();
                    }
                }
                catch { }

                try
                {
                    if (reader.GetOrdinal("kupacIme") >= 0 && reader["kupacIme"] != DBNull.Value)
                    {
                        racun.KupacIme = reader["kupacIme"].ToString();
                        racun.KupacPrezime = reader["kupacPrezime"]?.ToString();
                    }
                }
                catch { }

                list.Add(racun);
            }

            return list;
        }
    }
}
