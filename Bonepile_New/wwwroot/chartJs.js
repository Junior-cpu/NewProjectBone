
window.createChart6 = {


    starts6: function (jsonData) {

        const values = jsonData.map(dp => dp.qt)
        const categories = jsonData.map(dp => dp.acao == "ANALISE" ? "IN" : "OUT")

    
    }
}