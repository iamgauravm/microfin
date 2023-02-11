using Dapper;
using MicroFIN.Models;
using Microsoft.Data.SqlClient;

namespace MicroFIN.Core.Services;

public interface IReportRepo
{
    Task<List<LedgerViewModel>> GetAllLedgers();
}

public class ReportRepo: IReportRepo
{
    private readonly IConfiguration configuration;
    public ReportRepo(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task<List<LedgerViewModel>> GetAllLedgers()
    {
        var sql = "exec dbo.sp_getall_ledgers";
        using (var connection = new SqlConnection(configuration.GetConnectionString("MicroFinConn")))
        {
            connection.Open();
            var result = await connection.QueryAsync<LedgerViewModel>(sql);
            return result.ToList();
        }
    }
}