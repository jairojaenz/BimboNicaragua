type = ['primary', 'info', 'success', 'warning', 'danger'];

demo = {
  initPickColor: function() {
    $('.pick-class-label').click(function() {
      var new_class = $(this).attr('new-class');
      var old_class = $('#display-buttons').attr('data-class');
      var display_div = $('#display-buttons');
      if (display_div.length) {
        var display_buttons = display_div.find('.btn');
        display_buttons.removeClass(old_class);
        display_buttons.addClass(new_class);
        display_div.attr('data-class', new_class);
      }
    });
  },

  initDocChart: function() {
    chartColor = "#FFFFFF";

    // General configuration for the charts with Line gradientStroke
    gradientChartOptionsConfiguration = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      tooltips: {
        bodySpacing: 4,
        mode: "nearest",
        intersect: 0,
        position: "nearest",
        xPadding: 10,
        yPadding: 10,
        caretPadding: 10
      },
      responsive: true,
      scales: {
        yAxes: [{
          display: 0,
          gridLines: 0,
          ticks: {
            display: false
          },
          gridLines: {
            zeroLineColor: "transparent",
            drawTicks: false,
            display: false,
            drawBorder: false
          }
        }],
        xAxes: [{
          display: 0,
          gridLines: 0,
          ticks: {
            display: false
          },
          gridLines: {
            zeroLineColor: "transparent",
            drawTicks: false,
            display: false,
            drawBorder: false
          }
        }]
      },
      layout: {
        padding: {
          left: 0,
          right: 0,
          top: 15,
          bottom: 15
        }
      }
    };

    ctx = document.getElementById('lineChartExample').getContext("2d");

    gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
    gradientStroke.addColorStop(0, '#80b6f4');
    gradientStroke.addColorStop(1, chartColor);

    gradientFill = ctx.createLinearGradient(0, 170, 0, 50);
    gradientFill.addColorStop(0, "rgba(128, 182, 244, 0)");
    gradientFill.addColorStop(1, "rgba(249, 99, 59, 0.40)");

    myChart = new Chart(ctx, {
      type: 'line',
      responsive: true,
      data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
          label: "Active Users",
          borderColor: "#f96332",
          pointBorderColor: "#FFF",
          pointBackgroundColor: "#f96332",
          pointBorderWidth: 2,
          pointHoverRadius: 4,
          pointHoverBorderWidth: 1,
          pointRadius: 4,
          fill: true,
          backgroundColor: gradientFill,
          borderWidth: 2,
          data: [542, 480, 430, 550, 530, 453, 380, 434, 568, 610, 700, 630]
        }]
      },
      options: gradientChartOptionsConfiguration
    });
  },

  initDashboardPageCharts: function() {

    gradientChartOptionsConfigurationWithTooltipBlue = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.0)',
            zeroLineColor: "transparent",
          },
          ticks: {
            suggestedMin: 60,
            suggestedMax: 125,
            padding: 20,
            fontColor: "#2380f7"
          }
        }],

        xAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            padding: 20,
            fontColor: "#2380f7"
          }
        }]
      }
    };

    gradientChartOptionsConfigurationWithTooltipPurple = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.0)',
            zeroLineColor: "transparent",
          },
          ticks: {
            suggestedMin: 60,
            suggestedMax: 125,
            padding: 20,
            fontColor: "#9a9a9a"
          }
        }],

        xAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(225,78,202,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            padding: 20,
            fontColor: "#9a9a9a"
          }
        }]
      }
    };

    gradientChartOptionsConfigurationWithTooltipOrange = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.0)',
            zeroLineColor: "transparent",
          },
          ticks: {
            suggestedMin: 50,
            suggestedMax: 110,
            padding: 20,
            fontColor: "#ff8a76"
          }
        }],

        xAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(220,53,69,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            padding: 20,
            fontColor: "#ff8a76"
          }
        }]
      }
    };

    gradientChartOptionsConfigurationWithTooltipGreen = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.0)',
            zeroLineColor: "transparent",
          },
          ticks: {
            suggestedMin: 50,
            suggestedMax: 125,
            padding: 20,
            fontColor: "#9e9e9e"
          }
        }],

        xAxes: [{
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: 'rgba(0,242,195,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            padding: 20,
            fontColor: "#9e9e9e"
          }
        }]
      }
    };


    gradientBarChartConfiguration = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [{

          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            suggestedMin: 60,
            suggestedMax: 120,
            padding: 20,
            fontColor: "#9e9e9e"
          }
        }],

        xAxes: [{

          gridLines: {
            drawBorder: false,
            color: 'rgba(29,140,248,0.1)',
            zeroLineColor: "transparent",
          },
          ticks: {
            padding: 20,
            fontColor: "#9e9e9e"
          }
        }]
      }
    };
      fetch("Home/GetProductosMasVendidos") //hacer la peticion al controlador
          .then((response) => { //obtener la respuesta
              return response.ok ? response.json() : Promise.reject(response);  //validar si la respuesta es correcta
          })    //obtener los datos de la respuesta
          .then((dataJson) => { //obtener los datos de la respuesta
              console.log(dataJson) //mostrar los datos en la consola
              const chart_labels = dataJson.map((producto) => { return producto.nombreProducto }) //obtener las fechas de las ventas
              //obtner los valores de las ventas
              const chart_data = dataJson.map((producto) => { return producto.totalVendido })  //obtener los valores de las ventas
              //Sumar el total de productos vendidos
              const totalProductosVendidos = chart_data.reduce((total, cantidad) => { return total + cantidad }, 0)
              //mostrar el resulatdo de la suma en el html
              document.getElementById("totalProductosVendidos").innerHTML = totalProductosVendidos
    var ctx = document.getElementById("chartLinePurple").getContext("2d");

      var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

      gradientStroke.addColorStop(1, 'rgba(6,134,121,0.15)');
      gradientStroke.addColorStop(0.4, 'rgba(66,145,121,0.0)'); //green colors
      gradientStroke.addColorStop(0, 'rgba(66,145,121,0)'); //green colors

           var config = {
               type: 'line',
               data: {
                   labels: chart_labels,
                   datasets: [{
                       label: "Total Vendido",
                       fill: true,
                       backgroundColor: gradientStroke,
                       borderColor: '#00d6b4',
                       borderWidth: 2,
                       borderDash: [],
                       borderDashOffset: 0.3,
                       pointBackgroundColor: '#00d6b4',
                       pointBorderColor: 'rgba(255,255,255,0)',
                       pointHoverBackgroundColor: '#00d6b4',
                       pointBorderWidth: 20, 
                       pointHoverRadius: 4,
                       pointHoverBorderWidth: 10,
                       pointRadius: 4,
                       data: chart_data,
                   }]
               },
               options: gradientBarChartConfiguration

              };//fin de la configuracion


              const myChartData = new Chart(ctx, config);
    })    //fin de la promesa


    var ctxGreen = document.getElementById("chartLineGreen").getContext("2d");

    var gradientStroke = ctxGreen.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, 'rgba(6,134,121,0.15)');
    gradientStroke.addColorStop(0.4, 'rgba(66,145,121,0.0)'); //green colors
    gradientStroke.addColorStop(0, 'rgba(66,145,121,0)'); //green colors

    var data = {
      labels: ['JUL', 'AUG', 'SEP', 'OCT', 'NOV'],
      datasets: [{
        label: "My First dataset",
        fill: true,
        backgroundColor: gradientStroke,
        borderColor: '#00d6b4',
        borderWidth: 2,
        borderDash: [],
        borderDashOffset: 0.0,
        pointBackgroundColor: '#00d6b4',
        pointBorderColor: 'rgba(255,255,255,0)',
        pointHoverBackgroundColor: '#00d6b4',
        pointBorderWidth: 20,
        pointHoverRadius: 4,
        pointHoverBorderWidth: 15,
        pointRadius: 4,
        data: [90, 27, 60, 12, 80],
      }]
    };

    var myChart = new Chart(ctxGreen, {
      type: 'line',
      data: data,
      options: gradientChartOptionsConfigurationWithTooltipGreen

    });

    


    //var chart_labels = ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'];
    //var chart_data = [100, 70, 90, 70, 85, 60, 75, 60, 90, 80, 110, 100];
      //Referenciar el controlador de asp.net
      fetch("Home/VentasMensuales") //hacer la peticion al controlador
          .then((response) => { //obtener la respuesta
              return response.ok ? response.json() : Promise.reject(response);  //validar si la respuesta es correcta
          })    //obtener los datos de la respuesta
          .then((dataJson) => { //obtener los datos de la respuesta
              console.log(dataJson) //mostrar los datos en la consola
              const chart_labels = dataJson.map((fechaVenta) => { return fechaVenta.fechaVenta }) //obtener las fechas de las ventas
              //obtner los valores de las ventas
              const chart_data = dataJson.map((totalVenta) => { return totalVenta.total })  //obtener los valores de las ventas
              console.log(chart_labels) //mostrar las fechas en la consola
              console.log(chart_data) //mostrar los valores en la consola


    var ctx = document.getElementById("chartBig1").getContext('2d');

    var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

      gradientStroke.addColorStop(1, 'rgba(66,134,121,0.15)');
      gradientStroke.addColorStop(0.4, 'rgba(66,134,121,0.0)'); //green colors
      gradientStroke.addColorStop(0, 'rgba(66,134,121,0)'); //green colors
              var config = {
                  type: 'line',
                  data: {
                      labels: chart_labels,
                      datasets: [{
                          label: "Monto Total",
                          fill: true,
                          backgroundColor: gradientStroke,
                          borderColor: '#00d6b4',
                          borderWidth: 2,
                          borderDash: [],
                          borderDashOffset: 0.0,
                          pointBackgroundColor: '#00d6b4',
                          pointBorderColor: 'rgba(255,255,255,0)',
                          pointHoverBackgroundColor: '#00d6b4',
                          pointBorderWidth: 20,
                          pointHoverRadius: 4,
                          pointHoverBorderWidth: 15,
                          pointRadius: 4,
                          data: chart_data,
                      }]
                  },
                  options: gradientChartOptionsConfigurationWithTooltipPurple,
    

    };//fin de la configuracion
   
              const myChartData = new Chart(ctx, config);
              $("#0").click(function () {  //evento click
                  console.log(chart_data) //mostrar los datos en la consola)
                  var data = myChartData.config.data;    //obtener la configuracion de la grafica
                  data.datasets[0].data = chart_data;   //agregar los valores a la grafica
                  data.labels = chart_labels; //agregar las fechas a la grafica
                  myChartData.update(); //actualizar la grafica
              }); //fin del evento click
              $("#1").click(function () {
                  fetch('Home/VentasTrimestrales')
                  .then((response) => {
                            return response.ok ? response.json() : Promise.reject(response);
                        })
                        .then((dataJson) => {
                            const chart_labels = dataJson.map((fechaVenta) => { return fechaVenta.fechaVenta })
                            const chart_data = dataJson.map((totalVenta) => { return totalVenta.total })
                            console.log(chart_labels)
                            console.log(chart_data)
                            var data = myChartData.config.data;
                            data.datasets[0].data = chart_data;
                            data.labels = chart_labels;
                            myChartData.update();
                        });// fin de la promesa
              });
              $("#2").click(function () {
                  fetch('Home/VentasSemanales')
                      .then((response) => {
                          return response.ok ? response.json() : Promise.reject(response);
                      })
                      .then((dataJson) => {
                          const chart_labels = dataJson.map((fechaVenta) => { return fechaVenta.fechaVenta })
                          const chart_data = dataJson.map((totalVenta) => { return totalVenta.total })
                          var data = myChartData.config.data;
                          data.datasets[0].data = chart_data;
                          data.labels = chart_labels;
                          myChartData.update();
                      });// fin de la promesa
              });
   })    //fin de la promesa


      




    

    



    var ctx = document.getElementById("CountryChart").getContext("2d");

    var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, 'rgba(29,140,248,0.2)');
    gradientStroke.addColorStop(0.4, 'rgba(29,140,248,0.0)');
    gradientStroke.addColorStop(0, 'rgba(29,140,248,0)'); //blue colors


    var myChart = new Chart(ctx, {
      type: 'bar',
      responsive: true,
      legend: {
        display: false
      },
      data: {
        labels: ['USA', 'GER', 'AUS', 'UK', 'RO', 'BR'],
        datasets: [{
          label: "Countries",
          fill: true,
          backgroundColor: gradientStroke,
          hoverBackgroundColor: gradientStroke,
          borderColor: '#1f8ef1',
          borderWidth: 2,
          borderDash: [],
          borderDashOffset: 0.0,
          data: [53, 20, 10, 80, 100, 45],
        }]
      },
      options: gradientBarChartConfiguration
    });

  },

  showNotification: function(from, align) {
    color = Math.floor((Math.random() * 4) + 1);

    $.notify({
      icon: "tim-icons icon-bell-55",
      message: "Welcome to <b>Black Dashboard</b> - a beautiful freebie for every web developer."

    }, {
      type: type[color],
      timer: 8000,
      placement: {
        from: from,
        align: align
      }
    });
  }

};
//****************************************************************************************************************************************************************

