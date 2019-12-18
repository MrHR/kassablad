var jKassablad = {
    kassaContainer: null,
    InitKassa: function () {
        //document.querySelector('.btnNext').addEventListener('click', jKassablad.nextFormField);
    },

    nextFormField: function (event) { 
        var btnNext = document.getElementById(event.target.id);

        btnNext.closest('.form').style.display = 'none';
        btnNext.closest('.form').nextElementSibling.style.display = 'block';
    },

    createKassaContainer: function(event) {

        jKassablad.nextFormField(event);

        var data = new FormData(document.querySelector('#form_01'));
        // data.append('Active', true);
        // data.append('DateAdded', null);
        // data.append('DateUpdated', null);
        // data.append('UpdatedBy', 1);
        // data.append('CreatedBy', 1);
        // data.append('BeginUur', null);
        // data.append('EindUur', null);
        // data.append('Notes', null);
        // data.append('NaamTapperSluit', '');
        // data.append('Bezoekers', 0);
        // data.append('Afroomkluis', 0);
        // data.append('InkomstBar', 0);
        // data.append('InkomstLidkaart', 0);

        jKassablad.sendData($('#form_01').serialize(), 'https://localhost:5001/api/kassacontainer');
        //jKassablad.sendData(data, 'https://localhost:5001/api/kassacontainer');
    },

    sendData: function (formData, url) {
        console.log(formData);
        var result = $.ajax({
            url: url,
            type: 'POST',
            // processData: false,
            // contentType: false,
            datatype: 'json',
            data: formData,
            success: function (data, response) {
                if(response == "success") {
                    jKassablad.kassaContainer = data;
                    console.log(jKassablad.kassaContainer);
                } else {
                    console.log(response);
                }
            },
            fail: function () { 
                console.log('fail');
            }
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