using System.Data;
using System;
using System.Data.SqlClient;

partial class Program
{
    static void Main(string[] args)
    {
        // Параметры подключения к базе данных
        string connectionString = "Server=findb-stg.o3.ru;Database=Metazon;User Id=yandreychenko';Password=Liza2019(;";

        // Параметры для хранимой процедуры
        DateTime dateFrom = new DateTime(2024, 8, 1);
        DateTime dateTo = new DateTime(2024, 8, 10);

        // Пример значений для ContractTypes
        DataTable contractTypes = new DataTable();
        contractTypes.Columns.Add("Value", typeof(string));
        contractTypes.Rows.Add("ContractMaterials");
        contractTypes.Rows.Add("ContractDebtAgreementForApvz");

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.ContractTypeGeneralCountDetailForService", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметры
                    command.Parameters.AddWithValue("@DateFrom", dateFrom);
                    command.Parameters.AddWithValue("@DateTO", dateTo);

                    // Добавляем параметр для таблицы
                    SqlParameter contractTypesParam = command.Parameters.AddWithValue("@ContractTypes", contractTypes);
                    contractTypesParam.SqlDbType = SqlDbType.Structured;
                    contractTypesParam.TypeName = "dbo.StringTable"; // Убедитесь, что это имя типа совпадает с тем, что в БД

                    // Выполняем команду и получаем данные
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Чтение данных из результата
                            int contractID = reader.GetInt32(reader.GetOrdinal("ContractID"));
                            int? parentID = reader.IsDBNull(reader.GetOrdinal("ParentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParentID"));
                            string sysName = reader.GetString(reader.GetOrdinal("SysName"));
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            DateTime createDate = reader.GetDateTime(reader.GetOrdinal("CreateDate"));
                            DateTime? updateDate = reader.IsDBNull(reader.GetOrdinal("UpdateDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("UpdateDate"));
                            string state = reader.GetString(reader.GetOrdinal("State"));
                            DateTime contractDate = reader.GetDateTime(reader.GetOrdinal("ContractDate"));
                            DateTime? stopDate = reader.IsDBNull(reader.GetOrdinal("StopDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("StopDate"));
                            string contractNum = reader.GetString(reader.GetOrdinal("ContractNum"));
                            int contractorID = reader.GetInt32(reader.GetOrdinal("ContractorID"));
                            string contractorShortName = reader.GetString(reader.GetOrdinal("ContractorShortName"));
                            string contractorINN = reader.GetString(reader.GetOrdinal("ContractorINN"));
                            string contractorOKCode = reader.GetString(reader.GetOrdinal("ContractorOKCode"));
                            int? selfPersonID = reader.IsDBNull(reader.GetOrdinal("SelfPersonID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SelfPersonID"));
                            string selfPersonName = reader.IsDBNull(reader.GetOrdinal("SelfPersonName")) ? null : reader.GetString(reader.GetOrdinal("SelfPersonName"));
                            string descript = reader.IsDBNull(reader.GetOrdinal("Descript")) ? null : reader.GetString(reader.GetOrdinal("Descript"));

                            // Выводим полученные данные на консоль
                            Console.WriteLine($"ContractID: {contractID}, Name: {name}, ContractorShortName: {contractorShortName}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
