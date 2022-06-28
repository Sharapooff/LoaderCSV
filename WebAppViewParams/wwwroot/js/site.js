// Write your JavaScript code.

let MS = [];
let PKM_Seconds = [];
let thrust_brake = [];
let voltage = [];
let generator_ov_current = [];
let current_compressor_motor = [];
let temperature_B1 = [];
let temperature_A5 = [];
let ETD_current = [];
let rail_TNVD = [];
let rotation_frequency = [];
let test = [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175];

$.ajax({
    type: 'GET',//тип запроса
    url: '/Home/GetParametrs', //метод, который срабатывает на запрос
    data: {
        'json_param': 'param'//параметр для метода
    },
    success: function (data) {
        alert(data);  
        data = JSON.parse(data);

        $.each(data, function (key, val) {
            PKM_Seconds.push(val.PKM_Seconds);
            thrust_brake.push(val.thrust_brake);
            voltage.push(val.voltage);
            generator_ov_current.push(val.generator_ov_current);
            current_compressor_motor.push(val.current_compressor_motor);
            temperature_B1.push(val.temperature_B1);
            temperature_A5.push(val.temperature_A5);
            ETD_current.push(val.ETD_current);
            rail_TNVD.push(val.rail_TNVD);
            rotation_frequency.push(val.rotation_frequency);       
        });

        Highcharts.chart('container', {
            title: {
                text: 'Грвфики параметров работы локомотива'
            },

            subtitle: {
                text: 'Данные: АО ВНИКТИ'
            },

            yAxis: {
                title: {
                    text: 'Параметры'
                }
            },

            xAxis: {
                accessibility: {
                    rangeDescription: 'Диапазон: 2010 to 2017'
                }
            },

            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle'
            },

            plotOptions: {
                series: {
                    label: {
                        connectorAllowed: false
                    }//,
                    //pointStart: 2010
                }
            },

            series: [{
                    name: 'ПКМ',
                    data: PKM_Seconds
                }, {
                    name: 'Напряжение',
                    data: voltage
                }, {
                    name: 'Температура В1',
                    data: temperature_B1
                }, {
                    name: 'Температура А5',
                    data: temperature_A5
                }, {
                    name: 'ЭТД',
                    data: ETD_current
                }, {
                    name: 'ТНВД',
                    data: rail_TNVD
                }, {
                    name: 'Частота_вращения',
                    data: rotation_frequency
                }],

            responsive: {
                rules: [{
                    condition: {
                        maxWidth: 5000
                    },
                    chartOptions: {
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            verticalAlign: 'bottom'
                        }
                    }
                }]
            }
        });
    }
});

