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
            console.log("next form field");
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
            console.log('success kassa ', data);
            jKassablad.beginKassa = data;
            jConsumpties.fillConsumpties();
            jKassablad.nextFormField(event);
        }).fail(function(errorObj, errormsg, msg) {
            console.log('fail kassa ', msg);
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
        //Fetch 
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
                    </tr>`;

            consumptieTabel.append($(el));

            //Add onclick event plus one
            $(`#buttonUp${consumptie.naam}`).on('click', function () {
                buttonClick(`consumptie.naam`, +1);
            });

            //Add onclick event -1
            $(`#buttonDown${consumptie.naam}`).on('click', function () {
                buttonClick(`consumptie.naam`, -1);
            });
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
        console.log('formdata: ' + formData);
        var result = $.ajax({
            url: url,
            type: type,
            datatype: 'json',
            data: formData
        });

        return result;
    }
}; 

var jKassaCalulations = {
    pnm: null,
    pnm2: null,
    price: null,
    price2: null,
    subtot: null,
    subtot2: null,
    grdtot: null,
    grdtot2: null,
    eindtot: null,

    calculateKassa: function () {
        $('.pnm, .pnm2, .price, .price2, .subtot, .subtot2, .grdtot, .grdtot2').prop('readonly', true);
        var $tblrows = $("#tblProducts tbody tr");

        $tblrows.each(function (index) {
            var $tblrow = $(this);

            $tblrow.find('.qty').on('change', function () {

                var qty = $tblrow.find("[class=qty]").val();
                var qty2 = $tblrow.find("[class=qty2]").val();
                var price = $tblrow.find("[class=price]").val();
                var price2 = $tblrow.find(" [class=price2]").val();
                var subTotal = parseInt(qty, 10) * parseFloat(price);
                var subTotal2 = parseInt(qty2, 10) * parseFloat(price2);


                if (!isNaN(subTotal)) {

                    $tblrow.find('.subtot').val(subTotal.toFixed(2));
                    var grandTotal = 0;
                   


                    $(".subtot").each(function () {
                        var stval = parseFloat($(this).val());
                        grandTotal += isNaN(stval) ? 0 : stval;
                        
                    });

                    $('.grdtot').val(grandTotal.toFixed(2));
                    
                }
                if (!isNaN(subTotal2)) {

                    $tblrow.find('.subtot').val(subTotal2.toFixed(2));
                    var grandTotal2 = 0;



                    $(".subtot2").each(function () {
                        var stval = parseFloat($(this).val());
                        grandTotal2 += isNaN(stval) ? 0 : stval;

                    });

                    $('.grdtot2').val(grandTotal2.toFixed(2));
                    $('.eindtot').val()

                }
            });
        });

    }

};

var consumpties = {
    createConsumpties: function () {
        
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