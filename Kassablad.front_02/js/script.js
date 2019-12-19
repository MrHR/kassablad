var jKassablad = {
    kassaContainer: null,
    beginKassa: null,
    InitKassa: function () {
    },

    nextFormField: function (event) { 
        var btnNext = document.getElementById(event.target.id);

        btnNext.closest('.form').style.display = 'none';
        btnNext.closest('.form').nextElementSibling.style.display = 'block';
    },

    createKassaContainer: function(event) {
        var result = jKassablad.sendData($('#form_01').serialize(), 'https://localhost:5001/api/kassacontainer', 'POST');
        result.done(function (data) {
            console.log('success kascontainer', data);
            jKassablad.kassaContainer = data;
            jKassablad.nextFormField(event);
        }).fail(function(error) {
            console.log('fail kascontainer', error);
        });
    },

    createBeginKassa: function (event) {
        var result = jKassablad.sendData($('#form_02').serialize(), 'https://localhost:5001/api/kassa', 'POST');
        result.done(function (data) {
            console.log('success kassa', data);
            jKassablad.beginKassa = data;
            jKassablad.nextFormField(event);
        }).fail(function(errorObj, errormsg, msg) {
            console.log('fail kassa', msg);
        });
    },

    sendData: function (formData, url, type) {
        console.log('formdata:' + formData);
        var result = $.ajax({
            url: url,
            type: type,
            datatype: 'json',
            data: formData
        });

        return result;
    }
}

function buttonClick(Id, value) {
    //console.log(document.getElementById(Id).value);
    var i = parseInt(document.getElementById(Id).value);
    if ((i >= 0 && value > 0) || i > 0) {
        i += value;
    }
    document.getElementById(Id).value = i;
}