//Crear una funcion que permit recuperar los datos de la base de datos y mostrarlos en la grafica
function obtenerDatos() {

    ////Referenciar el controlador de asp.net
    //fetch("Home/VentasMensuales")
    //    .then((response) => {
    //        return response.ok ? response.json() : Promise.reject(response);
    //    })
    //    .then((dataJson) => {
    //    const labels = dataJson.map((fechaVenta) => { return fechaVenta.fechaVenta })
    //    const values = dataJson.map((item) => { return item.MontoTotal })

    //    const data = {
    //        labels: labels,
    //        datasets: [{
    //            label: "Ventas",
    //            fill: true,
    //            backgroundColor: gradientStroke,
    //            borderColor: '#00d6b4',
    //            borderWidth: 2,
    //            borderDash: [],
    //            borderDashOffset: 0.0,
    //            pointBackgroundColor: '#00d6b4',
    //            pointBorderColor: 'rgba(255,255,255,0)',
    //            pointHoverBackgroundColor: '#00d6b4',
    //            pointBorderWidth: 20,
    //            pointHoverRadius: 4,
    //            pointHoverBorderWidth: 15,
    //            pointRadius: 4,
    //            data: values,
    //        }]

    //    };
    //    const config = {
    //        type: 'line',
    //        data: data,
    //        options: gradientChartOptionsConfigurationWithTooltipGreen,
    //    };
    //    const context = document.getElementById("chartBig1").getContext("2d");
    //    const graphbars = new Chart(context, config)
    //})
}//Fin de la funcion obtenerDatos

$(document).ready(() =>{
    obtenerDatos();
});