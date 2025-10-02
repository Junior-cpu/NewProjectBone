
window.createChart5 = {


    starts5: function (jsonData) {

        const values = jsonData.map(dp => dp.qt)
        const categories = jsonData.map(dp => dp.acao == "ANALISE".trim() ? "IN" : "OUT")



        var options = {
            labels: categories,
            series:values ,
            chart: {
                //width: 200,
                height: 350,
                type: 'donut',
            },
            title:
            {
                text: 'In X Out hoje',
                align: 'left',
                margin: 10,
                offsetX: 0,
                offsetY: 0,
                floating: false,
                style: {
                    fontSize: '14px',
                    fontWeight: 'bold',
                    fontFamily: undefined,
                    color: '#696969',
                }

            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '75%', // Adjust this percentage (e.g., '50%' for a larger hole)
                        // ... other donut options
                    }
                }
            },
            legend:
            {
                show: true,
                position: 'bottom',
                onItemClick: {
                    toggleDataSeries: true
                },

            },
            responsive: [{
                breakpoint: 350,
                options: {
                    dataLabels: {
                        enabled: true,
                        position: 'bottom',
                    },
              
                 
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#donut"), options);
        chart.render();
        //var options = {
        //    labels: categories,
        //    series:values ,
        //    chart: {
        //        width: 380,
        //        type: 'donut',
        //    },
        //    plotOptions: {
        //        pie: {
        //            startAngle: -90,
        //            endAngle: 270
        //        }
        //    },
        //    dataLabels: {
        //        enabled: false
        //    },
        //    fill: {
        //        type: 'gradient',
        //    },
        //    legend: {
        //        formatter: function (val, opts) {
        //            return val + " - " + opts.w.globals.series[opts.seriesIndex]
        //        }
        //    },
        //    title: {
        //        text: 'Gradient Donut with custom Start-angle'
        //    },
        //    responsive: [{
        //        breakpoint: 480,
        //        options: {
        //            chart: {
        //                width: 200
        //            },
        //            legend: {
        //                position: 'bottom'
        //            }
        //        }
        //    }]
        //};

        //var chart = new ApexCharts(document.querySelector("#donut"), options);
        //chart.render();
    }
}