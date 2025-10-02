
window.createChart3 = {


    starts3: function (jsonData) {

        const values = jsonData.map(dp => dp.valor)
        const categories = jsonData.map(dp => dp.data)
       
        var options = {
            series: [{
                name: 'total',
                data: values
            }],
            chart: {
                height: 350,
                type: 'area',
            },
            grid: {
                show: false,
            },
            stroke: {
                curve: "smooth", // 'smooth' or 'stepline'
                width: 3, // Border width in pixels
                //colors: ["#FF0000"], // Border color (red in this case)
                dashArray: 0 // 0 for solid border, >0 for dashed border
            },
            plotOptions: {
                bar: {
                    borderRadius: 10,
                    dataLabels: {
                        position: 'center', // top, center, bottom
                    },
                }
            },
            dataLabels: {
                enabled: true,
                formatter: function (val) {
                    /* return val;*/
                    return "$" + val; 
                },
        
                offsetY: -20,
                style: {
                    fontSize: '10px',
                    colors: ["#000"]
                }
            },

            xaxis: {
                categories: categories,
                position: 'bottom',
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false
                },
                crosshairs: {
                    fill: {
                        type: 'gradient',
                        gradient: {
                            colorFrom: '#D8E3F0',
                            colorTo: '#BED1E6',
                            stops: [0, 100],
                            opacityFrom: 0.1,
                            opacityTo: 0.2,
                        }
                    }
                },
                tooltip: {
                    enabled: true,
                }
            },
            title: {
                text: 'Matrepai P09',
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
            yaxis: {
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false,
                },
                labels: {
                    show: false,
                    formatter: function (val) {
                        /*return val;*/
                       /* return "$" + value; */
                    }
                },
       

            }
  
        };

        var chart = new ApexCharts(document.querySelector("#chartmtrp09"), options);
        chart.render();


        //var options = {
        //    series: [{
        //        name: "STOCK ABC",
        //        data: values
        //    }],
        //    chart: {
        //        type: 'area',
        //        height: 350,
        //        zoom: {
        //            enabled: false
        //        }
        //    },
        //    dataLabels: {
        //        enabled: false
        //    },
        //    stroke: {
        //        curve: 'straight'
        //    },

        //    title: {
        //        text: 'Fundamental Analysis of Stocks',
        //        align: 'left'
        //    },
        //    subtitle: {
        //        text: 'Price Movements',
        //        align: 'left'
        //    },
        //    labels: categories,
        //    xaxis: {
        //        type: 'datetime',
        //    },
        //    yaxis: {
        //        opposite: true
        //    },
        //    legend: {
        //        horizontalAlign: 'left'
        //    }
        //};

        //var chart = new ApexCharts(document.querySelector("#chart"), options);
        //chart.render();
    }

}
