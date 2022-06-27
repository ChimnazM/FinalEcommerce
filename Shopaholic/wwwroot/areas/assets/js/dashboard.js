
(function($) {
  'use strict';
  $(function() {
    if ($("#dashboard-rating-1").length) {
      $('#dashboard-rating-1').barrating({
        theme: 'fontawesome-stars',
        showSelectedRating: false,
        initialRating: '2',
      });
    }
    if ($("#dashboard-rating-2").length) {
      $('#dashboard-rating-2').barrating({
        theme: 'fontawesome-stars',
        showSelectedRating: false,
        initialRating: '4',
      });
    }
    if ($("#dashboard-rating-3").length) {
      $('#dashboard-rating-3').barrating({
        theme: 'fontawesome-stars',
        showSelectedRating: false,
        initialRating: '3',
      });
    }
    if ($("#dashboard-rating-4").length) {
      $('#dashboard-rating-4').barrating({
        theme: 'fontawesome-stars',
        showSelectedRating: false,
        initialRating: '1',
      });
    }
    if ($("#dashboard-lineChart").length) {
      var lineChartCanvas = $("#dashboard-lineChart").get(0).getContext("2d");
      var lineChart = new Chart(lineChartCanvas, {
        type: 'line',
        data: {
          labels: ["2013", "2014", "2014", "2015", "2016", "2017"],
          datasets: [{
            data: [2, 4, 3, 3, 2, 3],
            backgroundColor: [
              '#e6f2fb'
            ],
            borderColor: [
              'rgba(102, 16 ,242, 1)'
            ],
            borderWidth: 2
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          scales: {
            xAxes: [{
              gridLines: {
                drawBorder: false,
                display: false
              },
              ticks: {
                display: false,
              }
            }],
            yAxes: [{
              gridLines: {
                drawBorder: false,
                display: false,
              },
              ticks: {
                display: false,
              }
            }]
          },
          legend: {
            display: false
          },
          elements: {
            point: {
              radius: 0
            }
          }
        }
      });
    }
    if ($("#dashboard-lineChart-2").length) {
      var lineChartCanvas = $("#dashboard-lineChart-2").get(0).getContext("2d");
      var lineChart = new Chart(lineChartCanvas, {
        type: 'line',
        data: {
          labels: ["2013", "2014", "2014", "2015", "2016", "2017"],
          datasets: [{
            data: [2, 4, 3, 3, 2, 3],
            pointBackgroundColor: "#fff",
            pointBorderWidth: 1,
            backgroundColor: [
              'rgba(0,0,0,0)'
            ],
            borderColor: [
              '#caa8f9'
            ],
            borderWidth: 1
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          scales: {
            xAxes: [{
              gridLines: {
                drawBorder: false,
                display: false
              },
              ticks: {
                display: false,
              }
            }],
            yAxes: [{
              gridLines: {
                drawBorder: false,
                display: false,
              },
              ticks: {
                display: false,
              }
            }]
          },
          legend: {
            display: false
          },
          tooltips: {
            enabled: false
          },
          layout: {
            padding: {
              top: 5,
              bottom: 5
            }
          }
        }
      });
    }
    if ($("#dashboard-lineChart-3").length) {
      var lineChartCanvas = $("#dashboard-lineChart-3").get(0).getContext("2d");
      var lineChart = new Chart(lineChartCanvas, {
        type: 'line',
        data: {
          labels: ["2013", "2014", "2014", "2015", "2016", "2017"],
          datasets: [{
            data: [2, 4, 3, 3, 2, 3],
            pointBackgroundColor: "#fff",
            pointBorderWidth: 1,
            backgroundColor: [
              'rgba(0,0,0,0)'
            ],
            borderColor: [
              '#fff'
            ],
            borderWidth: 1
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          scales: {
            xAxes: [{
              gridLines: {
                drawBorder: false,
                display: false
              },
              ticks: {
                display: false,
              }
            }],
            yAxes: [{
              gridLines: {
                drawBorder: false,
                display: false,
              },
              ticks: {
                display: false,
              }
            }]
          },
          legend: {
            display: false
          },
          tooltips: {
            enabled: false
          },
          layout: {
            padding: {
              top: 5,
              bottom: 5
            }
          }
        }
      });
    }
    if ($("#dashboard-donut-chart").length) {
      $(function() {
        var total = 62;
        var browsersChart = Morris.Donut({
          element: 'dashboard-donut-chart',
          data: [{
              label: "Download Sales",
              value: 12
            },
            {
              label: "In-Store Sales",
              value: 30
            },
            {
              label: "Mail-Order Sales",
              value: 20
            }
          ],
          resize: true,
          colors: ['#03a9f3', '#00c292', '#dddddd'],
          formatter: function(value, data) {
            return Math.floor(value / total * 100) + '%';
          }
        });

        browsersChart.options.data.forEach(function(label, i) {
          var legendItem = $('<span></span>').text(label['label']).prepend('<span>&nbsp;</span>');
          legendItem.find('span')
            .css('backgroundColor', browsersChart.options.colors[i]);
          $('#legend').append(legendItem)
        });
      });
    }
    if ($('#morris-line-example').length) {
      Morris.Line({
        element: 'morris-line-example',
        lineColors: ['#dadada', '#fb9678'],
        data: [{
            y: '2006',
            a: 50,
            b: 0
          },
          {
            y: '2007',
            a: 75,
            b: 78
          },
          {
            y: '2008',
            a: 30,
            b: 12
          },
          {
            y: '2009',
            a: 35,
            b: 50
          },
          {
            y: '2010',
            a: 70,
            b: 100
          },
          {
            y: '2011',
            a: 78,
            b: 65
          }
        ],
        grid: false,
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: "always"
      });
    }


    if ($("#dashboard-monthly-analytics").length) {
        var ctx = document.getElementById('dashboard-monthly-analytics').getContext("2d");

        $.ajax({

            url: "admin/home/getStatisticsCategories/",
            type: "get",
            dataType: "json",

            //data: { typeId: TypeId, quantity: Quantity },
            success: function (response) {


                var jan = response.jan;
                var janSum = jan[0] + jan[1] + jan[2] + jan[3];
                if (janSum != 0) {
                    jan[0] = jan[0] / janSum * 100;
                    jan[1] = jan[1] / janSum * 100;
                    jan[2] = jan[2] / janSum * 100;
                    jan[3] = jan[3] / janSum * 100;
                }

                var feb = response.feb;
                var febSum = feb[0] + feb[1] + feb[2] + feb[3];
                if (febSum != 0) {
                    feb[0] = feb[0] / febSum * 100;
                    feb[1] = feb[1] / febSum * 100;
                    feb[2] = feb[2] / febSum * 100;
                    feb[3] = feb[3] / febSum * 100;
                }

                var mar = response.mar;
                var marSum = mar[0] + mar[1] + mar[2] + mar[3];
                if (marSum != 0) {
                    mar[0] = mar[0] / marSum * 100;
                    mar[1] = mar[1] / marSum * 100;
                    mar[2] = mar[2] / marSum * 100;
                    mar[3] = mar[3] / marSum * 100;
                }

                var apr = response.apr;
                var aprSum = apr[0] + apr[1] + apr[2] + apr[3];
                if (aprSum != 0) {
                    apr[0] = apr[0] / aprSum * 100;
                    apr[1] = apr[1] / aprSum * 100;
                    apr[2] = apr[2] / aprSum * 100;
                    apr[3] = apr[3] / aprSum * 100;
                }

                var may = response.may;
                var maySum = may[0] + may[1] + may[2] + may[3];
                if (maySum != 0) {
                    may[0] = may[0] / maySum * 100;
                    may[1] = may[1] / maySum * 100;
                    may[2] = may[2] / maySum * 100;
                    may[3] = may[3] / maySum * 100;
                }

                var jun = response.jun;
                var junSum = jun[0] + jun[1] + jun[2] + jun[3];
                if (junSum != 0) {
                    jun[0] = jun[0] / junSum * 100;
                    jun[1] = jun[1] / junSum * 100;
                    jun[2] = jun[2] / junSum * 100;
                    jun[3] = jun[3] / junSum * 100;
                }

                var jul = response.jul;
                var julSum = jul[0] + jul[1] + jul[2] + jul[3];
                if (julSum != 0) {
                    jul[0] = jul[0] / julSum * 100;
                    jul[1] = jul[1] / julSum * 100;
                    jul[2] = jul[2] / julSum * 100;
                    jul[3] = jul[3] / julSum * 100;
                }

                console.log(julSum);
                console.log(jul[0]);

                var aug = response.aug;
                var augSum = jun[0] + jun[1] + jun[2] + jun[3];
                if (augSum != 0) {
                    aug[0] = aug[0] / augSum * 100;
                    aug[1] = aug[1] / augSum * 100;
                    aug[2] = aug[2] / augSum * 100;
                    aug[3] = aug[3] / augSum * 100;
                }

                var sep = response.sep;
                var sepSum = sep[0] + sep[1] + sep[2] + sep[3];
                if (sepSum != 0) {
                    sep[0] = sep[0] / sepSum * 100;
                    sep[1] = sep[1] / sepSum * 100;
                    sep[2] = sep[2] / sepSum * 100;
                    sep[3] = sep[3] / sepSum * 100;
                }

                var oct = response.oct;
                var octSum = oct[0] + oct[1] + oct[2] + oct[3];
                if (octSum != 0) {
                    oct[0] = oct[0] / octSum * 100;
                    oct[1] = oct[1] / octSum * 100;
                    oct[2] = oct[2] / octSum * 100;
                    oct[3] = oct[3] / octSum * 100;
                }

                var nov = response.nov;
                var novSum = nov[0] + nov[1] + nov[2] + nov[3];
                if (novSum != 0) {
                    nov[0] = nov[0] / novSum * 100;
                    nov[1] = nov[1] / novSum * 100;
                    nov[2] = nov[2] / novSum * 100;
                    nov[3] = nov[3] / novSum * 100;
                }

                var dec = response.dec;
                var decSum = dec[0] + dec[1] + dec[2] + dec[3];
                if (decSum != 0) {
                    dec[0] = dec[0] / decSum * 100;
                    dec[1] = dec[1] / decSum * 100;
                    dec[2] = dec[2] / decSum * 100;
                    dec[3] = dec[3] / decSum * 100;
                }


                var myChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: ['Jan', 'Feb', 'Mar', 'Arl', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                        datasets: [{
                            label: "Best Seller",
                            borderColor: 'rgb(171, 140 ,228)',
                            backgroundColor: 'rgba(171, 140 ,228, 0.8)',
                            pointRadius: 0,
                            fill: false,
                            borderWidth: 1,
                            //fill: 'origin',
                            data: [jan[0], feb[0], mar[0], apr[0], may[0], jun[0], jul[0], aug[0], sep[0], oct[0], nov[0], dec[0]]
                        },
                        {
                            label: "Featured",
                            borderColor: 'rgb(88, 216 ,163)',
                            backgroundColor: 'rgba(88, 216 ,163, 0.7)',
                            pointRadius: 0,
                            fill: false,
                            borderWidth: 1,
                            //fill: 'origin',
                            data: [jan[1], feb[1], mar[1], apr[1], may[1], jun[1], jul[1], aug[1], sep[1], oct[1], nov[1], dec[1]]
                        },
                        {
                            label: "New Arrival",
                            borderColor: 'rgb(255, 180 ,99)',
                            backgroundColor: 'rgba(255, 180 ,99, 0.7)',
                            pointRadius: 0,
                            fill: false,
                            borderWidth: 1,
                            //fill: 'origin',
                            data: [jan[2], feb[2], mar[2], apr[2], may[2], jun[2], jul[2], aug[2], sep[2], oct[2], nov[2], dec[2]]
                        },
                        {
                            label: "Special Offer",
                            borderColor: '#f6e84e',
                            backgroundColor: '#f6e84e',
                            pointRadius: 0,
                            fill: false,
                            borderWidth: 1,
                            //fill: 'origin',
                            data: [jan[3], feb[3], mar[3], apr[3], may[3], jun[3], jul[3], aug[3], sep[3], oct[3], nov[3], dec[3]]
                        },

                        ]
                    },
                    options: {
                        maintainAspectRatio: false,
                        legend: {
                            display: false,
                            position: "top"
                        },
                        scales: {
                            xAxes: [{
                                ticks: {
                                    display: true,
                                    beginAtZero: true,
                                    fontColor: 'rgba(0, 0, 0, 1)'
                                },
                                gridLines: {
                                    display: false,
                                    drawBorder: false,
                                    color: 'transparent',
                                    zeroLineColor: '#eeeeee'
                                }
                            }],
                            yAxes: [{
                                gridLines: {
                                    drawBorder: true,
                                    display: true,
                                    color: '#eeeeee',
                                },
                                categoryPercentage: 0.5,
                                ticks: {
                                    display: true,
                                    beginAtZero: true,
                                    stepSize: 20,
                                    max: 100,
                                    fontColor: 'rgba(0, 0, 0, 1)'
                                }
                            }]
                        },
                    },
                    elements: {
                        point: {
                            radius: 0
                        }
                    }
                });

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });


      document.getElementById('js-legend').innerHTML = myChart.generateLegend();
    }


    if ($("#dashboard-monthly-analytics-dark").length) {
      var ctx = document.getElementById('dashboard-monthly-analytics-dark').getContext("2d");
      var myChart = new Chart(ctx, {
        type: 'line',
        data: {
          labels: ['Jan', 'Feb', 'Mar', 'Arl', 'May', 'Jun', 'Jul', 'Aug'],
          datasets: [{
              label: "Ios",
              borderColor: 'rgb(171, 140 ,228)',
              backgroundColor: 'rgba(171, 140 ,228, 0.8)',
              pointRadius: 0,
              fill: false,
              borderWidth: 1,
              //fill: 'origin',
              data: [0, 0, 30, 0, 0, 0, 50, 0]
            },
            {
              label: "Android",
              borderColor: 'rgb(88, 216 ,163)',
              backgroundColor: 'rgba(88, 216 ,163, 0.7)',
                pointRadius: 0,
                fill: false,
              borderWidth: 1,
              //fill: 'origin',
              data: [0, 35, 0, 0, 30, 0, 0, 0]
            },
            {
              label: "Windows",
              borderColor: 'rgb(255, 180 ,99)',
              backgroundColor: 'rgba(255, 180 ,99, 0.7)',
                pointRadius: 0,
                fill: false,
              borderWidth: 1,
              //fill: 'origin',
              data: [0, 0, 0, 40, 10, 50, 0, 0]
            }
          ]
        },
        options: {
          maintainAspectRatio: false,
          legend: {
            display: false,
            position: "top"
          },
          scales: {
            xAxes: [{
              ticks: {
                display: true,
                beginAtZero: true,
                fontColor: '#76838f'
              },
              gridLines: {
                display: false,
                drawBorder: false,
                color: '#2a2c40',
                zeroLineColor: '#eeeeee'
              }
            }],
            yAxes: [{
              gridLines: {
                drawBorder: true,
                display: true,
                color: '#2a2c40',
              },
              categoryPercentage: 0.5,
              ticks: {
                display: true,
                beginAtZero: true,
                stepSize: 20,
                max: 80,
                fontColor: '#76838f'
              }
            }]
          },
        },
        elements: {
          point: {
            radius: 0
          }
        }
      });
      document.getElementById('js-legend').innerHTML = myChart.generateLegend();
    }
    if ($('#morris-area-example').length) {
      var browsersChart = Morris.Area({
        element: 'morris-area-example',
        lineColors: ['#00c292', '#03a9f3'],
        fillOpacity: 0.1,
        xLabelMargin: 10,
        yLabelMargin: 10,
        data: [{
            y: '2006',
            a: 30,
            b: 0
          },
          {
            y: '2007',
            a: 75,
            b: 50
          },
          {
            y: '2008',
            a: 30,
            b: 12
          },
          {
            y: '2009',
            a: 55,
            b: 50
          },
          {
            y: '2010',
            a: 40,
            b: 60
          },
          {
            y: '2011',
            a: 60,
            b: 45
          },
          {
            y: '2012',
            a: 60,
            b: 35
          }
        ],
        grid: false,
        axes: false,
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: "always",
        formatter: function(value, data) {
          return Math.floor(value / total * 100) + '%';
        }
      });
    }
    if ($("#morris-dashboard-bar-chart").length) {
      Morris.Bar({
        element: 'morris-dashboard-bar-chart',
        barColors: ['#fe946b', '#b663e6'],
        barGap: 9,
        barSizeRatio: 0.55,
        hideHover: 'always',
        grid: false,
        data: [{
            y: 'a',
            a: 30,
            b: 40
          },
          {
            y: 'b',
            a: 55,
            b: 65
          },
          {
            y: 'c',
            a: 60,
            b: 70
          },
          {
            y: 'd',
            a: 55,
            b: 45
          },
          {
            y: 'e',
            a: 40,
            b: 45
          }
        ],
        xkey: 'y', 
        ykeys: ['a', 'b'],
        axes: 'x',
        labels: ['Series A', 'Series B']
      });
    }
    if($("#growth-chart").length) {
      $("#growth-chart").sparkline('html', {
        enableTagOptions: true,
        type: 'bar',
        width: '100%',
        height: '50',
        fillColor: 'false',
        barColor: '#fb9678',
        barWidth: 4,
        barSpacing: 4,
        chartRangeMin: 0
      });
    }
  });
})(jQuery);