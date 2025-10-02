using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.EntityFrameworkCore;

namespace Bonepile_New.Services;

public class HardRepairService
{
    private readonly BancoContext _context;

    public HardRepairService(BancoContext context)
    {
        _context = context;
    }

    public async Task<List<HardRepairModel>> Get(DateTime dataInicio, DateTime dataFim)
    {
        return await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(r => r.Update_Date.Date >= dataInicio && r.Update_Date.Date <= dataFim)
            .ToListAsync();
    }

    public async Task<List<HardRepairModel>> GetSevenDays()
    {
        var dataAtual = DateTime.Today;
        var seven = dataAtual.AddDays(-7);

        return await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(r => r.Update_Date >= seven)
            .ToListAsync();
    }


    public async Task<List<HardRepairModel>> GetBacking()
    {
        var dataAtual = DateTime.Today;
        var seven = dataAtual.AddDays(-30);

         var repair =  await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(r => r.Update_Date >= seven && r.Station == "Backing IN" && r.Unit_Status == "Processing")
            .ToListAsync();

        return repair;

    }

    public async Task<List<HardRepairModel>> GetChartAsync()
    {
        var dataAtual = DateTime.Today;
        var dataSevenDays = dataAtual.AddDays(-7);  
      
        var chart = await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(x=>x.Update_Date.Date >= dataSevenDays)
            .ToListAsync();

        return chart;
    }

    public async Task<List<HardRepairModel>> GetChartClienteAsync()
    {
        var dataAtual = DateTime.Today;
        var dataSevenDays = dataAtual.AddDays(-7);

        var chart = await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(x => x.Update_Date.Date >= dataSevenDays)
            .ToListAsync();

        return chart;
    }

    public async Task<List<HardRepairModel>> GetGeral(DateTime dataInicio, DateTime dataFim)
    {

        return await _context.UDTHARD_REPAIR_BASE_PLACAS
            .Where(r => r.Update_Date.Date >= dataInicio && r.Update_Date.Date <= dataFim)
            .ToListAsync();
    }
}
