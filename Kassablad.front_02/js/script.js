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
        jLogin.mgr.getUser().then(function(user) {
            let data = $('#form_01').serialize();
            const result = jData.sendData(data, 'https://localhost:5001/api/kassacontainer', 'POST', user);
    
            result.done(function (data) {
                jKassablad.kassaContainer = data;
                console.log('success kascontainer', jKassablad.kassaContainer);
                console.log("next form field");
                jKassablad.nextFormField(event);
            }).fail(function(error) {
                console.log('fail kascontainer', error);
            });
        });
    },

    createBeginKassa: function (event) {
        jLogin.mgr.getUser().then(function(user) {
            let data = $('#form_02').serialize();
            data += "&KassaContainerId=" + jKassablad.kassaContainer.id
            + "&Type=BeginKassa"
            + "&NaamTapper=" + jKassablad.kassaContainer.NaamTapper;
            
            const result = jData.sendData(data, 'https://localhost:5001/api/kassa', 'POST', user);

            result.done(function (data) {
                console.log('success kassa ', data);
                jKassablad.beginKassa = data;
                jConsumpties.fillConsumpties();
                jKassablad.nextFormField(event);
            }).fail(function(errorObj, errormsg, msg) {
                console.log('fail kassa ', msg);
            });
        });
    },
}

var jConsumpties = {
    consumpties: null,
    fillConsumpties: function () {
        jLogin.mgr.getUser().then(function (user) {
            var result = jData.getData('https://localhost:5001/api/Consumptie', user);

            result.done(function (data) {
                //console.log('get data success: ' + JSON.stringify(data));
                jConsumpties.consumpties = data;
                jConsumpties.createConsumpties();
            }).fail(function (errorObj, errormsg, msg) {
                console.log('fail get data', msg);
            });
        });
    },

    createConsumpties: function () {
        //Fetch 
        var consumptieTabel = $('#consumptieTabel');
        var consumptieTabelEten = $('#consumptieTabelFood');

        $.map(jConsumpties.consumpties, function (consumptie, id) {
            var el = `<tr>
                        <td>${consumptie.naam}</td>
                        <td class="border"><input type="number" class="cCount" id="${consumptie.naam}" cId="${consumptie.id}" ccId="0" dateAdded="" createdBy="" value="0" min="0" prijs="${consumptie.prijs}" readonly /></td>
                        <td>
                            <button type="button" class="positive ui button" id="buttonUp${consumptie.naam}" onclick="jConsumpties.postConsumptieCount('${consumptie.naam}', +1)">+</button>
                            <button type="button" class="negative ui button" id="buttonUp${consumptie.naam}" onclick="jConsumpties.postConsumptieCount('${consumptie.naam}', -1)">-</button>
                        </td>
                    </tr>`;

            if(consumptie.type == 'Drank') {
                consumptieTabel.append($(el));
            } else if(consumptie.type = 'Eten') {
                consumptieTabelEten.append($(el));
            }
        });
    },

    postConsumptieCount: function (Id, value) {
        jLogin.mgr.getUser().then(function (user) {
            //call buttonClick function to add or deduct value
            buttonClick(Id, value);

            var consumptieId = $(`#${Id}`).attr('cId');
            var ccId = parseInt($(`#${Id}`).attr('ccId'));
            var createdBy = $(`#${Id}`).attr('createdBy');
            var dateAdded = $(`#${Id}`).attr('dateAdded');
            var aantal = parseInt($(`#${Id}`).val());
            var drink = {};

            //Add values to drink object
            drink['consumptieId'] = consumptieId;
            drink['aantal'] = aantal;
            drink['KassaContainerId'] = jKassablad.kassaContainer.id;
            drink['user'] = user.Id;

            console.log('drink ', drink);

            //send data
            var result = null;
            //check if this drinkcount already exists
            if(ccId === 0) { //if no then POST data
                result = jData.sendData(drink, 'https://localhost:5001/api/ConsumptieCount', 'POST', user);
            } else { //if yes then PUT data
                drink['Id'] = ccId;
                drink['CreatedBy'] = createdBy;
                drink['DateAdded'] = dateAdded;
                result = jData.sendData(drink, `https://localhost:5001/api/ConsumptieCount/${ccId}`, 'PUT', user);
            }

            //display result
            result.done(function(result) {
                if(result) { //if drinkCount POST'ed set id of drink
                    $(`#${Id}`).attr('ccId', result.id);
                    $(`#${Id}`).attr('createdBy', result.createdBy);
                    $(`#${Id}`).attr('dateAdded', result.dateAdded);
                }
            }).fail(function () {
                console.log('failed to save consumptionCount');
            });    
        });
    }
};

