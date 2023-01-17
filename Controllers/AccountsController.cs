
using MicroFIN.Core;
using MicroFIN.Core.Contracts;
using MicroFIN.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Controllers;
[Route("accounts")]
public class AccountsController : ControllerBase
{
    private readonly ILogger<AccountsController> _logger;
    private readonly IMicroFinDbContext _context;

    public AccountsController(ILogger<AccountsController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet("getall/{type}")]
    public async Task<ResponseObject<IEnumerable<AccountViewModel>>> GetAll(AccountType type)
    {
        return new ResponseObject<IEnumerable<AccountViewModel>>(
            (await _getAll(type))
            .Select(x => new AccountViewModel
            {
                Id = x.Id,
                Name = x.AccountName,
                Address = x.Address ?? "-",
                Mobile = x.Mobile ?? "",
                Remarks = x.Remarks ?? "",
                Business = x.BusinessName,
                FatherName = x.FatherName,
                AccountTypeId = (int)x.AccountType,
                AccountType = x.AccountType.ToString(),
                AvailableFunds = x.AvailableFunds,
                TotalFunding = x.TotalFunding,
                TotalRecovery = x.TotalRecovery,
                TotalWithdrawal = x.TotalWithdrawal
            }).ToList().OrderByDescending(c=>c.Id));
    }
   
    [HttpGet("get/{type}/{id}")]
    public async Task<ResponseObject<AccountViewModel>> GetById(AccountType type,int id)
    {
        var account = await _getById(type, id);
        return new ResponseObject<AccountViewModel>(new AccountViewModel
            {
                Id = account.Id,
                Name = account.AccountName,
                Address = account.Address ?? "-",
                Mobile = account.Mobile ?? "",
                Remarks = account.Remarks ?? "",
                Business = account.BusinessName,
                FatherName = account.FatherName,
                AccountTypeId = (int)account.AccountType,
                AccountType = account.AccountType.ToString(),
                AvailableFunds = account.AvailableFunds,
                TotalFunding = account.TotalFunding,
                TotalRecovery = account.TotalRecovery,
                TotalWithdrawal = account.TotalWithdrawal
            });
    }
    
