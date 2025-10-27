using Bonepile_New.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.JSInterop;
using System.Drawing.Text;

namespace Bonepile_New.Pages;

public partial class ArmarioBone
{
    public Armario_BoneModel model = new Armario_BoneModel();
    private List<Armario_BoneModel>? armarios { get; set; } = new List<Armario_BoneModel>();
    private List<BoneInModel>? boneIn { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? gaveteiro { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? debug1 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range0a3 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range4a7 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range8a14 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range15a30 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range31a60 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range60 { get; set; } = new List<BoneInModel>();
    private List<InfoPlacas> resultado = new List<InfoPlacas>();
    public IEnumerable<BoneInModel>? listPosicoes;
    public List<string>? list;
    public BoneInModel contexto = new BoneInModel();
    public BoneInModel contextoLista = new BoneInModel();
    public BoneOutModel contextoOut = new BoneOutModel();
    public BoneInModel contextoStatus = new BoneInModel();
    public List<BoneInModel> listIn = new();
    public List<BoneInModel> uniao = new();
    public List<BoneOutModel> uniaoOut = new();


    private DateTime? dataInicio;
    private DateTime? dataFim;
    private string? state;
    private string? serialnumber;
    private string? client;
    private string? action;
    private string? accao;

    public List<BoneInModel> listPosicoes1 { get; set; } = new List<BoneInModel>();
    private int resultado0a3 = 0;
    private int resultado4a7 = 0;
    private int resultado8a14 = 0;
    private int resultado15a30 = 0;
    private int resultado31a60 = 0;
    private int resultado60 = 0;
    private int debug = 0;
    private int total = 0;
    int qtd_g = 20;

    

    public string? ar { get; set; } = "";
    public string? Serial_Number = "";
    public string? serial = "";


   

    protected override async Task OnInitializedAsync()
    {


      

        armarios = await boneService.GetArmario();

        model = await boneService.GetArmarioId(qtd_g);

        list = bancoContext.UDTBONE_PLACAS_IN_BONE
           .Select(x => x.Local).ToList();



        resultado0a3 = bancoContext.UDTBONE_PLACAS_IN_BONE
             .Count(x => x.Aging >= 0 && x.Aging <= 3);

        resultado4a7 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging >= 4 && x.Aging <= 7);

        resultado8a14 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 7 && x.Aging < 15);

        resultado15a30 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 14 && x.Aging < 31);

