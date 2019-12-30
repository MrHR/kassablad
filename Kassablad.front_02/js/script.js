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
        let data = $('#form_01').serialize();
        const result = jData.sendData(data, 'https://localhost:5001/api/kassacontainer', 'POST');

        result.done(function (data) {
            console.log('success kascontainer', data);
            jKassablad.kassaContainer = data;
            jKassablad.nextFormField(event);
        }).fail(function(error) {
            console.log('fail kascontainer', error);
        });
    },

    createBeginKassa: function (event) {
        let data = $('#form_02').serialize();
        data += "&KassaContainerId=" + jKassablad.kassaContainer.id
        + "&Type=BeginKassa"
        + "&NaamTapper=" + jKassablad.kassaContainer.NaamTapper;
        
        const result = jData.sendData(data, 'https://localhost:5001/api/kassa', 'POST');

        result.done(function (data) {
            console.log('success kassa', data);
            jKassablad.beginKassa = data;
            jConsumpties.fillConsumpties();
            jKassablad.nextFormField(event);
        }).fail(function(errorObj, errormsg, msg) {
            console.log('fail kassa', msg);
        });
    },

    
}

var jConsumpties = {
    consumpties: null,
    fillConsumpties: function () {
        var result = jData.getData('https://localhost:5001/api/Consumptie');

        result.done(function (data) {
            //console.log('get data success: ' + JSON.stringify(data));
            jConsumpties.consumpties = data;
            jConsumpties.createConsumpties();
        }).fail(function (errorObj, errormsg, msg) {
            console.log('fail get data', msg);
        });
    },

    createConsumpties: function () {
        var consumptieTabel = $('#consumptieTabel');
        var html = '';
        $.map(jConsumpties.consumpties, function (consumptie, id) {
            var el = `<tr>
                        <td>${consumptie.naam}</td>
                        <td class="border"><input type="number" id="${consumptie.naam}" value="0" min="0" prijs="${consumptie.prijs}" readonly /></td>
                        <td>
                            <button type="button" class="positive ui button" id="buttonUp${consumptie.naam}" onclick="buttonClick('${consumptie.naam}}', +1)">+</button>
                            <button type="button" class="negative ui button" id="buttonUp${consumptie.naam}" onclick="buttonClick('${consumptie.naam}', -1)">-</button>
                        </td>
                    </tr>`

            consumptieTabel.append($(el));
            
        });

        console.log('html: ' + html);
        consumptieTabel.append($(html));
    }
};

var jData = {
    getData: function (url) {
        var result = $.ajax({
            url: url,
            type: 'GET'
        });

        return result;
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
}; 

function buttonClick(Id, value) {
    //console.log(document.getElementById(Id).value);
    var i = parseInt(document.getElementById(Id).value);
    if ((i >= 0 && value > 0) || i > 0) {
        i += value;
    }
    document.getElementById(Id).value = i;
}