    [HttpPost("createOrUpdate/{type}")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(AccountViewModel model,AccountType type)
    {
        return new ResponseObject<bool>(await _save(type, new Account
        {
            AccountName = model.Name,
            FatherName = model.FatherName,
            BusinessName = model.Business,
            Address = model.Address ?? "-",
            Mobile = model.Mobile ?? "",
            Remarks = model.Remarks ?? "",
            Id = model.Id,
        }));
    }
    
    [HttpPost("delete/{type}/{id}")]
    public async Task<ResponseObject<bool>> AgentDelete(int id,AccountType type)
    {
        var agent = await _deleteById(type,id);
        if (agent == false)
        {
            return new ResponseObject<bool>(false,false,$"{type.ToString()} is not found.");
        }
        return new ResponseObject<bool>(true);
    }
    
    
    // [HttpGet("investors/getall")]
    // public async Task<ResponseObject<IEnumerable<AgentViewRequest>>> InvestorGetAll()
    // {
    //     return new ResponseObject<IEnumerable<AgentViewRequest>>(
    //         (await _getAll(AccountType.Investor))
    //         .Select(x => new AgentViewRequest
    //         {
    //             Id = x.Id,
    //             Name = x.AccountName,
    //             Address = x.Address ?? "-",
    //             Mobile = x.Mobile ?? "",
    //             Remarks = x.Remarks ?? ""
    //         }).ToList());
    // }
    //
    // [HttpGet("investors/get/{id}")]
    // public async Task<ResponseObject<AgentViewRequest>> InvestorGetById(int id)
    // {
    //     var account = await _getById(AccountType.Investor, id);
    //     return new ResponseObject<AgentViewRequest>(new AgentViewRequest
    //     {
    //         Id = account.Id,
    //         Name = account.AccountName,
    //         Address = account.Address ?? "-",
    //         Mobile = account.Mobile ?? "",
    //         Remarks = account.Remarks ?? ""
    //     });
    // }
    //
    // [HttpPost("investors/createOrUpdate")]
    // public async Task<ResponseObject<bool>> InvestorCreateOrUpdate(AgentViewRequest model)
    // {
    //     return new ResponseObject<bool>(await _save(AccountType.Investor, new Account
    //     {
    //         AccountName = model.Name,
    //         Mobile = model.Mobile,
    //         Address = model.Address,
    //         Remarks = model.Remarks,
    //         Id = model.Id
    //     }));
    // }
    //
    // [HttpPost("investors/delete/{id}")]
    // public async Task<ResponseObject<bool>> Investorelete(int id)
    // {
    //     var agent = await _deleteById(AccountType.Investor,id);
    //     if (agent == false)
    //     {
    //         return new ResponseObject<bool>(false,false,"Investor is not found.");
    //     }
    //     return new ResponseObject<bool>(true);
    // }


    private async Task<IEnumerable<Account>> _getAll(AccountType _accountType)
    {
        return await _context.Accounts
            .Where(f => 
                f.AccountType == _accountType
                && f.IsActive == true
                && f.IsDefault == false)
            .ToListAsync();
    }
    private async Task<Account> _getById(AccountType _accountType,int id)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(f => f.AccountType == _accountType 
                                      && f.ParentAccountId == (int)_accountType 
                                      && f.Id==id 
                                      && f.IsDefault == false
                                      && f.IsActive == true);
    }
    private async Task<bool> _save(AccountType _accountType, Account model)
    {
        try
        {
            var account = await _getById(_accountType,model.Id);
            if (account == null)
            {
                account = new Account
                {
                    Address = model.Address,
                    Mobile = model.Mobile,
                    AccountName = model.AccountName,
                    IsActive = true,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 2,
                    ModifiedOn = DateTime.Now,
                    Id = 0,

                    AccountType = _accountType,
                    AccountTypeText = _accountType.ToString(),
                    ParentAccountId = (int)_accountType,
                    Remarks = model.Remarks,
                    AvailableFunds = 0,
                    BusinessName = model.BusinessName??"",
                    CreditScore = model.CreditScore??0,
                    FatherName = model.FatherName??"",
                    // IsCash = account.IsCash,
                    // IsDefault = account.IsDefault,
                    TotalFunding = model.TotalFunding,
                    TotalRecovery = model.TotalRecovery,
                    TotalWithdrawal = model.TotalFunding,
                    
                };
                _context.Accounts.Add(account);
            }
            else
            {
                account.AccountName = model.AccountName;
                account.FatherName = model.FatherName ?? "";
                account.Mobile = model.Mobile;
                account.Address = model.Address;
                account.BusinessName = model.BusinessName ?? "";
                account.Remarks = model.Remarks;
                account.TotalFunding = model.TotalFunding;
                account.TotalRecovery = model.TotalRecovery;
                account.TotalWithdrawal = model.TotalFunding;
                account.ModifiedBy = 2;
                account.ModifiedOn = DateTime.Now;
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    private async Task<bool> _deleteById(AccountType _accountType,int id)
    {
        try
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(f => 
                    f.AccountType == _accountType
                    && f.ParentAccountId == (int)_accountType 
                    && f.IsDefault == false
                    && f.IsActive == true);
            if (account == null)
            {
                return false;
            }
            account.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }


    #region Diaries

    [HttpGet("/diary/avaliblereferences")]
    public async Task<ResponseObject<IEnumerable<AccountViewModel>>> GetAllAvalibleReferences(AccountType type)
    {

        var data = await _context.Accounts
            .Where(x => x.IsActive == true
                        && x.IsDefault == false 
                        && x.ParentAccountId > 0
                        && (x.AccountType==AccountType.Investor || x.AccountType==AccountType.Diary)
                        && x.AvailableFunds>0)
            .ToArrayAsync();
        
        
        
        return new ResponseObject<IEnumerable<AccountViewModel>>(
            (data.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Name = x.AccountName,
                Address = x.Address ?? "-",
                Mobile = x.Mobile ?? "",
                Remarks = x.Remarks ?? "",
                Business = x.BusinessName,
                FatherName = x.FatherName,
                AccountTypeId = (int)x.AccountType,
                AccountType = x.AccountType.ToString(),
                AvailableFunds = x.AvailableFunds,
                TotalFunding = x.TotalFunding,
                TotalRecovery = x.TotalRecovery,
                TotalWithdrawal = x.TotalWithdrawal
            })));
    }
    
    [HttpGet("/diary/schemes")]
    public async Task<ResponseObject<IEnumerable<InstallmentSchemeViewModel>>> GetAllSchemes()
    {

        var data = await _context.InstallmentSchemes
            .Where(x => x.IsActive == true)
            .ToArrayAsync();

        return new ResponseObject<IEnumerable<InstallmentSchemeViewModel>>(
            (data.Select(x => new InstallmentSchemeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                InstallmentCount = x.InstallmentCount,
                RateInterest = x.RateInterest
            })));
    }
    
