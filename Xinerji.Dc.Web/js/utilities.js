var jsonServiceURL = "";

$(document).ready(function () {
    $(".amountinput").on("input", function () {
        // allow numbers, a comma or a dot
        var v = $(this).val(), vc = v.replace(/[^0-9,\.]/, '');
        if (v !== vc)
            $(this).val(vc);
    });


    window.onclick = function (event) {

      
        if (!event.target.matches('.form-control') &&
            !event.target.matches('.input-group-addon')) {

            
            var dropdowns = document.getElementsByClassName("dropdown-content");
            var i;
            for (i = 0; i < dropdowns.length; i++) {
                var openDropdown = dropdowns[i];
                if (openDropdown.classList.contains('show')) {
                    openDropdown.classList.remove('show');
                }
            }
        }
    }

    
});



(function () {
    var mainapp = angular.module('mainApp');
    
    
    mainapp.factory('utilities', function(){
        return {
            getMonths: function(){
                return [{
                            "id" : 0,
                            "name":"Ay"
                        },
                        {
                            "id" : 1,
                            "name":"Ocak"
                        },
                        {
                            "id" : 2,
                            "name":"Şubat"
                        },
                        {
                            "id" : 3,
                            "name":"Mart"
                        },
                        {
                            "id" : 4,
                            "name":"Nisan"
                        },
                        {
                            "id" : 5,
                            "name":"Mayıs"
                        },
                        {
                            "id" : 6,
                            "name":"Haziran"
                        },
                        {
                            "id" : 7,
                            "name":"Temmuz"
                        },      
                        {
                            "id" : 8,
                            "name":"Ağustos"
                        },
                        {
                            "id" : 9,
                            "name":"Eylül"
                        },
                        {
                            "id" : 10,
                            "name":"Ekim"
                        },
                        {
                            "id" : 11,
                            "name":"Kasım"
                        },
                        {
                            "id" : 12,
                            "name":"Aralık"
                        }
                    ];
            },
        
            getDays : function(){
                var days = [{ "id": 0, "name": "Gün"}];
        
                for(var i=1; i<32; i++){
                    days.push({ "id": i, "name": i});
                }
                return days;
            },
        
            
            getYears : function(){
                var years = [{ "id": 0, "name": "Yıl"}];
        
                for(var i=2016; i>1920; i--){
                    years.push({ "id": i, "name": i});
                }
                return years;
            },

            converJsonDate : function (jsonDate) {
                var shortDate = null;
                if (jsonDate) {
                    var regex = /-?\d+/;
                    var matches = regex.exec(jsonDate);
                    var dt = new Date(parseInt(matches[0]));
                    var month = dt.getMonth() + 1;
                    var monthString = month > 9 ? month : '0' + month;
                    var day = dt.getDate();
                    var dayString = day > 9 ? day : '0' + day;
                    var year = dt.getFullYear();
                    shortDate = dayString  + '/' + monthString + '/' + year;
                }

                return shortDate;
            },

            formatAmount: function (n) {
                try {
                    if (this.typeOf(n) == "string") {
                        if (n == "")
                            n = 0;
                        n = n.replace('.', '');
                        n = parseFloat(n.replace(',', '.'));
                    }

                    return " " + n.toFixed(2).replace(/./g, function (c, i, a) {
                        a = i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                        a = a.replace('.', '#');
                        a = a.replace(',', '.');
                        a = a.replace('#', ',');
                        return a;
                    });
                }
                catch (err) {
                    console.log(err)
                    return n;
                }
            },
            formatAmountForJsonRequest: function (n) {
                return n.replace('.', '');
            },
            parseFloat: function (n) {
                n = n.replace('.', '');
                n = n.replace(',', '.');
                return parseFloat(n);
            },
            typeOf: function (obj) {
                return Object.prototype.toString.call(obj).replace(/^\[object (.+)\]$/, "$1").toLowerCase()
            },
            getQueryString: function (name) {
               var url = window.location.href;
                name = name.replace(/[\[\]]/g, "\\$&");
                var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                    results = regex.exec(url);
                if (!results) return null;
                if (!results[2]) return '';
                return decodeURIComponent(results[2].replace(/\+/g, " "));
            }
        
        }
    });
    
    
    
}());