var jData = {
    getData: function (url, user) {
        const result = $.ajax({
            url: url,
            type: 'GET',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + user.access_token)
            }
        });

        return result;
    },

    sendData: function (formData, url, type, user) {
        //console.log('formdata: ' + formData);
        const result = $.ajax({
            url: url,
            type: type,
            datatype: 'json',
            data: formData,
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + user.access_token)
            }
        });

        return result;
    }
}; 

var jKassaCalulations = {
    grandTotal: null,

    calculateKassa: function () {
        $('.pnm, .pnm2, .price, .price2, .subtot, .subtot2, .grdtot, .grdtot2, .eindtot').prop('readonly', true);
        var $tblrows = $("#tblProducts tbody tr");

        $tblrows.each(function (index) {
            var $tblrow = $(this);

            $tblrow.find('.qty, .qty2').on('change', function () {

                var qty = $tblrow.find("[class=qty]").val();
                var qty2 = $tblrow.find("[class=qty2]").val();
                var price = $tblrow.find("[class=price]").val();
                var price2 = $tblrow.find(" [class=price2]").val();
                var subTotal = parseInt(qty, 10) * parseFloat(price);
                var subTotal2 = parseInt(qty2, 10) * parseFloat(price2);


                if (!isNaN(subTotal)) {

                    $tblrow.find('.subtot').val(subTotal.toFixed(2));
                    jKassaCalulations.grandTotal = 0;
                   


                    $(".subtot").each(function () {
                        var stval = parseFloat($(this).val());
                        jKassaCalulations.grandTotal += isNaN(stval) ? 0 : stval;
                        
                    });

                    $('.grdtot').val(jKassaCalulations.grandTotal.toFixed(2));
                    
                }
                if (!isNaN(subTotal2)) {

                    $tblrow.find('.subtot2').val(subTotal2.toFixed(2));
                    var grandTotal2 = 0;



                    $(".subtot2").each(function () {
                        var stval = parseFloat($(this).val());
                        grandTotal2 += isNaN(stval) ? 0 : stval;

                    });

                    $('.grdtot2').val(grandTotal2.toFixed(2));
                    $('.eindtot').val(grandTotal2 - jKassaCalulations.grandTotal);

                }
            });
        });

    }

};

var jLogin = {
    config: null,
    mgr: null,
    init: function () {
        document.getElementById("btnStart").addEventListener("click", jLogin.login, false);
        document.getElementById("login").addEventListener("click", jLogin.login, false);
        //document.getElementById("api").addEventListener("click", api, false);
        document.getElementById("logout").addEventListener("click", jLogin.logout, false);

        jLogin.config = {
            authority: "http://localhost:5000",
            client_id: "front_02",
            redirect_uri: "http://localhost:8000/callback.html",
            response_type: "code",
            scope:"openid profile api1",
            post_logout_redirect_uri : "http://localhost:8000/kassablad.html",
        };
        jLogin.mgr = new Oidc.UserManager(jLogin.config);

        jLogin.mgr.getUser().then(function (user) {
            if (user) {
                jLogin.log("User logged in", user.profile);
                document.getElementById('login').style.display = 'none';
                document.getElementById('logout').style.display = 'block';
            }
            else {
                jLogin.log("User not logged in");
                document.getElementById('login').style.display = 'block';
                document.getElementById('logout').style.display = 'none';
            }
        });

        console.log('logout ', jLogin.mgr);
    },

    log: function () {
        //document.getElementById('results').innerText = '';

        Array.prototype.forEach.call(arguments, function (msg) {
            if (msg instanceof Error) {
                msg = "Error: " + msg.message;
            }
            else if (typeof msg !== 'string') {
                msg = JSON.stringify(msg, null, 2);
            }
            //document.getElementById('results').innerHTML += msg + '\r\n';
        });
    },

    login: function () {
        jLogin.mgr.getUser().then(function(user) {
            if(!user) {
                jLogin.mgr.signinRedirect();
            }
        });
    },

    api: function () {
        jLogin.mgr.getUser().then(function (user) {
            var url = "https://localhost:5001/identity";
    
            var xhr = new XMLHttpRequest();
            xhr.open("GET", url);
            xhr.onload = function () {
                jLogin.log(xhr.status, JSON.parse(xhr.responseText));
            }
            xhr.setRequestHeader("Authorization", "Bearer " + user.access_token);
            xhr.send();
        });
    },

    logout: function () {
        jLogin.mgr.getUser().then(function(user) {
            if(user) {
                jLogin.mgr.signoutRedirect();
            }
        });
    }
};

function buttonClick(Id, value) {
    // console.log('id: ' + Id);
    var i = parseInt(document.getElementById(Id).value);
    if ((i >= 0 && value > 0) || i > 0) {
        i += value;
    }
    document.getElementById(Id).value = i;
}