    [HttpPost("/diary/create")]
    public async Task<ResponseObject<bool>> Create(CreateDiaryRequest model)
    {
        var _res = new ResponseObject<bool>(false);
        // Create diary
        var diary = await _context.Dairies.FirstOrDefaultAsync(x => x.DiaryNumber == model.DiaryNumber && x.IsActive == true);
        if (diary == null)
        {
            var customer = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == model.CustomerId && x.IsActive == true);
            var scheme = await _context.InstallmentSchemes.FirstOrDefaultAsync(x => x.Id == model.SchemeId && x.IsActive == true);
            if (customer != null)
            {
                diary = new Diary();
                diary.Id = 0;
                diary.Installment = scheme.InstallmentCount;
                diary.AccountId = 0; // new diary account id
                diary.AgentId = model.AgentId;
                diary.CustomerId = customer.Id;
                diary.DiaryNumber = model.DiaryNumber;
                diary.StartDate = model.DiaryStartDate.AddDays(1);
                diary.EndDate = model.DiaryStartDate.AddDays(scheme.InstallmentCount);
                diary.InstallmentSchemeId = model.SchemeId;
                diary.IsCompleted = false;
                diary.LoanAmount = model.LoanAmount;
                diary.RecoveryAmount = Convert.ToDouble(Math.Round((decimal)model.LoanAmount + ((decimal)model.LoanAmount * scheme.RateInterest/100),0));
                diary.TotalBalanceAmount = diary.RecoveryAmount;
                diary.TotalPaidAmount = 0;
                diary.IsActive = true;
                diary.CreatedBy = 2;
                diary.CreatedOn = DateTime.Now;
                diary.ModifiedBy = 2;
                diary.ModifiedOn = DateTime.Now;
                
                await _context.Dairies.AddAsync(diary);
                await _context.SaveChangesAsync();
                
                // Create diary account in account tables
                var account = new Account
                {
                    Id = 0,
                    AccountName = $"Diary# {model.DiaryNumber}",
                    AccountType = AccountType.Diary,
                    AccountTypeText = AccountType.Diary.ToString(),
                    ParentAccountId = (int)AccountType.Diary,
                    AvailableFunds = 0,
                    TotalFunding = diary.LoanAmount,
                    TotalRecovery = diary.RecoveryAmount,
                    TotalWithdrawal = 0,
                    IsActive = true,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 2,
                    ModifiedOn = DateTime.Now,
                    Address = "",
                    Mobile = "",
                    Remarks = "",
                    BusinessName = "",
                    CreditScore = 0,
                    FatherName = "",
                    IsDefault = false,
                    IsCash = false
                };
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                diary.AccountId = account.Id;
                await _context.SaveChangesAsync();
                
                // add installments
                var _InstallmentAmount = diary.RecoveryAmount / scheme.InstallmentCount;
                for (int i = 0; i < model.Installment;i++ )
                {
                    _context.DiaryInstallments.Add(new DiaryInstallment 
                        {
                            Id = 0,
                            DiaryId = diary.Id, 
                            InstallmentAmount = _InstallmentAmount,
                            BalanceAmount = _InstallmentAmount,
                            InstallmentDate = diary.StartDate.AddDays(i),
                            InstallmentNumber = i+1,
                            PaidAmount = 0,
                            ModifiedBy = 2,
                            ModifiedOn = DateTime.Now
                        });
                }
                await _context.SaveChangesAsync();
                
                // add refences accounts
                if (model.References != null)
                {
                    foreach (var item in model.References)
                    {
                        var accountRef = await _context.Accounts.FirstOrDefaultAsync(p => p.Id == item.AccountId);
                        if (accountRef != null)
                        {
                            var trans = new Transaction
                            {
                                Id = 0,
                                Amount = -item.LoanAmount,
                                Description = $"Transfer {accountRef.AccountName} to {diary.DiaryNumber}",
                                Total =  -item.LoanAmount,
                                LateFee = 0,
                                TransactionType = TransactionType.Transfer,
                                TransDate = diary.StartDate,
                                PaymentMode = "TRANS",
                                DiaryId = diary.AccountId,
                                TransactionTypeText = TransactionType.Transfer.ToString(),
                                CreatedBy = 2,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = 2,
                                ModifiedOn = DateTime.Now,
                                IsCompleted = false,
                                 
                            };
                            if(accountRef.AccountType==AccountType.Investor)
                                trans.InvestorId = accountRef.Id;
                            if (accountRef.AccountType == AccountType.Diary)
                            {
                                trans.FromDiaryId = accountRef.Id;
                            }
                            _context.Transactions.Add(trans);

                            accountRef.AvailableFunds = accountRef.AvailableFunds - item.LoanAmount;
                            accountRef.TotalRecovery =
                                accountRef.TotalRecovery + (diary.RecoveryAmount - diary.LoanAmount);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            else{
                _res.data = false;
                _res.Message = "Customer not found.";
            }
        }
        else
        {
            _res.data = false;
            _res.Message = "Diary Number already exits.";
        }
        
        
        
        
        
        
        
        
        
        
        // if (Diary == null)
        // {
        //     var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.CustomerId && x.IsActive == true);
        //     if (customer == null)
        //     {
        //         customer = new Customer
        //         {
        //             Address = model.CustomerAddress ?? "",
        //             Mobile = model.CustomerMobile,
        //             Name = model.CustomerName,
        //             BusinessName = model.CustomerBusinessName,
        //             FatherName = model.CustomerFatherName,
        //             CreatedBy = 2,
        //             CreatedOn = DateTime.Now,
        //             ModifiedBy = 2,
        //             ModifiedOn = DateTime.Now,
        //             IsActive = true,
        //             Phone = model.CustomerMobile
        //         };
        //         _context.Customers.Add(customer);
        //         _context.SaveChangesAsync();
        //     }
        //     
        //     Diary = new Diary();
        //
        //     Diary.Installment = model.Installment;
        //     Diary.AgentId = model.AgentId;
        //     Diary.DiaryNumber = model.DiaryNumber;
        //     Diary.LoanAmount = model.LoanAmount;
        //     Diary.CustomerId = customer.Id;
        //     
        //     if (Diary.AgentId > 1)
        //     {
        //         Diary.HasAgent = true;
        //         Diary.Installment = 117;
        //         Diary.RecoveryAmount = Diary.LoanAmount + (Diary.LoanAmount * 17 / 100);
        //     }
        //     else
        //     {
        //         Diary.HasAgent = true;
        //         Diary.Installment = 120;
        //         Diary.RecoveryAmount = Diary.LoanAmount + (Diary.LoanAmount * 20 / 100);
        //     }
        //
        //     Diary.TotalBalanceAmount = Diary.RecoveryAmount;
        //     Diary.IsActive = true;
        //     Diary.IsCompleted = false;
        //     Diary.CreatedBy = 2;
        //     Diary.CreatedOn = DateTime.Now;
        //     Diary.ModifiedBy = 2;
        //     Diary.ModifiedOn = DateTime.Now;
        //     var lastDiary = await _context.Dairies.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
        //     Diary.DiaryNumber = (lastDiary==null?1:(lastDiary.DiaryNumber+1));
        //     Diary.StartDate = model.DiaryStartDate.AddDays(1);
        //     Diary.EndDate = model.DiaryStartDate.AddDays(model.Installment);
        //     
        //     _context.Dairies.Add(Diary);
        //     await _context.SaveChangesAsync();
        //
        //     var _InstallmentAmount = Diary.LoanAmount / 100;
        //     
        //     // for (int i = 0; i < model.Installment;i++ )
        //     // {
        //     //     _context.DiaryInstallments.Add(new DiaryInstallment 
        //     //         {
        //     //             DiaryId = Diary.Id, 
        //     //             InstallmentAmount = _InstallmentAmount,
        //     //             BalanceAmount = _InstallmentAmount,
        //     //             InstallmentDate = Diary.StartDate.AddDays(i),
        //     //             InstallmentNumber = i+1,
        //     //             PaidAmount = 0,
        //     //             ModifiedBy = 2,
        //     //             ModifiedOn = DateTime.Now,
        //     //             Id = 0
        //     //         });
        //     // }
        //     // await _context.SaveChangesAsync();
        //     //
        //     // if (model.RefDiaries != null)
        //     // {
        //     //     foreach (var item in model.RefDiaries)
        //     //     {
        //     //         var dr = await _context.Accounts.FirstOrDefaultAsync(p => p.Id == item.AccountId);
        //     //         
        //     //         // var dr = await _context.Dairies.FirstOrDefaultAsync(p => p.DiaryNumber == item.DiaryNumber);
        //     //         // if(dr!=null){
        //     //         //     _context.DiaryReferences.Add(new DiaryReference
        //     //         //     {
        //     //         //         Amount = item.LoanAmount,
        //     //         //         DiaryId = Diary.Id,
        //     //         //         FromDiaryId = dr.Id,
        //     //         //         CreatedBy = 2,
        //     //         //         CreatedOn = DateTime.Now,
        //     //         //         ModifiedBy = 2,
        //     //         //         ModifiedOn = DateTime.Now,
        //     //         //
        //     //         //     });
        //     //         //     await _context.SaveChangesAsync();
        //     //         // }
        //     //     }
        //     // }
        // }
        // return new ResponseObject<bool>(true);
        return _res;
    }
    
    [HttpPost("/diary/payment")]
    public async Task<ResponseObject<bool>> DiaryPayment(DiaryPaymentRequest model)
    {
        var _res = new ResponseObject<bool>(false);
        var diary = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == model.DiaryId && x.IsActive == true);
        if (diary != null)
        {
            
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == diary.AccountId && x.IsActive == true);
            var trans = new Transaction
            {
                Amount = model.PaymentAmount,
                LateFee = model.PaymentLateAmount,
                Description = $"Payment of {account.AccountName}",
                Id = 0,
                Total =  model.PaymentTotal,
                DiaryId = diary.AccountId,
                
                TransactionType = TransactionType.DairyPayment,
                TransDate = model.PaymentDate,
                PaymentMode = model.PaymentMode,
                TransactionTypeText = TransactionType.DairyPayment.ToString(),
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                IsCompleted = false
            };
            _context.Transactions.Add(trans);

            account.AvailableFunds = account.AvailableFunds + model.PaymentAmount;

            diary.TotalPaidAmount = diary.TotalPaidAmount + model.PaymentAmount;
            diary.TotalBalanceAmount = diary.TotalBalanceAmount - model.PaymentAmount;
            await _context.SaveChangesAsync();
            
            var _amount = model.PaymentAmount;
            var installments = await _context.DiaryInstallments.Where(x => x.DiaryId==diary.Id).ToListAsync();
            foreach (var item in installments)
            {
                if(_amount<=0)
                    break;
                if (item.BalanceAmount > 0)
                {
                    _amount = _amount - item.BalanceAmount;
                    if (_amount > 0)
                    {
                        item.BalanceAmount = 0;
                    }
                    else
                    {
                        item.BalanceAmount = Double.Abs(_amount);
                        _amount = 0;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        else
        {
            _res.data = false;
            _res.Message = "Diary Number already exits.";
        }
        
        
        return _res;
    }

    #endregion
    #region Investors
    [HttpPost("/investor/addfund")]
    public async Task<ResponseObject<bool>> AddFundByInvestor(InvestorAddFundRequest request)
    {
        var investor = await _context.Accounts
            .FirstOrDefaultAsync(x=>
                x.AccountType== AccountType.Investor
                && x.Id==request.AccountId);

        if (investor != null)
        {
            var trans = new Transaction
            {
                Amount = request.Amount,
                Description = "Add Fund by Investor",
                Id = 0,
                Total =  request.Amount,
                InvestorId = request.AccountId,
                LateFee = 0,
                TransactionType = TransactionType.AddFund,
                TransDate = request.TransDate,
                PaymentMode = request.Mode,
                TransactionTypeText = TransactionType.AddFund.ToString(),
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                IsCompleted = false
            };
            _context.Transactions.Add(trans);

            investor.AvailableFunds = investor.AvailableFunds + request.Amount;
            investor.TotalFunding = investor.TotalFunding + request.Amount;
            investor.TotalRecovery = investor.TotalRecovery + request.Amount;
            await _context.SaveChangesAsync();
        }
        
        return new ResponseObject<bool>(true);
    }
    

    #endregion
    
    
    
    

    // [HttpGet("getall")]
    // public async Task<ResponseObject<IEnumerable<AgentViewRequest>>> GetAll()
    // {
    //     return new ResponseObject<IEnumerable<AgentViewRequest>>(await _context.Accounts
    //         .Where(f=>f.AccountType== AccountType.Investor &&f.IsActive==true)
    //         .Select(x=>new AgentViewRequest
    //         {
    //             Address = x.Address??"-",
    //             Id = x.Id,
    //             Installments = 117,
    //             Mobile = x.Mobile??"",
    //             Name = x.AccountName,
    //             Dairies = string.Join(",", _context.Dairies.Where(d => d.AgentId==x.Id).Select(f=>f.DiaryNumber.ToString()).ToList<string>())
    //         })
    //        
    //         .ToListAsync());
    // }
    //
    // [HttpGet("get/{id}")]
    // public async Task<ResponseObject<AgentViewRequest?>> Get(int id)
    // {
    //     return new ResponseObject<AgentViewRequest?>(
    //         await _context.Accounts
    //             .Select(x=>new AgentViewRequest
    //             {
    //                 Address = x.Address??"-",
    //                 Id = x.Id,
    //                 Installments = 120,
    //                 Mobile = x.Mobile??"",
    //                 Name = x.AccountName,
    //                 Dairies = string.Join(",", _context.Dairies.Where(d => d.AgentId==x.Id).Select(f=>f.DiaryNumber.ToString()).ToList<string>())
    //             }).FirstOrDefaultAsync<AgentViewRequest>(x=>x.Id==id));
    // }
    //
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(AgentViewRequest model)
    {
        var agent = await _context.Accounts.FirstOrDefaultAsync(x =>x.AccountType== AccountType.Investor && x.Id == model.Id && x.IsActive==true);
        if (agent == null)
        {
            agent = new Account
            {
                Address = model.Address,
                Mobile = model.Mobile,
                AccountName = model.Name,
                IsActive = true,
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                Id = 0,
                AccountType = AccountType.Investor,
                AccountTypeText = "Agent",
                ParentAccountId = (int)AccountType.Investor
            };
            _context.Accounts.Add(agent);
        }
        else
        {
            agent.AccountName = model.Name;
            agent.Mobile = model.Mobile;
            agent.Address = model.Address;
            agent.ModifiedBy = 2;
            agent.ModifiedOn = DateTime.Now;
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var agent = await _context.Accounts.FirstOrDefaultAsync(x =>x.AccountType== AccountType.Investor && x.Id == id && x.IsActive == true);
        if (agent == null)
        {
            return new ResponseObject<bool>(false,false,"Agent is not found.");
        }
        agent.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
}