//datepicker
$(function () {
    $("#date").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#date").datepicker("setDate", new Date());
});

$('#date').on('input change', function () {
    var thisDate;
    thisDate = $("#date").datepicker('getDate');
    var selectedWinnaars = [];
    for (var i = 0; i < winnaarsDefault.length; i++) {
        var parts = winnaarsDefault[i].datum.split('-');
        var dateDb = new Date(parts[2], parts[1] - 1, parts[0]);

        if ((new Date(thisDate).getTime() == new Date(dateDb).getTime())) {
            selectedWinnaars.push(winnaarsDefault[i]);
        }

        else {
        }
    }
    winnaars = selectedWinnaars;
    vulTable();
});


//ophalen kassaContainers

var jKassaBlad = {
    kassaContainers: null,
    fillkassaBladList: function () {
        
            var result = jData.getData('https://localhost:5001/api/KassaContainer');

            result.done(function (data) {
                console.log('get data success: ' + JSON.stringify(data));
                jKassaBlad.kassaContainers = data;
                jKassaBlad.createKassaBlad();
            }).fail(function (errorObj, errormsg, msg) {
                console.log('fail get data', msg);
            });
        
    },

    createKassaBlad: function () {

        var kassaBladen = $('#kassaContainers');

        $.map(jKassaBlad.kassaContainers, function (KassaContainer, id) {
            console.log(KassaContainer);
            var el = `<tr>
                        <td>${KassaContainer.naamTapper}</td>
                        <td>${moment(KassaContainer.dateAdded).format('LLL')}</td>
                        <td>${KassaContainer.inkomstBar}</td>
                    </tr>`;

            kassaBladen.append($(el));
            
        });
    },
};



var jData = {
    getData: function (url) {
        const result = $.ajax({
            url: url,
            type: 'GET',
           
        });

        return result;
    },

    sendData: function (formData, url, type) {
        //console.log('formdata: ' + formData);
        const result = $.ajax({
            url: url,
            type: type,
            datatype: 'json',
            data: formData,
          
        });

        return result;
    }
}; 
