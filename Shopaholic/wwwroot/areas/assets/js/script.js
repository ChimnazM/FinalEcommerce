(function ($) {
    'use strict';
    CKEDITOR.replace('Info')
    CKEDITOR.replace('Text')
    CKEDITOR.replace('Desc')
    CKEDITOR.replace('Context')
    CKEDITOR.replace('Answer')
    CKEDITOR.replace('About')



})(jQuery);


//Category Pie
let ctx = document.getElementById("product-pie").getContext("2d");
let labels = ['Best Seller', 'Featured', 'New Arrival', 'Special Offer'];
let colorHex = ['#FB3640', '#EFCA08', '#43AA8B', '#253D5B'];

$.ajax({

    url: "admin/home/getSalesByCategories/",
    type: "get",
    dataType: "json",

    //data: { typeId: TypeId, quantity: Quantity },
    success: function (response) {

        var allCount = response.allSaleItemsCount;
        var best = response.bestSellerCount;
        var featured = response.featuredCount;
        var newArrival = response.newArrivalCount;
        var special = response.specialOfferCount;


        var bestPercent = (parseFloat(best / allCount * 100)).toFixed(1);
        var featuredPercent = (parseFloat(featured / allCount * 100)).toFixed(1);
        var newArrivalPercent = (parseFloat(newArrival / allCount * 100)).toFixed(1);
        var specialPercent = (parseFloat(special / allCount * 100)).toFixed(1);

        let myChart = new Chart(ctx, {
            type: 'pie',
            data: {
                datasets: [{
                    data: [bestPercent, featuredPercent, newArrivalPercent, specialPercent],
                    backgroundColor: colorHex
                }],
                labels: labels
            },
            options: {
                responsive: true,
                legend: {
                    position: 'bottom'
                },
                plugins: {
                    datalabels: {
                        color: '#fff',
                        anchor: 'end',
                        align: 'start',
                        offset: -10,
                        borderWidth: 2,
                        borderColor: '#fff',
                        borderRadius: 25,
                        backgroundColor: (context) => {
                            return context.dataset.backgroundColor;
                        },
                        font: {
                            weight: 'bold',
                            size: '10'
                        },
                        formatter: (value) => {
                            return value + ' %';
                        }
                    }
                }
            }
        });

    },
    error: function (response) {

        console.log("error: " + response);
    }

});





//Gender Pie
let ctx2 = document.getElementById("product-gender-pie").getContext("2d");
let labels2 = ['Male', 'Female', "Kid's"];
let colorHex2 = ['blue', 'red', 'green'];

$.ajax({

    url: "admin/home/getSalesByGender/",
    type: "get",
    dataType: "json",

    //data: { typeId: TypeId, quantity: Quantity },
    success: function (response) {

        var all = response.allSaleItemsCount;
        var male = response.maleSaleItemsCount;
        var female = response.femaleSaleItemsCount;
        var kids = response.kidsSaleItemsCount;

        var malePercent = (male / all * 100).toFixed(1);
        var femalePercent = (female / all * 100).toFixed(1);
        var kidsPercent = (kids / all * 100).toFixed(1);

        let myChart2 = new Chart(ctx2, {
            type: 'pie',
            data: {
                datasets: [{
                    data: [malePercent, femalePercent, kidsPercent],
                    backgroundColor: colorHex2
                }],
                labels: labels2
            },
            options: {
                responsive: true,
                legend: {
                    position: 'bottom'
                },
                plugins: {
                    datalabels: {
                        color: '#fff',
                        anchor: 'end',
                        align: 'start',
                        offset: -10,
                        borderWidth: 2,
                        borderColor: '#fff',
                        borderRadius: 25,
                        backgroundColor: (context) => {
                            return context.dataset.backgroundColor;
                        },
                        font: {
                            weight: 'bold',
                            size: '10'
                        },
                        formatter: (value) => {
                            return value + ' %';
                        }
                    }
                }
            }
        });


    },
    error: function (response) {

        console.log("error: " + response);
    }

});



