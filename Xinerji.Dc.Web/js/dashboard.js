// Daterange picker
$('.input-daterange-datepicker').daterangepicker({
    buttonClasses: ['btn', 'btn-sm'],
    applyClass: 'btn-danger',
    cancelClass: 'btn-inverse',
    locale: {
        "daysOfWeek": [
            "Pz",
            "Pzt",
            "Sal",
            "Çrş",
            "Prş",
            "Cm",
            "Cmt"
        ],
        "monthNames": [
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"
        ],
        "applyLabel": "Tamam",
        "cancelLabel": "İptal",
        "format": "DD/MM/YYYY"
    }
});
$('.input-daterange-timepicker').daterangepicker({
    timePicker: true,
    format: 'MM/DD/YYYY h:mm A',
    timePickerIncrement: 30,
    timePicker12Hour: true,
    timePickerSeconds: false,
    buttonClasses: ['btn', 'btn-sm'],
    applyClass: 'btn-danger',
    cancelClass: 'btn-inverse',

    locale: {
        "daysOfWeek": [
            "Pz",
            "Mo",
            "Tu",
            "We",
            "Th",
            "Fr",
            "Sa"
        ],
        "monthNames": [
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"
        ],
        "applyLabel": "Tamam",
        "cancelLabel": "İptal",
        "format": "DD/MM/YYYY"
    }
});


$(document).ready(function () {

    $.ajax({
        type: 'POST',
        url: jsonServiceURL + "/page/pageload",
        dataType: 'json',
        data: JSON.stringify({
            Url: window.location.pathname
        }),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {

        },
        error: function (error) {

        }
    });



});