        resultado31a60 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 30 && x.Aging < 61);

        resultado60 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 60);

        debug = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Local == "DEBUG_1".Trim());

        total = bancoContext.UDTBONE_PLACAS_IN_BONE.Count();


        
    }

    private bool mostrarModalTotal = false;
    private bool mostrarModalDebug = false;
    private bool mostrarModal0a3 = false;
    private bool mostrarModal4a7 = false;
    private bool mostrarModal8a14 = false;
    private bool mostrarModal15a30 = false;
    private bool mostrarModal31a60 = false;
    private bool mostrarModal60 = false;
    private bool mostrarModalGaveteiro = false;
    private bool mostrarModalEntrada = false;
    private bool mostrarModalEntradaLista = false;
    private bool mostrarModalSaida = false;
    private bool mostrarModalStatus = false;
    private bool mostrarModalReport = false;
    private bool mostrarModalReportOut = false;



    private async Task AbrirModal()
    {
        boneIn = await bonepileService.GetTotalAsync();
        mostrarModalTotal = true;
    }

    private async Task AbrirModalDebug()
    {
        debug1 = await bonepileService.GetDebugAsync();
        mostrarModalDebug = true;
    }

    private async Task AbrirModal0a3()
    {
        range0a3 = await bonepileService.Get0a3Async();
        mostrarModal0a3 = true;
    }
    private async Task AbrirModal4a7()
    {
        range4a7 = await bonepileService.Get4a7Async();
        mostrarModal4a7 = true;
    }
    private async Task AbrirModal8a14()
    {
        range8a14 = await bonepileService.Get8a14Async();
        mostrarModal8a14 = true;
    }
    private async Task AbrirModal15a30()
    {
        range15a30 = await bonepileService.Get15a30Async();
        mostrarModal15a30 = true;
    }
    private async Task AbrirModal31a60()
    {
        range31a60 = await bonepileService.Get31a60Async();
        mostrarModal31a60 = true;
    }
    private async Task AbrirModal60()
    {
        range60 = await bonepileService.Get60Async();
        mostrarModal60 = true;
    }

    private async Task AbrirModalGaveta(string ar)
    {
        gaveteiro = await bonepileService.GetGavetaAsync(ar);
        mostrarModalGaveteiro = true;
    }
    private async Task AbrirModalEntrada()
    {

        mostrarModalEntrada = true;
    }
    private async Task AbrirModalEntradaLista()
    {

        mostrarModalEntradaLista = true;
    }
    private async Task AbrirModalSaida()
    {

        mostrarModalSaida = true;
    }
    private async Task AbrirModalStatus()
    {

        mostrarModalStatus = true;
    }
    private async Task AbrirModalReport()
    {

        mostrarModalReport = true;
    }
    private async Task AbrirModalReportOut()
    {

        mostrarModalReportOut = true;
    }
    private Task FecharModalTotal()
    {
        mostrarModalTotal = false;
        return Task.CompletedTask;
    }

    private Task FecharModalDebug()
    {
        mostrarModalDebug = false;
        return Task.CompletedTask;
    }

    private Task FecharModal0a3()
    {
        mostrarModal0a3 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal4a7()
    {
        mostrarModal4a7 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal8a14()
    {
        mostrarModal8a14 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal15a30()
    {
        mostrarModal15a30 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal31a60()
    {
        mostrarModal31a60 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal60()
    {
        mostrarModal60 = false;
        return Task.CompletedTask;
    }

    private Task FecharModalGaveteiro()
    {
        mostrarModalGaveteiro = false;
        return Task.CompletedTask;
    }
    private Task FecharModalEntrada()
    {
        mostrarModalEntrada = false;
        return Task.CompletedTask;
    }
    private Task FecharModalEntradaLista()
    {
        mostrarModalEntradaLista = false;
        return Task.CompletedTask;
    }
    private Task FecharModalSaida()
    {
        mostrarModalSaida = false;
        return Task.CompletedTask;
    }
    private Task FecharModalStatus()
    {
        mostrarModalStatus = false;
        return Task.CompletedTask;
    }
    private Task FecharModalReport()
    {
        mostrarModalReport = false;
        return Task.CompletedTask;
    }
    private Task FecharModalReportOut()
    {
        mostrarModalReportOut = false;
        return Task.CompletedTask;
    }
    async Task Success() =>
    await JS.InvokeAsync<object>("alert", "Successful login!");


    string partnumber = "";
    string cliente = "";
    string modelo = "";
    string falha = "";
    string local = "";
    string acao = "";
    string localization = "DEBUG_1";

    string partnumber1 = "";
    bool checked1 = false;
    double preco = 0;
    int aging = 0;
    long Id = 0;



    private async Task BuscaInfo(string serial_number)
    {
     
        var resultado3 = await bancoContext.InfoPlacas
        .FromSqlRaw("EXEC db_owner.UDTBONE_Get_Infos_Placas @serial_number", new SqlParameter("@serial_number", serial_number))
        .ToListAsync();

        resultado = await bancoContext.InfoPlacas.ToListAsync();

        partnumber = resultado[0].Partnumber;
        contexto.Part_Number = resultado[0].Partnumber;
        contexto.Cliente = resultado[0].Cliente;
        contexto.Modelo = resultado[0].Modelo;
        contexto.Falha = resultado[0].Failure;
        contexto.Serial_Number = serial_number;
 


        var preco1 = await bancoContext.GetValor
         .FromSqlRaw("EXEC db_owner.UDTBONE_GetValorByPartNumber @partnumber", new SqlParameter("@partnumber", partnumber))
         .ToListAsync();

        preco = preco1[0].PRECO_MEDIO_MENSAL_EM_USD;
        contexto.Valor = preco;
        contexto.Local = local;
        contexto.Aging = aging;
        contexto.Acao = acao;
        contexto.Id = Id;


    }

    private async Task OnValidSubmit()
    {
        if(contexto.Local == "")
        {
            contexto.Local = localization;
        }
        if(contexto.Local.ToUpper() =="D" || contexto.Local.ToUpper() == "DE" || contexto.Local.ToUpper() =="DEB" || contexto.Local.ToUpper() == "DEBU")
        {
            contexto.Local = localization;
        }
        await boneService.SalvaBoneIn(contexto);
        mostrarModalEntrada = false;
        Toaster.Add("Mensagem de sucesso ", MatToastType.Success, "Titulo");
        await Task.Delay(3000);
        navigation.NavigateTo(navigation.Uri, forceLoad: true);
    }


    private async Task BuscaInfoSaida(string serial)
    {
        contexto = await boneService.GetBoneIn(serial);

        contextoOut.Serial_Number = serial;
        contextoOut.Part_Number = contexto.Part_Number;
        contextoOut.Local = contexto.Local;
        contextoOut.Cliente = contexto.Cliente;
        contextoOut.Modelo = contexto.Modelo;
        contextoOut.Falha = contexto.Falha;
        contextoOut.Entrada = contexto.Entrada;
        contextoOut.Aging = contexto.Aging;
        contextoOut.Valor = contexto.Valor;
        contextoOut.Saida = DateTime.Now;

    }


    private async Task OnExitSubmit()
    {

        await boneService.SalvaBoneOut(contextoOut);
        mostrarModalSaida = false;
        Toaster.Add("Mensagem de sucesso ", MatToastType.Danger, "Titulo");
        await Task.Delay(3000);
        navigation.NavigateTo(navigation.Uri, forceLoad: true);
    }

    private async Task BuscaInfo1(string serial_number)
    {
       
        var resultado3 = await bancoContext.InfoPlacas
        .FromSqlRaw("EXEC db_owner.UDTBONE_Get_Infos_Placas @serial_number", new SqlParameter("@serial_number", serial_number))
        .ToListAsync();

        resultado = await bancoContext.InfoPlacas.ToListAsync();

        partnumber = resultado[0].Partnumber;
        contextoLista.Part_Number = resultado[0].Partnumber;
        contextoLista.Cliente = resultado[0].Cliente;
        contextoLista.Modelo = resultado[0].Modelo;
        contextoLista.Falha = resultado[0].Failure;
        contextoLista.Serial_Number = resultado[0].SerialNumber;
       


        var preco1 = await bancoContext.GetValor
         .FromSqlRaw("EXEC db_owner.UDTBONE_GetValorByPartNumber @partnumber", new SqlParameter("@partnumber", partnumber))
         .ToListAsync();

        preco = preco1[0].PRECO_MEDIO_MENSAL_EM_USD;
        contextoLista.Valor = preco;
        contextoLista.Aging = aging;
     

    }


    private async Task OnValidSubmitLista()
    {
        listIn.Add(contextoLista);
        Serial_Number = string.Empty;
        contextoLista = new();
    }

        

    async Task SalvarLista()
    {
        await boneService.SalvaBoneInLista(listIn);
        mostrarModalEntradaLista = false;
        Toaster.Add("Mensagem de sucesso ", MatToastType.Success, "Titulo");
        await Task.Delay(3000);
        navigation.NavigateTo(navigation.Uri, forceLoad: true);

    }

    private async Task BuscaInfoStatus(string serial)
    {
        contexto = await boneService.GetBoneIn(serial);

        contextoStatus.Serial_Number = serial;
        contextoStatus.Part_Number = contexto.Part_Number;
        contextoStatus.Local = contexto.Local;
        contextoStatus.Acao = contexto.Acao;    
   
    }
    private async Task AlterStatus()
    {
        await boneService.AtualizaStatusdAsync(contextoStatus);
        mostrarModalStatus = false;
        Toaster.Add("Mensagem de sucesso ", MatToastType.Warning, "Titulo");
        await Task.Delay(3000);
        navigation.NavigateTo(navigation.Uri, forceLoad: true);
    }

   

    private async Task Reports()
    { 
            uniao = await boneService.Buscar(dataInicio, serialnumber, client,accao);
    }


    private async Task Report()
    {
        uniaoOut = await boneService.BuscarOut(dataInicio, dataFim, serialnumber, client, accao);
    }

    private void Limpar()
    {

        serialnumber = string.Empty;
        dataInicio = null;
        dataFim = null;
        client = string.Empty;
        accao = string .Empty;  
    }

   
}

