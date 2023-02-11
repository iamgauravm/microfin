using Dapper;
using MicroFIN.Models;
using Microsoft.Data.SqlClient;

namespace MicroFIN.Core.Services;

public interface IReportRepo
{
    Task<List<LedgerViewModel>> GetAllLedgers();
    Task<LedgerCounterViewModel> GetAllLedgerCounter();
    
    
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

    public async Task<LedgerCounterViewModel> GetAllLedgerCounter()
    {
        var sql = "exec dbo.sp_getall_ledgers";
        using (var connection = new SqlConnection(configuration.GetConnectionString("MicroFinConn")))
        {
            connection.Open();
            var result = await connection.QueryAsync<LedgerViewModel>(sql);
            return new LedgerCounterViewModel
            {
                TotalCredit = result.Sum(x=>x.Credit),
                TotalDebit = result.Sum(x=>x.Debit),
                TotalBalance = result.Sum(x=>x.Credit)-result.Sum(x=>x.Debit),
            };
        }
    }
}