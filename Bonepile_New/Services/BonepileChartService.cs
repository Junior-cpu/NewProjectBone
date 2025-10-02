using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections;

namespace Bonepile_New.Services;

public class BonepileChartService
{
    private readonly HttpClient _httpClient;
    private readonly BancoContext _context;
    public BonepileChartService(HttpClient httpClient, BancoContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    //public async Task<IEnumerable<BonepileChartModel>> GetChartAsync()
    //{
    //    return await _httpClient.GetFromJsonAsync<IEnumerable<BonepileChartModel>>("api/getchart");
    //}

    public async Task<List<BonepileChartModel>> GetChartAsync()
    {
        var chart = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO_CHART.ToListAsync();

        return chart;
    }

    public async Task<List<ConfirmInModel>> GetConfirmIn()
    {
        var dataAtual = DateTime.Today;
        var confirm = await _context.UDTBONE_PLACAS_IN_CONFIRM_TEST
            .Where(d=>d.Acao !="--".Trim() && d.Acao!="SCRAP".Trim() && d.Entrada.Date >= dataAtual)    
            .ToListAsync();

        return confirm;
    }
    public async Task<List<ConfirmOutModel>> GetConfirmInxOut()
    {
        var dataAtual = DateTime.Today;
        var confirm = await _context.UDTBONE_HISTORICO_OUT_CONFIRM_TEST
       
            .Where(d => d.Entrada.Date >= dataAtual)
        
            .ToListAsync();

        return confirm;
    }
    public async Task<List<BorInModel>> GetBorIn()
    {
        var dataAtual = DateTime.Today;
        var bor = await _context.UDTBONE_PLACAS_IN_BOR_TEST
             .Where(d => d.Acao != "--".Trim() && d.Acao != "SCRAP".Trim() && d.Entrada.Date >= dataAtual)
            .ToListAsync();
   
        return bor;
    }
    public async Task<List<BorOutModel>> GetBorInxOut()
    {
        var dataAtual = DateTime.Today;
        var bor = await _context.UDTBONE_HISTORICO_OUT_BOR_TEST
             .Where(d => d.Entrada.Date >= dataAtual)
            .ToListAsync();

        return bor;
    }
    public async Task<List<BoneInModel>> GetBoneIn()
    {
        var dataAtual = DateTime.Today;
        var bone = await _context.UDTBONE_PLACAS_IN_BONE
          
            .Where(d => d.Acao != "--".Trim() && d.Acao != "SCRAP".Trim()  && d.Entrada.Date >= dataAtual)
            .ToListAsync();

        return bone;
    }
    public async Task<List<BoneOutModel>> GetBoneInxOut()
    {
        var dataAtual = DateTime.Today;
        var bone = await _context.UDTBONE_HISTORICO_OUT

            .Where(d => d.Entrada.Date >= dataAtual)
            .ToListAsync();

        return bone;
    }
    public async Task<List<BoneOutModel>> GetBoneOut()
    {
        var dataAtual = DateTime.Today;
        //var dataOntem = dataAtual.AddDays(-5);
        var boneOut = await _context.UDTBONE_HISTORICO_OUT
            .Where(d=>d.Saida.Date >= dataAtual  && d.Acao !="REPARO".Trim())
            .ToListAsync();

        return boneOut;
    }
    public async Task<List<ConfirmOutModel>> GetConfirmOut()
    {
        var dataAtual = DateTime.Today;
        //var dataOntem = dataAtual.AddDays(-5);
        var confirmOut = await _context.UDTBONE_HISTORICO_OUT_CONFIRM_TEST
            .Where(d => d.Saida.Date >= dataAtual  && d.Acao != "REPARO".Trim())
            .ToListAsync();

        return confirmOut;
    }
    public async Task<List<BorOutModel>> GetBorOut()
    {
        var dataAtual = DateTime.Today;
        //var dataOntem = dataAtual.AddDays(-5);
        var borOut = await _context.UDTBONE_HISTORICO_OUT_BOR_TEST
            .Where(d => d.Saida.Date >= dataAtual  && d.Acao != "REPARO".Trim())
            .ToListAsync();

        return borOut;
    }
}

